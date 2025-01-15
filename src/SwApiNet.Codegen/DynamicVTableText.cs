using System.Text;

namespace SwApiNet.Codegen;

public static class DynamicVTableText
{
    public static GeneratedResult GenerateContent(DataToGenerate data)
    {
        if (!data.InterfaceName.StartsWith("I"))
        {
            throw new InvalidOperationException($"""Interface name must start with "I" for proper code generation""");
        }

        if (!data.InterfaceName.EndsWith("VTable"))
        {
            throw new InvalidOperationException($"""Interface name must end with "VTable" for proper code generation""");
        }

        if (data.Functions.Any(x => !x.IsMethod))
        {
            throw new InvalidOperationException($"""Dynamic VTable proxy does not support properties/fields. Declare all members as functions""");
        }

        var functionsWithoutFirstArg = data.Functions
            .Where(x => !x.Args.Any())
            .Select(x => $"{x.Name}()")
            .ToList();
        if(functionsWithoutFirstArg.Any())
        {
            throw new InvalidOperationException($"""Every function must have first argument of type "{data.ParentType}", it will be generated automatically. Functions with no arguments: {string.Join(", ", functionsWithoutFirstArg)}""");
        }

        var requiredType = $"{data.ParentType}*";
        var functionsWithBadFirstArgs = data.Functions
            .Where(x => x.Args.FirstOrDefault().Type.Split('.').Last() != requiredType)
            .Select(x => $"{x.Name}({x.Args.FirstOrDefault().Type})")
            .ToList();
        if(functionsWithBadFirstArgs.Any())
        {
            throw new InvalidOperationException($"""Every function must have first argument of type "{requiredType}", it will be generated automatically. Functions with invalid first arguments: {string.Join(", ", functionsWithBadFirstArgs)}""");
        }

        var structPointersInit = new StringBuilder();
        foreach (var x in data.Functions)
        {
            structPointersInit.AppendLine($"            this.{x.Name}Ptr = Interop.{x.Name}Fake;");

        }

        var structFields = new StringBuilder();
        foreach (var x in data.Functions)
        {
            structFields.AppendLine($"        public delegate* unmanaged[Thiscall]<{x.ArgsGeneric.Value}> {x.Name}Ptr;");
        }

        var structMethods = new StringBuilder();
        foreach (var x in data.Functions)
        {
            if (x.IsMethod) structMethods.AppendLine($"        public {x.ReturnType} {x.Name}({x.ArgsDefinition.Value}) => {x.Name}Ptr({x.ArgsList.Value});");
        }

        var logMethods = new StringBuilder();
        foreach (var x in data.Functions)
        {
            var argsBag = string.Join(".", x.Args.Select(x => $"Add({x.Name})"));
            logMethods.AppendLine($"        public {x.ReturnType} {x.Name}({x.ArgsDefinition.Value}) => Tools.LogMethod(() => target.{x.Name}({x.ArgsList.Value}), ArgsBag.Init().{argsBag}, \"{data.ParentType}\");");
        }

        var passThroughMethods = new StringBuilder();
        foreach (var x in data.Functions)
        {
            passThroughMethods.AppendLine($"        public {x.ReturnType} {x.Name}({x.ArgsDefinition.Value}) => real->{x.Name}Ptr({x.ArgsList.Value});");

        }

        var interceptMethods = new StringBuilder();
        foreach (var x in data.Functions)
        {
            if (x.IsMethod)
                if (x.DeadBeef)
                {
                    interceptMethods.AppendLine($"        public {x.ReturnType} {x.Name}({x.ArgsDefinition.Value}) => target.{x.Name}({x.ArgsList.Value});");
                }
                else
                {
                    interceptMethods.AppendLine($"        public virtual {x.ReturnType} {x.Name}({x.ArgsDefinition.Value}) => target.{x.Name}({x.ArgsList.Value});");
                }
        }

        var interopFake = new StringBuilder();
        foreach (var x in data.Functions)
        {
            interopFake.AppendLine($"        public static delegate* unmanaged[Thiscall]<{x.ArgsGeneric.Value}> {x.Name}Fake {{ get; set; }} = &{x.Name}Export;");
        }

        var interopExports = new StringBuilder();
        foreach (var x in data.Functions)
        {
            if (x.DeadBeef)
            {
                // return stub value right away
                interopExports.AppendLine($"        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvThiscall)])] public static {x.ReturnType} {x.Name}Export({x.ArgsDefinition}) => (nint)Tools.DeadBeef;");
            }
            else
            {
                interopExports.AppendLine($"        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvThiscall)])] public static {x.ReturnType} {x.Name}Export({x.ArgsDefinition}) => EntrypointByFakeVTable[(nint){x.Args.First().Name}->Table].{x.Name}({x.ArgsList});");
            }

        }

        var text = $$"""
                     using System.Runtime.CompilerServices;
                     using System.Runtime.InteropServices;
                     using SwApiNet.Wrappers.Utils;

                     namespace {{data.Namespace}};

                     /// <inheritdoc />
                     [StructLayout(LayoutKind.Sequential)]
                     public unsafe partial struct {{data.ParentType}}
                     {
                         public unsafe VTable* Table;
                         public Fields OtherFields;
                         
                         public static nint Hijack(nint real)
                         {
                             return (nint)Hijack(({{data.ParentType}}*) real);
                         }
                     
                         public static nint Hijack({{data.ParentType}}* real)
                         {
                             // allocate unmanaged memory. VTables are static and can be cached forever, no freeing required
                             var fake = ({{data.ParentType}}*)Marshal.AllocHGlobal(sizeof({{data.ParentType}}));
                             fake->Table = ({{data.ParentType}}.VTable*) Marshal.AllocHGlobal(sizeof({{data.ParentType}}.VTable));
                             // init proxy struct and related stuff
                             Marshal.StructureToPtr(new {{data.ParentType}}.VTable(real->Table), (nint)fake->Table, true);
                             Interop.EntrypointByFakeVTable[(nint)fake->Table] = new InterceptWrapper(new LogWrapper(new PassThroughWrapper(real->Table)));
                             return (nint)fake;
                         }
                     
                         /// <inheritdoc />    
                         [StructLayout(LayoutKind.Sequential)]
                         public partial struct Fields{
                         }
                         
                         /// <inheritdoc />
                         [StructLayout(LayoutKind.Sequential)]
                         public unsafe partial struct VTable : {{data.InterfaceName}}
                         {
                             /// <inheritdoc />
                             public VTable(VTable* real)
                             {
                                 // wire fake pointers and values
                     {{structPointersInit}}
                             }
                     
                             // actual fields
                     {{structFields}}
                             // internally callable methods
                     {{structMethods}}
                         }
                         
                         /// <inheritdoc />
                         public partial class LogWrapper({{data.InterfaceName}} target) : {{data.InterfaceName}}
                         {
                     {{logMethods}}
                         }
                     
                         /// <inheritdoc />
                         public partial class PassThroughWrapper(VTable* real) : {{data.InterfaceName}}
                         {
                     {{passThroughMethods}}
                         }
                     
                         /// <inheritdoc />
                         public partial class InterceptWrapperBase({{data.InterfaceName}} target) : {{data.InterfaceName}}
                         {
                     {{interceptMethods}}
                         }
                     
                         /// <inheritdoc />
                         public partial class InterceptWrapper({{data.InterfaceName}} target) : InterceptWrapperBase(target)
                         {
                             // write overrides manually here when needed
                         }
                     
                         /// <summary>
                         /// Generated from <see cref="{{data.InterfaceName}}"/>
                         /// </summary>
                         public static partial class Interop
                         {
                             public static readonly Dictionary<nint, {{data.InterfaceName}}> EntrypointByFakeVTable = new();

                     {{interopFake}}
                     {{interopExports}}
                         }
                     }
                     """;

        return data.Success(text);
    }
}
