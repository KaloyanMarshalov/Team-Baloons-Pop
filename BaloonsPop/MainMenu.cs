namespace PoppingBaloons
{
    using System;
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
            Console.ForegroundColor = ConsoleColor.Cyan;
            ILogger logger = ConsoleLogger.LoggerInstance;
            logger.Log(" ____  _____  _     _     _____  _____  _     _     _____  _____  _____  _____ ");
            logger.Log("| _  ||  _  || |   | |   |  _  ||  _  ||  \\  | |   |  _  ||  _  ||  _  ||  ___| ");
            logger.Log("|   / | |_| || |   | |   | | | || | | || |\\ \\| |   | |_| || | | || |_| || |___ ");
            logger.Log("| _ \\ |  _  || |__ | |__ | |_| || |_| || |  \\  |   |  _ _|| |_| ||  _ _| ___  |");
            logger.Log("|____||_| |_||____||____||_____||_____||_|   |_|   |_|    |_____||_|    |_____|  ");
            logger.Log(string.Empty);
            logger.Log("                        Welcome to “Balloons Pops” game :)");
            logger.Log(string.Empty);
            logger.Log("                         Please try to pop the balloons!");
            logger.Log(string.Empty);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("___________________________________________________________________________________");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                   > Start Game <");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                     Quit Game");

            ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                // Start Game
                Console.Clear();
                logger.Log("List of Commands");
                logger.Log("---------------------------------------");
                logger.Log("* Use 'top' to view the top scoreboard!");
                logger.Log("* Use 'restart' to start a new game!");
                logger.Log("* Use 'exit' to quit the game!");
                logger.Log(string.Empty);

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
                    logger.Log(" ____  _____  _     _     _____  _____  _     _     _____  _____  _____  _____ ");
                    logger.Log("| _  ||  _  || |   | |   |  _  ||  _  ||  \\  | |   |  _  ||  _  ||  _  ||  ___| ");
                    logger.Log("|   / | |_| || |   | |   | | | || | | || |\\ \\| |   | |_| || | | || |_| || |___ ");
                    logger.Log("| _ \\ |  _  || |__ | |__ | |_| || |_| || |  \\  |   |  _ _|| |_| ||  _ _| ___  |");
                    logger.Log("|____||_| |_||____||____||_____||_____||_|   |_|   |_|    |_____||_|    |_____|  ");
                    logger.Log(string.Empty);
                    logger.Log("                        Welcome to “Balloons Pops” game :)");
                    logger.Log(string.Empty);
                    logger.Log("                         Please try to pop the balloons!");
                    logger.Log(string.Empty);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("___________________________________________________________________________________");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("                                     Start Game ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                   > Quit Game <");
                                               
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
                            return StartMenu(); // Recursion :)
                        }
                    }
                }
            }

            return 2;
        }
    }
}