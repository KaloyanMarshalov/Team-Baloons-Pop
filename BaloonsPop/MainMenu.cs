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
    using System.Collections.Generic;
    using System.Linq;
    using PoppingBaloons.Interfaces;
    
    /// <summary>
    /// The main class used to execute the whole code:
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

                ListOfCommands.PrintListOfCommands();  
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