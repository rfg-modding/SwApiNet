using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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

        var provider = context.SyntaxProvider.ForAttributeWithMetadataName("SwApiNet.Codegen.VTableProxyAttribute", IsInterface, CollectData);
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
        context.AddSource(data.Name, "");
    }

    private bool IsInterface(SyntaxNode node, CancellationToken token)
    {
        return node is InterfaceDeclarationSyntax;
    }

    [SuppressMessage("MicrosoftCodeAnalysisCorrectness", "RS1035:Do not use APIs banned for analyzers")]
    private DataToGenerate? CollectData(GeneratorAttributeSyntaxContext context, CancellationToken token)
    {
        if (context.TargetSymbol is not INamedTypeSymbol symbol)
        {
            throw new InvalidOperationException($"Can't perform codegen on: {context.TargetSymbol}");
        }

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

        //Throw(symbolMembers);
        return null;

        // Create an EnumToGenerate for use in the generation phase
        //enumsToGenerate.Add(new EnumToGenerate(enumName, members));

        foreach (var member in symbolMembers)
        {
            if (member is IFieldSymbol field && field.ConstantValue is not null)
            {
                members.Add(member.Name);
            }
        }

        //return new EnumToGenerate(enumName, members);
    }

    private static void Throw(object data)
    {
        throw new DivideByZeroException(JsonSerializer.Serialize(data, Options));
    }
    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true,
        Converters = {new BadClassConverter()}
    };
}

public record Function(string Name, string Declaration);

public record DataToGenerate(string Name, IReadOnlyList<Function> Functions);

public class BadClassConverter: JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(Encoding);
    }


    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        return (JsonConverter) Activator.CreateInstance(typeof(BadClassConverterInner<>).MakeGenericType(typeToConvert), args: [options])!;
    }
}

public class BadClassConverterInner<T> : JsonConverter<T>
{
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStringValue($"ignored {typeof(T)}");
    }
}
