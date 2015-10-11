namespace PoppingBaloons.Board.PopStrategies
{
    public abstract class PopStrategy
    {
        public abstract int PopBalloons(int row, int col, Gameboard board);
    }
}