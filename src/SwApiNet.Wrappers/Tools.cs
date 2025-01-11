using System.Collections;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Text;
using SwApiNet.Wrappers.Dll;
using SwApiNet.Wrappers.Models;

namespace SwApiNet.Wrappers;

public static class Tools
{
    public static void Log(string text, [CallerMemberName] string? method = null)
    {
        lock (Locker)
        {
            var message = $"{method ?? "null"} {text}";
            var time = TimeOnly.FromDateTime(DateTime.UtcNow).ToString("O");
            var fullLogMessage = $"DOTNET {time} {message}";
            Console.WriteLine(fullLogMessage);
        }
    }

    public static T LogMethod<T>(Func<T> action, ArgsBag args, bool exceptionsOnly=false, [CallerMemberName] string? method = null)
    {
        try
        {
            if (!exceptionsOnly)
            {
                lock (Locker)
                {
                    var message = $"{method ?? "null"}   args = {args}";
                    var time = TimeOnly.FromDateTime(DateTime.UtcNow).ToString("O");
                    var fullLogMessage = $"DOTNET {time} {message}";
                    Console.WriteLine(fullLogMessage);
                }
            }

            var result = action();
            if (!exceptionsOnly)
            {
                lock (Locker)
                {
                    var resultText = Serialize(result);
                    var message = $"{method ?? "null"} return = {resultText}";
                    var time = TimeOnly.FromDateTime(DateTime.UtcNow).ToString("O");
                    var fullLogMessage = $"DOTNET {time} {message}";
                    Console.WriteLine(fullLogMessage);
                }
            }

            return result;
        }
        catch (Exception e)
        {
            lock (Locker)
            {
                var message = $"{method ?? "null"} {e}";
                var time = TimeOnly.FromDateTime(DateTime.UtcNow).ToString("O");
                var fullLogMessage = $"DOTNET {time} {message}";
                Console.WriteLine(fullLogMessage);
            }

            throw;
        }

    }

    public static void LogMethod(Action action, ArgsBag args, bool exceptionsOnly=false, [CallerMemberName] string? method = null)
    {
        LogMethod(Func, args, exceptionsOnly, method);
        return;

        Type Func()
        {
            action();
            return typeof(void); // not a value, just a type, but works anyway
        }
    }

    public static string Serialize(object? o)
    {
        if (o is null)
        {
            return $"(null)";
        }
#pragma warning disable CS0252, CS0253
        if (o == typeof(void))
#pragma warning restore CS0252, CS0253
        {
            return $"(void)";
        }
        if (o is nint n)
        {
            return $"0x{n:X8}";
        }

        return $"{o}";
    }

    public static unsafe void LogPointer(string label, nint address, [CallerMemberName] string? method = null)
    {
        lock (Locker)
        {
            var value = *(nint*)address;
            var message = $"{method ?? "null"} {label} [{address:X8}] = {value:X8}";
            var time = TimeOnly.FromDateTime(DateTime.UtcNow).ToString("O");
            var fullLogMessage = $"DOTNET {time} {message}";
            Console.WriteLine(fullLogMessage);
        }
    }

    public static unsafe void LogMemory(string label, nint address, int length, [CallerMemberName] string? method = null)
    {
        lock (Locker)
        {
            var sb = new StringBuilder($"{method ?? "null"} {label} [{address:X8}] =");
            // reading 1 byte at a time
            for (int i = 0; i < length; i++)
            {
                var value = *(byte*)(address+i);
                sb.Append($" {value:X2}");
            }

            var time = TimeOnly.FromDateTime(DateTime.UtcNow).ToString("O");
            var fullLogMessage = $"DOTNET {time} {sb}";
            Console.WriteLine(fullLogMessage);
        }
    }

    private static readonly object Locker = new();

    private static string lastMessage = string.Empty;
}

/*

// can memcpy whole vtable to patch only relevant parts
Buffer.MemoryCopy(steamClientDll->Vtable, fakeVTable, sizeof(SteamClient.VTable), sizeof(SteamClient.VTable));
Marshal.FreeHGlobal((IntPtr)everythingAllocated); normally every AllocHGlobal requires freeing memory

// demo how to read C string
var ptr = new nint(cStringPtr);
var str = Marshal.PtrToStringAnsi(ptr);
Utils.Log($"Received string argument: {str}");

*/
