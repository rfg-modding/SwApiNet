using System.Collections;

namespace SwApiNet.Codegen;

public class RecordArray<T>(IEnumerable<T>? data = null)
    : IReadOnlyList<T>, IEquatable<RecordArray<T>>
    where T : IEquatable<T>
{
    private readonly T[] data = data?.ToArray() ?? [];

    #region IReadOnlyList

    public IEnumerator<T> GetEnumerator()
    {
        return data.AsEnumerable().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Count => data.Length;

    public T this[int index] => data[index];
    #endregion

    #region Equality

    public override int GetHashCode()
    {
        return data.GetHashCode();
    }

    public bool Equals(RecordArray<T> other)
    {
        return data.SequenceEqual(other.data);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((RecordArray<T>) obj);
    }

    public static bool operator ==(RecordArray<T> left, RecordArray<T> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(RecordArray<T> left, RecordArray<T> right)
    {
        return !(left == right);
    }

    #endregion
}
