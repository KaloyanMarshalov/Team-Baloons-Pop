namespace PoppingBaloons
{
    using System;
    using System.Linq;
    using PoppingBaloons.Interfaces;

    class Program
    {
        static void Main()
        {
            ILogger logger = new ConsoleLogger();

            logger.Log("Welcome to “Balloons Pops” game. Please try to pop the balloons.");
            logger.Log(" Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");

            Game game = new Game();

            while(true)
            {
                game.ParseCommand(Console.ReadLine());
            }
        }
    }
}