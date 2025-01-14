using System.Collections;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.CompilerServices;
using NLog;
using NLog.Extensions.Logging;
using NLog.Layouts;
using NLog.Targets;
using SwApiNet.Wrappers.Dll;
using SwApiNet.Wrappers.Models;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using LogLevel = NLog.LogLevel;

namespace SwApiNet.Wrappers;

public static class Tools
{
    public static readonly ILogger Log;
    private static readonly ILogger LogInternal;

    static Tools()
    {
        LogManager.Setup()
            .LoadConfiguration(c =>
            {
                var target = c.ForTarget("file")
                    .WriteTo(new FileTarget()
                    {
                        FileName = "SwApiLog.log",
                        Layout =new SimpleLayout("${date:format=HH\\:mm\\:ss.fffffff} ${level:uppercase=true}\t${callsite:when=logger=='SwApiNet.Wrappers.Tools.LogAll'}${literal:text=\t:when=logger=='SwApiNet.Wrappers.Tools.LogAll'}${message:withexception=true}"),
                        MaxArchiveFiles = 5,
                        ArchiveNumbering = ArchiveNumberingMode.Rolling,
                        ArchiveFileName = "SwApiLog.{#}.log",
                        ArchiveOldFileOnStartup = true
                    })
                    .WithAsync();
                c.ForLogger().FilterMinLevel(LogLevel.Trace).WriteTo(target);
            });
        var factory = new NLogLoggerFactory();
        Log = new Logger<LogAll>(factory);
        LogInternal = new Logger<LogForMethods>(factory);
        Log.LogInformation("Initialized");
    }

    private record LogAll;

    private record LogForMethods;

    // TODO: when return type is pointer, this method blocks from writing vtable signatures. fix somehow?
    public static T LogMethod<T>(Func<T> action, ArgsBag args, string origin, bool exceptionsOnly=false, [CallerMemberName] string? method = null)
    {
        var sb = new StringBuilder();
        sb.Append(origin).Append(".");
        sb.Append(method ?? "null");
        var caller = sb.ToString();
        try
        {
            if (!exceptionsOnly)
            {
                LogInternal.LogTrace($"{caller} args   = {args}");
            }

            var result = action();
            if (!exceptionsOnly)
            {
                var resultText = Serialize(result);
                LogInternal.LogTrace($"{caller} return = {resultText}");
            }

            return result;
        }
        catch (Exception e)
        {
            LogInternal.LogError(e, $"{caller} failed");
            throw;
        }

    }

    public static void LogMethod(Action action, ArgsBag args, string origin, bool exceptionsOnly=false, [CallerMemberName] string? method = null)
    {
        LogMethod(Func, args, origin, exceptionsOnly, method);
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

    public static unsafe string PointerToString(string label, nint address)
    {
            var value = *(nint*)address;
            return $"{label} [{address:X8}] = {value:X8}";
    }

    public static unsafe string MemoryToString(string label, nint address, int length)
    {
        var sb = new StringBuilder($"{label} [{address:X8}] =");
        // reading 1 byte at a time
        for (int i = 0; i < length; i++)
        {
            var value = *(byte*)(address+i);
            sb.Append($" {value:X2}");
        }

        return sb.ToString();
    }

    public static readonly nuint DeadBeef = 0xDEADBEEF;
    public static readonly int CFalse = 1;
    public static readonly int CTrue = 0;

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
