// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRenderer.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   Interface for Renderer classes
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PoppingBaloons.Interfaces
{
    using PoppingBaloons.Board;

    /// <summary>
    /// A class that holds the state of the gameboard.
    /// <list type="bullet">
    /// <item> 
    /// <description><see cref="ClearScreen"/></description> 
    /// </item>
    /// <item> 
    /// <description><see cref="RenderGameboard"/></description> 
    /// </item>
    /// <item> 
    /// <description><see cref="RenderMessage"/></description> 
    /// </item>
    /// </list> 
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// A void abstarct method that will be overriden by it's inheritors.
        /// </summary>
        void ClearScreen();

        /// <summary>
        /// A void abstarct method that will be overriden by it's inheritors.
        /// </summary>
        /// <param name="gameboard">The instance of Gameboard the method uses.</param>
        void RenderGameboard(Gameboard gameboard);

        /// <summary>
        /// A void abstarct method that will be overriden by it's inheritors.
        /// </summary>
        /// <param name="score">The string the method is called upon.</param>
        void RenderMessage(string score);
    }
}