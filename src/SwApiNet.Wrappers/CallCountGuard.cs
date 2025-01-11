using System.Runtime.CompilerServices;

namespace SwApiNet.Wrappers;

public class CallCountGuard
{
    private readonly Dictionary<string, int> methodCalls = new();
    private static readonly object Locker = new();

    /// <summary>
    /// Throws if a method is called more than expected count
    /// </summary>
    public void Check(int limit, [CallerMemberName] string? method = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(method);
        lock (Locker)
        {
            var value = methodCalls.GetValueOrDefault(method, 0);
            value++;
            methodCalls[method] = value;

            if(value > limit)
            {
                throw new InvalidOperationException($"Method [{method}] was called more times than expected ({limit})");
            }
        }
    }
}