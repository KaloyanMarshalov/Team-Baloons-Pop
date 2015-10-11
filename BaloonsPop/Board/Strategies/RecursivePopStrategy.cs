// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecursivePopStrategy.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   A class that checks how many baloons are not popped.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PoppingBaloons.Board.Strategies
{
    /// <summary>
    /// A class for setting positions of unpopped baloons on empty space below them.
    /// <list type="bullet">
    /// <item> 
    /// <description><see cref="PopBalloons"/></description> 
    /// </item>
    /// <item> 
    /// <description><see cref="ProcessCell"/></description> 
    /// </item>
    /// </list> 
    /// </summary>
    public class RecursivePopStrategy : PopStrategy
    {
        /// <summary>
        /// A method that adds the baloons that are the same as current.
        /// </summary>
        /// <param name="row">The row of the board as a prameter</param>
        /// <param name="col">The column of the board as a prameter</param>
        /// <param name="board">This method accepts a new instance of the Gameboard.</param>
        /// <returns>Returns the number of the baloons complying with the requirements.</returns>
        public override int PopBalloons(int row, int col, Gameboard board)
        {
            int result = 0;

            result += this.ProcessCell(row, col, board);
            return result;
        }

        /// <summary>
        /// A method that checks how many neighbouring baloons of the current have the same color and
        /// are not popped.
        /// </summary>
        /// <param name="row">The row of the board as a prameter</param>
        /// <param name="col">The column of the board as a prameter</param>
        /// <param name="board">This method accepts a new instance of the Gameboard.</param>
        /// <returns>Returns the number of the baloons complying with the requirements.</returns>
        private int ProcessCell(int row, int col, Gameboard board)
        {
            var currentCell = board.GetElement(row, col);
            var subresult = 0;
            
            currentCell.IsActive = false;

            if (row - 1 >= 0)
            {
                var upperCell = board.GetElement(row - 1, col);

                if (upperCell.Color == currentCell.Color && upperCell.IsActive)
                {                    
                    subresult += this.ProcessCell(row - 1, col, board);
                }
            }

            if (row + 1 < board.BoardHeight)
            {
                var lowerCell = board.GetElement(row + 1, col);

                if (lowerCell.Color == currentCell.Color && lowerCell.IsActive)
                {
                    subresult += this.ProcessCell(row + 1, col, board);
                }
            }

            if (col - 1 >= 0)
            {
                var leftCell = board.GetElement(row, col - 1);

                if (leftCell.Color == currentCell.Color && leftCell.IsActive)
                {
                    subresult += this.ProcessCell(row, col - 1, board);
                }
            }

            if (col + 1 < board.BoardWidth)
            {
                var rightCell = board.GetElement(row, col + 1);

                if (rightCell.Color == currentCell.Color && rightCell.IsActive)
                {
                    subresult += this.ProcessCell(row, col + 1, board);
                }
            }

            return currentCell.GetValue() + subresult;
        }
    }
}