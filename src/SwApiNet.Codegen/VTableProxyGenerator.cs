using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SwApiNet.Codegen;

[Generator]
public class VTableProxyGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Register the attribute source
        context.RegisterPostInitializationOutput(i =>
        {
            var attributeSource = @"
namespace SwApiNet.Codegen;

[System.AttributeUsage(System.AttributeTargets.Interface, Inherited=false)]
public class VTableProxyAttribute: System.Attribute {} 
";
            i.AddSource("VTableProxyAttribute.g.cs", attributeSource);
        });

        // does not work in tests:
        //var provider = context.SyntaxProvider.ForAttributeWithMetadataName("SwApiNet.Codegen.VTableProxyAttribute", IsInterface, CollectDataAfterAttribute);
        var data = context.SyntaxProvider.CreateSyntaxProvider(IsInterface, CollectData);
        var files = data.Where(x => x != null).Select((x, _) => x!.Value).Select((x, _) => (name: $"{x.StructName}.g", content: GenerateContent(x)));
        context.RegisterSourceOutput(files, Output);
    }

    private void Output(SourceProductionContext context, (string name, string content) x)
    {
        context.AddSource(x.name, x.content);
    }

    private bool IsInterface(SyntaxNode node, CancellationToken token)
    {
        return node is InterfaceDeclarationSyntax;
    }

    private DataToGenerate? CollectData(GeneratorSyntaxContext context, CancellationToken token)
    {
        var declaredSymbol = context.SemanticModel.GetDeclaredSymbol(context.Node);
        if (declaredSymbol is null) return null;

        if (declaredSymbol is not INamedTypeSymbol symbol) return null;

        if (!declaredSymbol.GetAttributes().Any(x => x.AttributeClass?.Name.StartsWith("VTableProxy") == true)) return null;

        var functions = new List<Member>();
        var symbolMembers = symbol.GetMembers();
        foreach (var x in symbolMembers)
        {
            if (x is IMethodSymbol method)
            {
                if (x.Name.StartsWith("get_"))
                {
                    continue;
                }
                // declare delegate and proxies
                var args = new List<Arg>();
                foreach (var methodParameter in method.Parameters)
                {
                    var type = methodParameter.Type.ToString();
                    var name = methodParameter.Name;
                    args.Add(new Arg(type, name));
                }

                functions.Add(new Member(x.Name, new RecordArray<Arg>(args), method.ReturnType.ToString(), true));
            }
            else if (x is IPropertySymbol prop)
            {
                // declare field
                functions.Add(new Member(x.Name, new RecordArray<Arg>(), prop.Type.ToString(), false));
            }}

        return new DataToGenerate(symbol.Name, symbol.ContainingNamespace.ToString(), new RecordArray<Member>(functions));
    }

    private string GenerateContent(DataToGenerate data)
    {
        var interopInit = new StringBuilder();
        foreach (var x in data.Functions)
        {
            if (x.IsMethod)
            {
                interopInit.AppendLine($"        Interop.{x.Name}Real = real->{x.Name}Ptr;");
            }
            else
            {
                interopInit.AppendLine($"        Interop.{x.Name}Real = real->{x.Name}Val;");
                interopInit.AppendLine($"        Interop.{x.Name}Fake = real->{x.Name}Val;");
            }
        }

        var structPointersInit = new StringBuilder();
        foreach (var x in data.Functions)
        {
            if (x.IsMethod)
            {
                structPointersInit.AppendLine($"        this.{x.Name}Ptr = Interop.{x.Name}Fake;");
            }
            else
            {
                // no way to use proxy chain for field containint a value
                structPointersInit.AppendLine($"        this.{x.Name}Val = real->{x.Name};");
            }
        }

        var structFields = new StringBuilder();
        foreach (var x in data.Functions)
        {
            if (x.IsMethod)
            {
                structFields.AppendLine($"    public delegate* unmanaged[Thiscall]<{x.ArgsGeneric.Value}> {x.Name}Ptr;");
            }
            else
            {
                structFields.AppendLine($"    public {x.ReturnType} {x.Name}Val;");
            }
        }

        var structMethods = new StringBuilder();
        foreach (var x in data.Functions)
        {
            if (x.IsMethod)
            {
                structMethods.AppendLine($"    public {x.ReturnType} {x.Name}({x.ArgsDefinition.Value}) => Interop.Target.{x.Name}({x.ArgsList.Value});");
            }
            else
            {
                structMethods.AppendLine($"    public {x.ReturnType} {x.Name} => this.{x.Name}Val;");
            }
        }

        var logMethods = new StringBuilder();
        foreach (var x in data.Functions)
        {
            if (x.IsMethod)
            {
                var argsBag = string.Join(".", x.Args.Select(x => $"Add({x.Name})"));
                logMethods.AppendLine($"        public {x.ReturnType} {x.Name}({x.ArgsDefinition.Value}) => Tools.LogMethod(() => target.{x.Name}({x.ArgsList.Value}), ArgsBag.Init().{argsBag});");
            }
            else
            {
                logMethods.AppendLine($"        public {x.ReturnType} {x.Name} => Tools.LogMethod(() => target.{x.Name}, ArgsBag.Empty);");
            }
        }

        var passThroughMethods = new StringBuilder();
        foreach (var x in data.Functions)
        {
            if (x.IsMethod)
            {
                passThroughMethods.AppendLine($"        public {x.ReturnType} {x.Name}({x.ArgsDefinition.Value}) => Interop.{x.Name}Real({x.ArgsList.Value});");
            }
            else
            {
                passThroughMethods.AppendLine($"        public {x.ReturnType} {x.Name} => Interop.{x.Name}Real;");
            }
        }

        var interceptMethods = new StringBuilder();
        foreach (var x in data.Functions)
        {
            if (x.IsMethod)
            {
                interceptMethods.AppendLine($"        public virtual {x.ReturnType} {x.Name}({x.ArgsDefinition.Value}) => target.{x.Name}({x.ArgsList.Value});");
            }
            else
            {
                interceptMethods.AppendLine($"        public virtual {x.ReturnType} {x.Name} => target.{x.Name};");
            }
        }

        var interopReal = new StringBuilder();
        foreach (var x in data.Functions)
        {
            if (x.IsMethod)
            {
                interopReal.AppendLine($"        public static delegate* unmanaged[Thiscall]<{x.ArgsGeneric.Value}> {x.Name}Real {{ get; set; }}");
            }
            else
            {
                interopReal.AppendLine($"        public static {x.ReturnType} {x.Name}Real {{ get; set; }}");
            }
        }

        var interopFake = new StringBuilder();
        foreach (var x in data.Functions)
        {
            if (x.IsMethod)
            {
                interopFake.AppendLine($"        public static delegate* unmanaged[Thiscall]<{x.ArgsGeneric.Value}> {x.Name}Fake {{ get; set; }} = &{x.Name}Export;");
            }
            else
            {
                interopReal.AppendLine($"        public static {x.ReturnType} {x.Name}Fake {{ get; set; }}");
            }
        }

        var interopExports = new StringBuilder();
        foreach (var x in data.Functions)
        {
            if (x.IsMethod)
            {
                interopExports.AppendLine($"        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvThiscall)])] public static {x.ReturnType} {x.Name}Export({x.ArgsDefinition}) => Target.{x.Name}({x.ArgsList});");
            }
        }

        var text = $$"""
                     using System.Runtime.CompilerServices;
                     using System.Runtime.InteropServices;

                     namespace {{data.Namespace}};

                     /// <inheritdoc />
                     [StructLayout(LayoutKind.Sequential)]
                     public unsafe partial struct {{data.StructName}} : {{data.InterfaceName}}
                     {
                         /// <inheritdoc />
                         public {{data.StructName}}({{data.StructName}}* real)
                         {
                             // can't store directly in the struct, it will affect size
                             Interop.Target = new InterceptWrapper(new LogWrapper(new PassThroughWrapper()));
                     
                             // replace real pointers
                             // fields will be equal to values of real struct
                             // methods will point to fake exported delegates to call wrapper chain
                     {{interopInit}}
                             // wire fake pointers
                     {{structPointersInit}}
                         }
                     
                         // actual fields
                     {{structFields}}
                         // internally callable methods
                     {{structMethods}}
                     
                         /// <inheritdoc />
                         public class LogWrapper({{data.InterfaceName}} target) : {{data.InterfaceName}}
                         {
                     {{logMethods}}
                         }
                     
                         /// <inheritdoc />
                         public class PassThroughWrapper() : {{data.InterfaceName}}
                         {
                     {{passThroughMethods}}
                         }
                     
                         /// <inheritdoc />
                         public class InterceptWrapperBase({{data.InterfaceName}} target) : {{data.InterfaceName}}
                         {
                     {{interceptMethods}}
                         }
                     
                         /// <inheritdoc />
                         public class InterceptWrapper({{data.InterfaceName}} target) : InterceptWrapperBase(target)
                         {
                             // write overrides manually here when needed
                         }
                     
                         /// <summary>
                         /// Generated from <see cref="{{data.InterfaceName}}"/>
                         /// </summary>
                         public static class Interop
                         {
                             public static {{data.InterfaceName}} Target { get; set; } = null!;

                     {{interopReal}}
                     {{interopFake}}
                     {{interopExports}}
                         }
                     }
                     """;
        return text;
    }
}
