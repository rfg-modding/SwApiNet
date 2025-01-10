using System.Collections;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

namespace SwApiNet.Wrappers;

public class ArgsBag
{
    private readonly OrderedDictionary dictionary = new();

    public static ArgsBag Init() => new ArgsBag();

    public static ArgsBag Init(object a, [CallerArgumentExpression(nameof(a))] string? aName=null)
    {
        return new ArgsBag().AddInternal(a, aName);
    }

    public static ArgsBag Init(object a, object b, [CallerArgumentExpression(nameof(a))] string? aName=null, [CallerArgumentExpression(nameof(b))] string? bName=null)
    {
        return new ArgsBag(). AddInternal(a, aName).AddInternal(b, bName);
    }

    public static ArgsBag Init(object a, object b, object c, [CallerArgumentExpression(nameof(a))] string? aName=null, [CallerArgumentExpression(nameof(b))] string? bName=null, [CallerArgumentExpression(nameof(c))] string? cName=null)
    {
        return new ArgsBag(). AddInternal(a, aName).AddInternal(b, bName).AddInternal(c, cName);
    }

    public static ArgsBag Init(object a, object b, object c, object d, [CallerArgumentExpression(nameof(a))] string? aName=null, [CallerArgumentExpression(nameof(b))] string? bName=null, [CallerArgumentExpression(nameof(c))] string? cName=null, [CallerArgumentExpression(nameof(d))] string? dName=null)
    {
        return new ArgsBag(). AddInternal(a, aName).AddInternal(b, bName).AddInternal(c, cName).AddInternal(d, dName);
    }

    public unsafe ArgsBag Add(void* a, [CallerArgumentExpression(nameof(a))] string? aName = null)
    {
        return Add((nint) a, aName);
    }

    public ArgsBag Add(object a, [CallerArgumentExpression(nameof(a))] string? aName=null)
    {
        return AddInternal(a, aName);
    }

    public ArgsBag Add(object a, object b, [CallerArgumentExpression(nameof(a))] string? aName=null, [CallerArgumentExpression(nameof(a))] string? bName=null)
    {
        return AddInternal(a, aName).AddInternal(b, bName);
    }

    public ArgsBag Add(object a, object b, object c, [CallerArgumentExpression(nameof(a))] string? aName=null, [CallerArgumentExpression(nameof(b))] string? bName=null, [CallerArgumentExpression(nameof(c))] string? cName=null)
    {
        return AddInternal(a, aName).AddInternal(b, bName).AddInternal(c, cName);
    }

    public ArgsBag Add(object a, object b, object c, object d, [CallerArgumentExpression(nameof(a))] string? aName=null, [CallerArgumentExpression(nameof(b))] string? bName=null, [CallerArgumentExpression(nameof(c))] string? cName=null, [CallerArgumentExpression(nameof(d))] string? dName=null)
    {
        return AddInternal(a, aName).AddInternal(b, bName).AddInternal(c, cName).AddInternal(d, dName);
    }

    public override string ToString()
    {
        if (dictionary.Count == 0)
        {
            return "(none)";
        }

        var result = string.Join(", ", dictionary.OfType<DictionaryEntry>().Select(x => $"{x.Key} = {Tools.Serialize(x.Value)}"));
        return $"({result})";
    }

    private ArgsBag AddInternal(object value, string? name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        dictionary.Add(name, Tools.Serialize(value));
        return this;
    }

    public static readonly ArgsBag Empty = new();
}
