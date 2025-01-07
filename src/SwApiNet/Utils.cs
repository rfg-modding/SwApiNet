using System;
using System.Runtime.CompilerServices;

namespace SwApiNet;

public static class Utils
{
    public static void LogMethod([CallerMemberName] string method = null)
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

    private static string lastMessage = string.Empty;
    private static int counter;
    private static readonly object Locker = new();
}
