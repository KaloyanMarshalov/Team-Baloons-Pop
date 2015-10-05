namespace PoppingBaloons
{
    using System;
    using PoppingBaloons.Interfaces;

    public sealed class ConsoleLogger : ILogger
    {
        private static readonly object SyncLock = new object();
        private static volatile ConsoleLogger loggerInstance;

        private ConsoleLogger()
        {
        }

        public static ConsoleLogger LoggerInstance
        {
            get
            {
                if (loggerInstance == null)
                {
                    lock (SyncLock)
                    {
                        if (loggerInstance == null)
                        {
                            loggerInstance = new ConsoleLogger();
                        }
                    }
                }

                return loggerInstance;
            }
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
