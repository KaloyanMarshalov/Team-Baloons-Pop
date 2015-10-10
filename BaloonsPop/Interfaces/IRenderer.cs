// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ilogger.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   Interface used in the ConsoleLogger class
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PoppingBaloons.Interfaces
{
    using PoppingBaloons.Board;

    /// <summary>
    /// Sealed class used for logging various messages on the console:
    /// <list type="bullet">
    /// <item> 
    /// <description><see cref="Log"/></description> 
    /// </item>
    /// </list> 
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// A void method that later will be overriden.
        /// </summary>
        /// <param name="message">The string the method is called upon.</param>

        void RenderGameboard(Gameboard gameboard);
    }
}