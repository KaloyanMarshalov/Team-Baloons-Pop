// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewGame.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   A class that initiates a new game.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PoppingBaloons.Menu
{
    using System;
    using System.Linq;
    using PoppingBaloons.Renderers;

    /// <summary>
    /// A class that implements the logic of starting the game.
    /// <list type="bullet">
    /// <item> 
    /// <description><see cref="StartNewGame"/></description> 
    /// </item>
    /// </list> 
    /// </summary>
    public class NewGame
    {
        /// <summary>
        /// The main method makes a new instance of the <see cref="Renderers.ConsoleRenderer"/>. And a new
        /// instance of the <see cref="Game"/> class.
        /// </summary>
        public static void StartNewGame()
        {
            const int BoardWidth = 5;
            const int BoardHeight = 10;
            
            ConsoleRenderer consoleRenderer = ConsoleRenderer.LoggerInstance;
            Game game = new Game(BoardHeight, BoardWidth, consoleRenderer);
            game.Start();
        }
    }
}
