namespace PoppingBaloons
{
    using System;

    public class Score
    {
        private const int MinimumPlayerNameLength = 3;
        private string nameOfPlayer;
        private int points;

        public Score(string nameOfPlayer, int points)
        {
            this.NameOfPlayer = nameOfPlayer;
            this.Points = points;
        }

        public string NameOfPlayer
        {
            get
            {
                return this.nameOfPlayer;
            }
            set
            {
                if (value.Length <= MinimumPlayerNameLength)
                {
                    throw new ArgumentOutOfRangeException("Player name must be longer than " + (MinimumPlayerNameLength - 1) + " symbols");
                }

                this.nameOfPlayer = value;
            }
        }

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

        public override string ToString()
        {
            return this.NameOfPlayer + " " + this.Points;
        }
    }
}