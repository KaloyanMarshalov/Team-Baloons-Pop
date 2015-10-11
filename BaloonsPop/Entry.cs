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
        /// The main method starts the game.
        /// </summary>
        public static void Main()
        {
            Menu.GameMenu.StartGame();
        }         
    }
}