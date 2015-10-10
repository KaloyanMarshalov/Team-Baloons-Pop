namespace PoppingBaloons.Board
{
    using System;       
    using System.Linq;     

    public class BalloonMaker
    {
        public Balloon MakeBalloon(BaloonColor colorOfBalloon) 
        {
            switch (colorOfBalloon)
            {
                case BaloonColor.Blue: 
                    return new Balloon("blue");
                case BaloonColor.Red:
                    return new Balloon("red");
                default:
                    throw new ArgumentException();
            }

        }
    }
}
