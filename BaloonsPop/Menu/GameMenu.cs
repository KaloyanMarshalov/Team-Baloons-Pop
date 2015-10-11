// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameMenu.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   A class that prints the game menu on console.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PoppingBaloons.Menu
{
    using System;
    using System.Linq;

    /// <summary>
    /// A class that implements the logic of starting the game.
    /// <list type="bullet">
    /// <item> 
    /// <description><see cref="StartGame"/></description> 
    /// </item>
    /// </list> 
    /// </summary>
    public class GameMenu
    {
        private const string StartGameMarked = "> START GAME <\n";
        private const string StartGameUnMarked = "  START GAME\n";
        private const string QuitGameMarked = "> QUIT GAME <";
        private const string QuitGameUnMarked = "  QUIT GAME";

        /// <summary>
        /// A method that checks for key stroke and depending on that starts or ends the game.
        /// </summary>
        /// <returns></returns>
        public static int StartGame()
        {
                Console.Clear();
                Menu.MainMenu.PrintMenu(StartGameMarked, QuitGameUnMarked);
                var keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    NewGame.StartNewGame();
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow || keyInfo.Key == ConsoleKey.UpArrow)
                {
                    EndGame.QuitGame();
                }

            return StartGame();
        }
    }
}
