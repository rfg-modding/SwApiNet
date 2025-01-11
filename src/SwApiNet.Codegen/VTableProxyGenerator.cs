using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
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
            namespace SwApiNet.Codegen
            {
                public class VTableProxyAttribute: System.Attribute {} 
            }";
            i.AddSource("VTableProxyAttribute.g.cs", attributeSource);
        });

        // does not work in tests:
        //var provider = context.SyntaxProvider.ForAttributeWithMetadataName("SwApiNet.Codegen.VTableProxyAttribute", IsInterface, CollectData);
        var provider = context.SyntaxProvider.CreateSyntaxProvider(IsInterface, CollectData);
        context.RegisterSourceOutput(provider, Output);

        return;

        // define the execution pipeline here via a series of transformations:

        // find all additional files that end with .txt
        var textFiles = context.AdditionalTextsProvider.Where(static file => file.Path.EndsWith(".txt"));

        // read their contents and save their name
        IncrementalValuesProvider<(string name, string content)> namesAndContents = textFiles.Select((text, cancellationToken) => (name: Path.GetFileNameWithoutExtension(text.Path), content: text.GetText(cancellationToken)!.ToString()));

        // generate a class that contains their values as const strings
        context.RegisterSourceOutput(namesAndContents, (spc, nameAndContent) =>
        {
            spc.AddSource($"ConstStrings.{nameAndContent.name}", $@"
    public static partial class ConstStrings
    {{
        public const string {nameAndContent.name} = ""{nameAndContent.content}"";
    }}");
        });
    }

    private void Output(SourceProductionContext context, DataToGenerate? data)
    {
        if (data is null)
        {
            return;
        }
        context.AddSource(data.Name, JsonSerializer.Serialize(data, new JsonSerializerOptions(){WriteIndented = true}));
    }

    private bool IsInterface(SyntaxNode node, CancellationToken token)
    {
        return node is InterfaceDeclarationSyntax;
    }

    private DataToGenerate? CollectData(GeneratorSyntaxContext context, CancellationToken token)
    {
        var declaredSymbol = context.SemanticModel.GetDeclaredSymbol(context.Node);
        if (declaredSymbol is null)
        {
            return null;
        }
        if (declaredSymbol is not INamedTypeSymbol symbol)
        {
            return null;
        }

        if (!declaredSymbol.GetAttributes().Any(x => x.AttributeClass?.Name == "VTableProxy"))
        {
            return null;
        }


        var data = new DataToGenerate(symbol.Name, symbol.ContainingNamespace.ToString(), []);
        var symbolMembers = symbol.GetMembers();
        foreach (var x in symbolMembers)
        {
            if (x is IMethodSymbol method)
            {
                var args = new List<Arg>();
                foreach (var methodParameter in method.Parameters)
                {
                    var type = methodParameter.Type.ToString();
                    var name = methodParameter.Name;
                    args.Add(new Arg(type, name));
                }
                data.Functions.Add(new Function(x.Name, args, method.ReturnType.ToString()));
            }
        }

        return data;
    }

    private DataToGenerate? CollectData(GeneratorAttributeSyntaxContext context, CancellationToken token)
    {
        if (context.TargetSymbol is not INamedTypeSymbol symbol)
        {
            throw new InvalidOperationException($"Can't perform codegen on: {context.TargetSymbol}");
        }

        throw null;
        var fullName = symbol.ToString();
        var symbolMembers = symbol.GetMembers();
        var members = new List<string>(symbolMembers.Length);
        foreach (var x in symbolMembers)
        {
            if (x is IMethodSymbol method)
            {
                members.Add(x.Name);
            }
        }

        // Create an EnumToGenerate for use in the generation phase
        //enumsToGenerate.Add(new EnumToGenerate(enumName, members));

        foreach (var member in symbolMembers)
        {
            if (member is IFieldSymbol field && field.ConstantValue is not null)
            {
                members.Add(member.Name);
            }
        }

        throw null;
    }
}



public record Arg(string Type, string Name);

public record Function(string Name, List<Arg> Args, string Return);

public record DataToGenerate(string Name, string Namespace, List<Function> Functions);
