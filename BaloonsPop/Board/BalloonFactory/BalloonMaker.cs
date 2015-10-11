// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BalloonMaker.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   A class that is used for making ballons.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PoppingBaloons.Board.BalloonFactory
{
    using System;       
    using System.Linq;

    /// <summary>
    /// A class that updates and prints the highscore:
    /// <list type="bullet">
    /// <item> 
    /// <description><see cref="MakeBalloon"/></description> 
    /// </item>
    /// </list> 
    /// </summary>
    public class BalloonMaker
    {
        private const float BonusBalloonProbailityInPercent = 10;

        private int balloonsCreated;

        /// <summary>
        /// A method that creates baloons depending on the colors passed to the method.
        /// </summary>
        /// <param name="colorOfBalloon">The enum value that the method is called upon.</param>
        /// <returns>A new baloon.</returns>
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

            if (this.balloonsCreated % BonusBalloonProbailityInPercent == 0)
            {
                return newBalloon;
            }

            return newBalloon;
        }
    }
}
