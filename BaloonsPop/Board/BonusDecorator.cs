namespace PoppingBaloons.Board
{
    class BonusDecorator: BoardComponentDecorator
    {
        private const int BonusValue = 5;

        public BonusDecorator(BoardComponent component)
            :base(component)
        { 
        }

        public override int GetValue()
        {
            return base.GetValue() + BonusValue;
        }
    }
}
