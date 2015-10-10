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
                case BaloonColor.Green:
                    return new Balloon("green");
                case BaloonColor.Red:
                    return new Balloon("red");
                case BaloonColor.Yellow:
                    return new Balloon("yellow");                 
                default:
                    throw new ArgumentException();
            }

        }
    }
}
