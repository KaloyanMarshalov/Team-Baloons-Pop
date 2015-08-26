namespace PoppingBaloons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HighScore
    {
        private const int MaxScoreCount = 5;
        private readonly SortedList<int, Score> scoreList;
        private readonly IComparer<int> descendingComparer = new ScoreComparer();

        public HighScore()
        {
            this.scoreList = new SortedList<int, Score>(descendingComparer);
        }

        public void AddScore(Score scoreToAdd)
        {
            if (scoreToAdd == null)
            {
                throw new ArgumentNullException("Cannot add score with value of null");
            }

            this.scoreList.Add(scoreToAdd.Points, scoreToAdd);

            if (this.scoreList.Count > MaxScoreCount)
            {
                this.scoreList.RemoveAt(MaxScoreCount);
            }
        }

        public override string ToString()
        {
            if (scoreList.Count == 0)
            {
                return "The scoreboard is empty";
            }

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Top performers:");

            foreach (var score in scoreList)
            {
                stringBuilder.AppendLine(score.Value.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}