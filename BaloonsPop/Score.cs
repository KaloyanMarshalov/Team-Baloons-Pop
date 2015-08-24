namespace PoppingBaloons
{
    using System;

    class Score
    {
        private const int MinimumPlayerNameLength = 3;
        private string nameOfPlayer;
        private int score;

        public Score(string nameOfPlayer, int score)
        {
            this.nameOfPlayer = nameOfPlayer;
            this.score = score;
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

        public int Score
        {
            get
            {
                return this.score;
            }
            set
            {
                if (value < 0)
                {
		            throw new ArgumentOutOfRangeException("Score must be zero or more");
                }

                this.score = value;
            }
        }

        public override string ToString()
        {
            return this.NameOfPlayer + " " + this.Score;
        }
    }
}