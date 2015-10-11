// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NormalGravityStrategy.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   A class for setting positions of unpopped baloons on empty space below them.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PoppingBaloons.Board.Strategies
{
    using System.Collections.Generic;
    using PoppingBaloons.Board.BalloonFactory;

    /// <summary>
    /// A class for setting positions of unpopped baloons on empty space below them.
    /// <list type="bullet">
    /// <item> 
    /// <description><see cref="Apply"/></description> 
    /// </item>
    /// </list> 
    /// </summary>
    public class NormalGravityStrategy : GravityStrategy
    {
        /// <summary>
        /// A class that checks for unpopped baloons and adds then to a stack.
        /// If there are unpopped baloons their positions are reset. If all baloons are 
        /// popped, red baloons are created in the emprty space.
        /// </summary>
        /// <param name="board">This method accepts a new instance of the Gameboard.</param>
        public override void Apply(Gameboard board)
        {
            for (int col = 0; col < board.BoardWidth; col++)
            {
                Stack<BoardComponent> columnContents = new Stack<BoardComponent>();

                for (int row = 0; row < board.BoardHeight; row++)
                {
                    var currentComponent = board.GetElement(row, col);

                    if (currentComponent.IsActive)
                    {
                        columnContents.Push(currentComponent);
                    }
                }

                for (int row = board.BoardHeight - 1; row >= 0; row--)
                {
                    if (columnContents.Count > 0)
                    {
                        board.SetElement(row, col, columnContents.Pop());
                    }
                    else
                    {
                        BalloonMaker balloonMaker = new BalloonMaker();
                        BoardComponent poppedBalloon = balloonMaker.MakeBalloon(BaloonColor.Red);
                        poppedBalloon.IsActive = false;

                        board.SetElement(row, col, poppedBalloon);
                    }
                }
            }
        }
    }
}