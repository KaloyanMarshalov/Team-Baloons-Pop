namespace PoppingBaloons
{
    using System;
    using System.Collections;
    using System.Text;

    public class HighScore
    {
        private const int maxScoreCount = 5;
        private SortedList scoreList;

        public HighScore()
        {
            this.scoreList = new SortedList();
        }

        public void AddScore(Score scoreToAdd)
        {
            if (scoreToAdd == null)
            {
                throw new ArgumentNullException("Cannot add score with value of null");
            }

            this.scoreList.Add(scoreToAdd.Points, scoreToAdd);

            if (this.scoreList.Count > maxScoreCount)
            {
                this.scoreList.RemoveAt(maxScoreCount);
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

            foreach (DictionaryEntry score in scoreList)
            {
                stringBuilder.AppendLine(score.Value.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}