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
<<<<<<< HEAD
                case BaloonColor.Green:
                    return new Balloon("green");
                case BaloonColor.Red:
                    return new Balloon("red");
                case BaloonColor.Yellow:
                    return new Balloon("yellow");
=======
                case BaloonColor.Red:
                    return new Balloon("red");
>>>>>>> 94669612c515b656c8353de09ace201b98d39248
                default:
                    throw new ArgumentException();
            }

        }
    }
}
