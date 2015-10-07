// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainMenu.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   The main class used to execute the whole code.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PoppingBaloons
{
    using System;
    using System.Linq;
    using PoppingBaloons.Interfaces;

    /// <summary>
    /// Sealed class used for logging various messages on the console:
    /// <list type="bullet">
    /// <item> 
    /// <description><see cref="Main"/></description> 
    /// </item>
    /// <item> 
    /// <description><see cref="StartMenu"/></description> 
    /// </item>
    /// </list> 
    /// </summary>
    
    public class MainMenu
    {
        /// <summary>
        /// The main method that invokes <see cref="StartMenu"/> method.
        /// </summary>
        public static void Main()
        {                
            StartMenu();
        }

        /// <summary>
        /// A method used for drawing a welcome message on the console. It waits for user
        /// input for starting or quiting the game.
        /// </summary>
        /// <returns>Returns 2.</returns>
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