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
    /// The main class used to execute the whole code:
    /// <list type="bullet">    
    public class Entry
    {
        /// <summary>
        /// The main method that invokes <see cref="StartMenu"/> method.
        /// </summary>
        public static void Main()
        {
            ConsoleRenderer consoleRenderer = ConsoleRenderer.LoggerInstance;
            Game game = new Game(10, 6, consoleRenderer);
            game.Start();
        }
    }
}