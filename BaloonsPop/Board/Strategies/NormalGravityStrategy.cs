using System;

namespace PoppingBaloons.Board.Strategies
{
    using System.Collections.Generic;

    class NormalGravityStrategy : GravityStrategy
    {
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