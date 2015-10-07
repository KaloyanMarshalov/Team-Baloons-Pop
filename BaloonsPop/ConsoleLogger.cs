// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleLogger.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   A class that watches for a change in state of the baloons.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PoppingBaloons
{
    using System;
    using PoppingBaloons.Interfaces;

    /// <summary>
    /// Sealed class used for logging various messages on the console:
    /// <list type="bullet">
    /// <item> 
    /// <description><see cref="Log"/></description> 
    /// </item>
    /// </list> 
    /// </summary>
    public sealed class ConsoleLogger : ILogger
    {
        private static readonly object SyncLock = new object();
        private static volatile ConsoleLogger loggerInstance;

        private ConsoleLogger()
        {
        }

        /// <summary>
        /// A static method used for checking if an instance of this class is already
        /// available. Implementation of the Singleton Pattern.
        /// </summary>
        /// <returns>The method returns a new instance if none has been instantiated.</returns>
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

        /// <summary>
        /// A method that writes a message on the console.
        /// </summary>
        /// <param name="message">The string the method is called upon.</param>
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
