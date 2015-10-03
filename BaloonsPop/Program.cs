namespace PoppingBaloons
{
    using System;
    using System.Linq;
    using PoppingBaloons.Interfaces;

    public class Program
    {
        public static void Main()
        {
            ILogger logger = ConsoleLogger.LoggerInstance;

            logger.Log("Welcome to “Balloons Pops” game. Please try to pop the balloons.");
            logger.Log("Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");

            Game game = new Game(logger);

            while (true)
            {
                game.ParseCommand(Console.ReadLine());
            }
        }
    }
}