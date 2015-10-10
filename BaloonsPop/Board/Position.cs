namespace PoppingBaloons
{
    using System;
    using System.Linq;

    public class Position
    {
        private int row;
        private int col;

        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }
    }
}