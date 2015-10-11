namespace PoppingBaloons.Board.BalloonFactory
{
    public class Balloon : BoardComponent
    {
        private readonly int value = 2;         

        public Balloon(string color)
        {
            this.Color = color;
            this.IsActive = true;
        }   
                                                                                               
        public override int GetValue()
        {
            return this.value;
        }
    }
}