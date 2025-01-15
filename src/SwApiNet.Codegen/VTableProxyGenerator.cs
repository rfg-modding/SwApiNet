using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SwApiNet.Codegen;

[Generator]
public class VTableProxyGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        AddAttributes(context);

        // does not work in tests:
        //var provider = context.SyntaxProvider.ForAttributeWithMetadataName("SwApiNet.Codegen.VTableProxyAttribute", IsInterface, CollectDataAfterAttribute);
        var data = context.SyntaxProvider.CreateSyntaxProvider(IsInterface, CollectData);
        var files = data.Where(x => x != null).Select((x, _) => x!.Value).Select((x, _) => GenerateContent(x));
        context.RegisterSourceOutput(files, Output);
    }

    private static void AddAttributes(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(i =>
        {
            var attributeSource = @"
namespace SwApiNet.Codegen;

[System.AttributeUsage(System.AttributeTargets.Interface, Inherited=false)]
public class StaticVTableProxyAttribute: System.Attribute {}

[System.AttributeUsage(System.AttributeTargets.Interface, Inherited=false)]
public class DynamicVTableProxyAttribute: System.Attribute {}

[System.AttributeUsage(System.AttributeTargets.Property, Inherited=false)]
public class UnusedAttribute: System.Attribute {}

[System.AttributeUsage(System.AttributeTargets.Method, Inherited=false)]
public class DeadBeefAttribute: System.Attribute {}
";
            i.AddSource("VTableProxyAttribute.g.cs", attributeSource);
        });
    }

    private void Output(SourceProductionContext context, GeneratedResult x)
    {
        if (!string.IsNullOrWhiteSpace(x.Error))
        {
            context.ReportDiagnostic(Diagnostic.Create("RFG", "Codegen", $"Failed to generate {x.Filename}: {x.Error}", DiagnosticSeverity.Error, DiagnosticSeverity.Error, true, default));
        }
        else
        {
            context.AddSource(x.Filename, x.Content!);

        }
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

        var attr = declaredSymbol.GetAttributes().SingleOrDefault(x => x.AttributeClass?.Name.Contains("VTableProxy") == true);
        if (attr is null)
        {
            return null;
        }
        var isDynamic = attr.AttributeClass?.Name.Contains("Dynamic") == true;

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

                var deadBeef = method.GetAttributes().Any(a => a.AttributeClass?.Name.StartsWith("DeadBeef") == true);
                var args = new List<Arg>();
                foreach (var methodParameter in method.Parameters)
                {
                    var type = methodParameter.Type.ToString();
                    var name = methodParameter.Name;
                    args.Add(new Arg(type, name));
                }

                // declare delegate and proxies
                functions.Add(new Member(x.Name, new RecordArray<Arg>(args), method.ReturnType.ToString(), true, false, deadBeef));
            }
            else if (x is IPropertySymbol prop)
            {
                var unused = prop.GetAttributes().Any(a => a.AttributeClass?.Name.StartsWith("Unused") == true);
                // declare field
                functions.Add(new Member(x.Name, new RecordArray<Arg>(), prop.Type.ToString(), false, unused, false));
            }
        }


        return new DataToGenerate(symbol.Name, symbol.ContainingNamespace.ToString(), new RecordArray<Member>(functions), isDynamic);
    }

    private GeneratedResult GenerateContent(DataToGenerate data)
    {
        try
        {
            if (data.IsDynamic)
            {
                return DynamicVTableText.GenerateContent(data);

            }
            else
            {
                return StaticVTableText.GenerateContent(data);
            }
        }
        catch (Exception e)
        {
            return data.Failure(e.ToString());
        }
    }


}
