// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Score.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   A class that updates the score of each player.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PoppingBaloons
{
    using System;

    /// <summary>
    /// A class that updates the score of each player:
    /// <list type="bullet">
    /// <item> 
    /// <description><see cref="CompareTo"/></description> 
    /// </item>
    /// <item> 
    /// <description><see cref="ToString"/></description> 
    /// </item>
    /// </list> 
    /// </summary>
    public class Score : IComparable
    {
        private const int MinimumPlayerNameLength = 3;
        private const int MaximumPlayerNameLength = 25;
        private const string NameErrorStringFormat = "Player name must be longer than {0} and shorter than {1} symbols";

        private string playerName;
        private int points;

        /// <summary>
        /// A constructor used to instantiate the class.
        /// </summary>
        /// <param name="nameOfPlayer">The string the contructor uses.</param>
        /// <param name="points">The integer the contructor uses.</param>
        public Score(string nameOfPlayer, int points)
        {
            this.PlayerName = nameOfPlayer;
            this.Points = points;
        }

        /// <summary>
        /// Gets or sets the player name.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">Throws if the name is not in
        /// the desired range.</exception>
        public string PlayerName
        {
            get
            {
                return this.playerName;
            }

            set
            {
                if (value.Length <= MinimumPlayerNameLength || value.Length > MaximumPlayerNameLength)
                {
                    throw new ArgumentOutOfRangeException(string.Format(NameErrorStringFormat, MinimumPlayerNameLength, MaximumPlayerNameLength));
                }

                this.playerName = value;
            }
        }

        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">Throws if points are lower than 0.</exception>
        public int Points
        {
            get
            {
                return this.points;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Score must be zero or more");
                }

                this.points = value;
            }
        }

        /// <summary>
        /// A method that compares the points.
        /// </summary>
        /// <param name="obj">The object the method is called upon.</param>
        /// <returns>The compared result multiplied by -1.</returns>
        public int CompareTo(object obj)
        {
            return ((Score)obj).Points.CompareTo(this.Points) * -1;
        }

        /// <summary>
        /// A method used to concatenate the player name and his/her points.
        /// </summary>
        public override string ToString()
        {
            return this.PlayerName + " " + this.Points;
        }
    }
}