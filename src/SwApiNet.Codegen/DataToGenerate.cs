namespace SwApiNet.Codegen;

public readonly record struct DataToGenerate(string InterfaceName, string Namespace, RecordArray<Member> Functions)
{
    public readonly string StructName = $"{InterfaceName.Substring(1)}";

}
