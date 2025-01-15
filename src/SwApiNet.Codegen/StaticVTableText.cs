using System.Text;

namespace SwApiNet.Codegen;

public static class StaticVTableText
{
    public static GeneratedResult GenerateContent(DataToGenerate data)
    {
        if (!data.InterfaceName.StartsWith("I"))
        {
            throw new InvalidOperationException($"""Interface name must start with "I" for proper code generation """);
        }

        if (!data.InterfaceName.EndsWith("VTable"))
        {
            throw new InvalidOperationException($"""Interface name must end with "VTable" for proper code generation """);
        }

        var functionsWithoutFirstArg = data.Functions
            .Where(x => x.IsMethod)
            .Where(x => !x.Args.Any())
            .Select(x => $"{x.Name}()")
            .ToList();
        if(functionsWithoutFirstArg.Any())
        {
            throw new InvalidOperationException($"""Every function must have first argument of type "{data.ParentType}", it will be generated automatically. Functions with no arguments: {string.Join(", ", functionsWithoutFirstArg)}""");
        }

        var requiredType = $"{data.ParentType}*";
        var functionsWithBadFirstArgs = data.Functions
            .Where(x => x.IsMethod)
            .Where(x => x.Args.FirstOrDefault().Type.Split('.').Last() != requiredType)
            .Select(x => $"{x.Name}({x.Args.FirstOrDefault().Type})")
            .ToList();
        if(functionsWithBadFirstArgs.Any())
        {
            throw new InvalidOperationException($"""Every function must have first argument of type "{requiredType}", it will be generated automatically. Functions with invalid first arguments: {string.Join(", ", functionsWithBadFirstArgs)}""");
        }

        var interopInit = new StringBuilder();
        foreach (var x in data.Functions)
        {
            if (x.IsMethod)
            {
                interopInit.AppendLine($"            Interop.{x.Name}Real = real->{x.Name}Ptr;");
            }
            else
            {
                if (x.Unused)
                {
                }
                else
                {
                    interopInit.AppendLine($"            Interop.{x.Name}Real = real->{x.Name}Val;");
                    interopInit.AppendLine($"            Interop.{x.Name}Fake = real->{x.Name}Val;");
                }

            }
        }

        var structPointersInit = new StringBuilder();
        foreach (var x in data.Functions)
        {
            if (x.IsMethod)
            {
                structPointersInit.AppendLine($"            this.{x.Name}Ptr = Interop.{x.Name}Fake;");
            }
            else
            {
                if (x.Unused)
                {
                    // init with 0 or whatever
                    structPointersInit.AppendLine($"            this.{x.Name}Val = default;");
                }
                else
                {
                    // no way to use proxy chain for field containint a value
                    structPointersInit.AppendLine($"            this.{x.Name}Val = real->{x.Name};");
                }

            }
        }

        var structFields = new StringBuilder();
        foreach (var x in data.Functions)
        {
            if (x.IsMethod)
            {
                structFields.AppendLine($"        public delegate* unmanaged[Thiscall]<{x.ArgsGeneric.Value}> {x.Name}Ptr;");
            }
            else
            {
                structFields.AppendLine($"        public {x.ReturnType} {x.Name}Val;");
            }
        }

        var structMethods = new StringBuilder();
        foreach (var x in data.Functions)
        {
            if (x.IsMethod)
            {
                structMethods.AppendLine($"        public {x.ReturnType} {x.Name}({x.ArgsDefinition.Value}) => Interop.Target.{x.Name}({x.ArgsList.Value});");
            }
            else
            {
                structMethods.AppendLine($"        public {x.ReturnType} {x.Name} => this.{x.Name}Val;");
            }
        }

        var logMethods = new StringBuilder();
        foreach (var x in data.Functions)
        {
            if (x.IsMethod)
            {
                var argsBag = string.Join(".", x.Args.Select(x => $"Add({x.Name})"));
                logMethods.AppendLine($"        public {x.ReturnType} {x.Name}({x.ArgsDefinition.Value}) => Tools.LogMethod(() => target.{x.Name}({x.ArgsList.Value}), ArgsBag.Init().{argsBag}, \"{data.ParentType}\");");
            }
            else
            {
                logMethods.AppendLine($"        public {x.ReturnType} {x.Name} => Tools.LogMethod(() => target.{x.Name}, ArgsBag.Empty, \"{data.ParentType}\");");
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
                if (x.Unused)
                {
                    passThroughMethods.AppendLine($"        public {x.ReturnType} {x.Name} => default;");
                }
                else
                {
                    passThroughMethods.AppendLine($"        public {x.ReturnType} {x.Name} => Interop.{x.Name}Real;");
                }
            }
        }

        var interceptMethods = new StringBuilder();
        foreach (var x in data.Functions)
        {
            if (x.IsMethod)
            {
                if (x.DeadBeef)
                {
                    interceptMethods.AppendLine($"        public {x.ReturnType} {x.Name}({x.ArgsDefinition.Value}) => target.{x.Name}({x.ArgsList.Value});");
                }
                else
                {
                    interceptMethods.AppendLine($"        public virtual {x.ReturnType} {x.Name}({x.ArgsDefinition.Value}) => target.{x.Name}({x.ArgsList.Value});");
                }
            }
            else
            {
                if (x.Unused)
                {
                    interceptMethods.AppendLine($"        public {x.ReturnType} {x.Name} => target.{x.Name};");
                }
                else
                {
                    interceptMethods.AppendLine($"        public virtual {x.ReturnType} {x.Name} => target.{x.Name};");
                }
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
                if (x.Unused)
                {
                }
                else
                {
                    interopReal.AppendLine($"        public static {x.ReturnType} {x.Name}Real {{ get; set; }}");
                }
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
                if (x.Unused)
                {
                }
                else
                {
                    interopReal.AppendLine($"        public static {x.ReturnType} {x.Name}Fake {{ get; set; }}");
                }
            }
        }

        var interopExports = new StringBuilder();
        foreach (var x in data.Functions)
        {
            if (x.IsMethod)
            {
                if (x.DeadBeef)
                {
                    // return stub value right away
                    interopExports.AppendLine($"        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvThiscall)])] public static {x.ReturnType} {x.Name}Export({x.ArgsDefinition}) => (nint)Tools.DeadBeef;");
                }
                else
                {
                    interopExports.AppendLine($"        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvThiscall)])] public static {x.ReturnType} {x.Name}Export({x.ArgsDefinition}) => Target.{x.Name}({x.ArgsList});");
                }
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
                                 // can't store directly in the struct, it will affect size
                                 Interop.Target = new InterceptWrapper(new LogWrapper(new PassThroughWrapper()));
                     
                                 // replace real pointers
                                 // fields will be equal to values of real struct
                                 // methods will point to fake exported delegates to call wrapper chain
                     {{interopInit}}
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
                         public partial class PassThroughWrapper() : {{data.InterfaceName}}
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
                             public static {{data.InterfaceName}} Target { get; set; } = null!;

                     {{interopReal}}
                     {{interopFake}}
                     {{interopExports}}
                         }
                     }
                     """;

        return data.Success(text);
    }
}