namespace SwApiNet.Codegen;

public readonly record struct Member(string Name, RecordArray<Arg> Args, string ReturnType, bool IsMethod, bool Unused, bool DeadBeef)
{
    public readonly Lazy<string> ArgsGeneric = new(() => string.Join(", ", Args.Select(x => x.Type).Append(ReturnType)));

    public readonly Lazy<string> ArgsDefinition = new(() => string.Join(", ", Args));

    public readonly Lazy<string> ArgsList = new(() => string.Join(", ", Args.Select(x => x.Name)));
}
