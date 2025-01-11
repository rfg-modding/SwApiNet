namespace SwApiNet.Codegen;

public readonly record struct Arg(string Type, string Name)
{
    public override string ToString()
    {
        return $"{Type} {Name}";
    }
}