// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GravityStrategy.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   An abstract class for the startegy pattern.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PoppingBaloons.Board.Strategies
{
    /// <summary>
    /// An abstract class for the startegy pattern.
    /// <list type="bullet">
    /// <item> 
    /// <description><see cref="Apply"/></description> 
    /// </item>
    /// </list> 
    /// </summary>
    public abstract class GravityStrategy
    {
        /// <summary>
        /// A void abstarct method that will be overriden by it's inheritors.
        /// </summary>
        /// <param name="board">This method accepts a new instance of the Gameboard.</param>
        public abstract void Apply(Gameboard board);
    }
}