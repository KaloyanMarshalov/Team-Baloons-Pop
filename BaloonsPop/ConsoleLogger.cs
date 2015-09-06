namespace PoppingBaloons
{
    using System;
    using PoppingBaloons.Interfaces;

    public sealed class ConsoleLogger : ILogger
    {
        private static volatile ConsoleLogger loggerInstance;
        private static object syncLock = new object();

        private ConsoleLogger()
        {
        }

        public static ConsoleLogger LoggerInstance
        {
            get
            {
                if (loggerInstance == null)
                {
                    lock (syncLock)
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
