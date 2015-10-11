namespace PoppingBaloons.Board.BalloonFactory
{
    using System;       
    using System.Linq;     

    public class BalloonMaker
    {
        private int balloonsCreated;
        private const float BonusBalloonProbailityInPercent = 10;

        public Balloon MakeBalloon(BaloonColor colorOfBalloon) 
        {
            Balloon newBalloon;
            this.balloonsCreated++;

            switch (colorOfBalloon)
            {
                case BaloonColor.Blue: 
                    newBalloon = new Balloon("blue");
                    break;
                case BaloonColor.Green:
                    newBalloon = new Balloon("green");
                    break;
                case BaloonColor.Red:
                    newBalloon = new Balloon("red");
                    break;
                case BaloonColor.Yellow:
                    newBalloon = new Balloon("yellow");
                    break;
                default:
                    throw new ArgumentException();
            }

            if (balloonsCreated % BonusBalloonProbailityInPercent == 0)
            {
                return newBalloon;
            }

            return newBalloon;
        }
    }
}
