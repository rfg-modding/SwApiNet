namespace SwApiNet.Codegen;

public readonly record struct DataToGenerate(string InterfaceName, string Namespace, RecordArray<Member> Functions, bool IsDynamic)
{
    private readonly string VTableName = $"{InterfaceName.Substring(1)}";
    public string ParentType => VTableName.Replace("VTable", "").Split('.').Last();
    public string FileName => $"{ParentType}.g";
    public string FullVTableName => $"{Namespace}.{ParentType}.VTable";


    public GeneratedResult Failure(string error) => new GeneratedResult(FileName, null, error);
    public GeneratedResult Success(string text) => new GeneratedResult(FileName, text, null);
}
