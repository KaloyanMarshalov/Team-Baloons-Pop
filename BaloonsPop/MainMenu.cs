namespace PoppingBaloons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PoppingBaloons.Interfaces;

    public class MainMenu
    {
        public static void Main()
        {
            StartMenu();
        }

        public static int StartMenu() // 1 - Start Game , 2 - Quit Game
        {
            string logo = "     ____  _____  _     _     _____  _____  _     _     _____  _____  _____  _____\n " +
                          "   | _  ||  _  || |   | |   |  _  ||  _  ||  \\  | |   |  _  ||  _  ||  _  ||  ___|\n " +
                          "   |   / | |_| || |   | |   | | | || | | || |\\ \\| |   | |_| || | | || |_| || |___ \n" +
                         "    | _ \\ |  _  || |__ | |__ | |_| || |_| || |  \\  |   |  _ _|| |_| ||  _ _| ___  |\n" +
                         "    |____||_| |_||____||____||_____||_____||_|   |_|   |_|    |_____||_|    |_____|  \n\n" +
                         "                           Welcome to “Balloons Pops” game :)\n\n" +
                         "                            Please try to pop the balloons!\n" +
                         "__________________________________________________________________________________________\n";

            ILogger logger = ConsoleLogger.LoggerInstance;
            Console.ForegroundColor = ConsoleColor.Cyan;
            logger.Log(logo);
            Console.ForegroundColor = ConsoleColor.Red;
            logger.Log("                                   > START GAME <\n");
            Console.ForegroundColor = ConsoleColor.White;
            logger.Log("                                     QUIT GAME");
            ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                // Start Game
                Console.Clear();

                var listOfCommands = new List<string>();

                listOfCommands.Add("List of Commands");
                listOfCommands.Add("---------------------------------------");
                listOfCommands.Add("* Use 'top' to view the top scoreboard!");
                listOfCommands.Add("* Use 'restart' to start a new game!");
                listOfCommands.Add("* Use 'exit' to quit the game!\n");

                foreach (var item in listOfCommands)
                {
                    logger.Log(item);
                }

                Game game = new Game(logger);

                while (true)
                {
                    game.ParseCommand(Console.ReadLine());
                }
            }
            else
            {
                if (keyInfo.Key == ConsoleKey.DownArrow || keyInfo.Key == ConsoleKey.UpArrow)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    logger.Log(logo);
                    Console.ForegroundColor = ConsoleColor.White;
                    logger.Log("                                     START GAME\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    logger.Log("                                   > QUIT GAME <");

                    if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                    {
                        // Quit Game
                        logger.Log("Thanks for playing!!!");
                        Environment.Exit(0);
                    }
                    else
                    {
                        if (Console.ReadKey(true).Key == ConsoleKey.UpArrow || Console.ReadKey(true).Key == ConsoleKey.DownArrow)
                        {
                            Console.Clear();
                        }
                    }
                }
            }

            return StartMenu();
        }
    }
}