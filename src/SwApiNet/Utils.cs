using System;
using System.Runtime.CompilerServices;

namespace SwApiNet;

public static class Utils
{
    public static void LogMethodBuffered([CallerMemberName] string method = null)
    {
        lock (Locker)
        {
            var message = $"{method ?? "null"}";
            if (message == lastMessage)
            {
                counter++;
                return;
            }

            if (counter > 0)
            {
                Console.WriteLine($"Previous message repeated {counter} times");
                counter = 0;
                lastMessage = string.Empty;
            }

            var time = TimeOnly.FromDateTime(DateTime.UtcNow).ToString("O");
            var fullLogMessage = $"{time} {message}";
            Console.WriteLine(fullLogMessage);
            lastMessage = message;
        }
    }

    public static void Log(string text, [CallerMemberName] string method = null)
    {
        lock (Locker)
        {
            var message = $"{method ?? "null"} {text}";
            var time = TimeOnly.FromDateTime(DateTime.UtcNow).ToString("O");
            var fullLogMessage = $"{time} {message}";
            Console.WriteLine(fullLogMessage);
        }
    }

    public static T TryCatchLog<T>(Func<T> action, [CallerMemberName] string method = null)
    {
        try
        {
            return action();
        }
        catch (Exception e)
        {
            lock (Locker)
            {
                var message = $"{method ?? "null"} {e}";
                var time = TimeOnly.FromDateTime(DateTime.UtcNow).ToString("O");
                var fullLogMessage = $"{time} {message}";
                Console.WriteLine(fullLogMessage);
            }

            throw;
        }

    }

    public static void TryCatchLog(Action action, [CallerMemberName] string method = null)
    {
        try
        {
            action();
        }
        catch (Exception e)
        {
            lock (Locker)
            {
                var message = $"{method ?? "null"} {e}";
                var time = TimeOnly.FromDateTime(DateTime.UtcNow).ToString("O");
                var fullLogMessage = $"{time} {message}";
                Console.WriteLine(fullLogMessage);
            }

            throw;
        }

    }

    private static readonly object Locker = new();

    private static string lastMessage = string.Empty;
    private static int counter;
}
