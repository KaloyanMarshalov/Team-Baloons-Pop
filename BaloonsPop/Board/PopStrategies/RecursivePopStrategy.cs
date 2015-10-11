namespace PoppingBaloons.Board.PopStrategies
{
    using System;

    public class RecursivePopStrategy : PopStrategy
    {
        public override int PopBalloons(int row, int col, Gameboard board)
        {
            Console.WriteLine("check" + row + " " + col);
            int result = 0;

            result += ProcessCell(row, col, board);
            Console.WriteLine(result);
            return result;
        }

        private int ProcessCell(int row, int col, Gameboard board)
        {
            Console.WriteLine("Processing r{0}c{1}", row, col);
            var currentCell = board.GetElement(row, col);
            var subresult = 0;
            
            currentCell.IsActive = false;

            if (row - 1 >= 0)
            {
                var upperCell = board.GetElement(row - 1, col);

                if (upperCell.Color == currentCell.Color && upperCell.IsActive)
                {                    
                    subresult += ProcessCell(row - 1, col, board);
                }
            }

            if (row + 1 < board.BoardHeight)
            {
                var lowerCell = board.GetElement(row + 1, col);

                if (lowerCell.Color == currentCell.Color && lowerCell.IsActive)
                {
                    subresult += ProcessCell(row + 1, col, board);
                }
            }

            if (col - 1 >= 0)
            {
                var leftCell = board.GetElement(row, col - 1);

                if (leftCell.Color == currentCell.Color && leftCell.IsActive)
                {
                    subresult += ProcessCell(row, col - 1, board);
                }
            }

            if (col + 1 < board.BoardWidth)
            {
                var rightCell = board.GetElement(row, col + 1);

                if (rightCell.Color == currentCell.Color && rightCell.IsActive)
                {
                    subresult += ProcessCell(row, col + 1, board);
                }
            }

            return currentCell.GetValue() + subresult;
        }
    }
}
