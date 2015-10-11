// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Entry.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   The main class used to execute the whole code.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace PoppingBaloons
{
    using Renderers;

    /// <summary>
    /// The main class used to execute the whole code.
    /// <list type="bullet">
    /// <item> 
    /// <description><see cref="Main"/></description> 
    /// </item>
    /// </list> 
    /// </summary>
    public class Entry
    {
        /// <summary>
        /// The main method makes a new instance of the <see cref="Renderers.ConsoleRenderer"/>. And a new
        /// instance of the <see cref="Game"/> class.
        /// </summary>
        public static void Main()
        {
            ConsoleRenderer consoleRenderer = ConsoleRenderer.LoggerInstance;
            Game game = new Game(10, 5, consoleRenderer);
            game.Start();
        }
    }
}