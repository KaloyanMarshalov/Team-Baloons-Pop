// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EndGame.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   A class that implements the logic of ending the game.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PoppingBaloons.Menu
{
    using System;
    using System.Linq;

    /// <summary>
    /// A class that implements the logic of ending the game.
    /// <list type="bullet">
    /// <item> 
    /// <description><see cref="QuitGame"/></description> 
    /// </item>
    /// </list> 
    /// </summary>
    public class EndGame
    {
        private const string StartGameMarked = "> START GAME <\n";
        private const string StartGameUnMarked = "  START GAME\n";
        private const string QuitGameMarked = "> QUIT GAME <";
        private const string QuitGameUnMarked = "  QUIT GAME";

        /// <summary>
        /// A method used for ending the game.
        /// </summary>
        public static void QuitGame()
        {
            Console.Clear();
            MainMenu.PrintMenu(StartGameUnMarked, QuitGameMarked);
            var keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                // Quit Game
                Console.WriteLine("Thanks for playing!!!");
                Environment.Exit(0);
            }
            else
            {
                if (keyInfo.Key == ConsoleKey.UpArrow || keyInfo.Key == ConsoleKey.DownArrow)
                {
                    Console.Clear();
                    MainMenu.PrintMenu(StartGameMarked, QuitGameUnMarked);

                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        GameMenu.StartGame();
                    }
                }
            }
        }
    }
}
