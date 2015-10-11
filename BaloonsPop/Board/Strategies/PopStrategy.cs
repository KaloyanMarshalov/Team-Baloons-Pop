namespace PoppingBaloons.Board.Strategies
{
    public abstract class PopStrategy
    {
        public abstract int PopBalloons(int row, int col, Gameboard board);
    }
}