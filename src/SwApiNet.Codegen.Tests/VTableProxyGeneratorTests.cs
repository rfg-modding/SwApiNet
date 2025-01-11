using System.Runtime.CompilerServices;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace SwApiNet.Codegen.Tests;

public class VTableProxyGeneratorTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test()
    {
        var src = @"""
using SwApiNet.Codegen;

namespace Test;

[VTableProxy]
public unsafe interface ISteamClientVTable
{
    nint GetISteamApps(void* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr);
    void TestNoReturn(void* thisPtr, HSteamUser user, HSteamPipe pipe, byte* versionStr);
}

public enum HSteamUser;
public enum HSteamPipe;



                  """;
        var generator = new VTableProxyGenerator();

        var compilation = CSharpCompilation.Create("CSharpCodeGen.GenerateAssembly")
            .AddSyntaxTrees(CSharpSyntaxTree.ParseText(src))
            .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
            .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        var driver = CSharpGeneratorDriver.Create(generator)
            .RunGeneratorsAndUpdateCompilation(compilation, out var comp2, out var _);

        var result = driver.GetRunResult();


        var text = result.GeneratedTrees.Select(x => x.GetText().ToString());
        Assert.Fail(string.Join("\n\n============\n\n", text));
    }
}
