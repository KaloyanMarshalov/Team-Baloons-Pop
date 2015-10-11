// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PopStrategy.cs" company="Team-Baloon-Pop">
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
    /// <description><see cref="PopBalloons"/></description> 
    /// </item>
    /// </list> 
    /// </summary>
    public abstract class PopStrategy
    {
        /// <summary>
        /// A void abstarct method that will be overriden by it's inheritors.
        /// </summary>
        /// <param name="row">The row of the board as a prameter</param>
        /// <param name="col">The column of the board as a prameter</param>
        /// <param name="board">This method accepts a new instance of the Gameboard.</param>
        public abstract int PopBalloons(int row, int col, Gameboard board);
    }
}