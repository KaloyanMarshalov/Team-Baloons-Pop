namespace PoppingBaloons
{
    using System;
    using PoppingBaloons.Interfaces;

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
