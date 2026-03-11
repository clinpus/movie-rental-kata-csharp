using System;

namespace MovieRental
{
    public static class Logger
    {
        private const string LogFile = "errors.log";

        public static void LogError(string message)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [ERROR] : {message}";

            Console.WriteLine(logEntry);

        }
    }
}