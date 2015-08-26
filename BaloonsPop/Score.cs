namespace PoppingBaloons
{
    using System;

    public class Score : IComparable
    {
        private const int MinimumPlayerNameLength = 3;
        private const int MaximumPlayerNameLength = 25;
        private const string NameErrorStringFormat = "Player name must be longer than {0} and shorter than {1} symbols";

        private string playerName;
        private int points;

        public Score(string nameOfPlayer, int points)
        {
            this.PlayerName = nameOfPlayer;
            this.Points = points;
        }

        public int CompareTo(object obj)
        {
            return (((Score)obj).Points).CompareTo(this.Points) * -1;
        }

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
            return this.PlayerName + " " + this.Points;
        }
    }
}