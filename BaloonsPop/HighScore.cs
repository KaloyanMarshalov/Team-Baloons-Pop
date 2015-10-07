﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HighScore.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   A class that updates and prints the highscore.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PoppingBaloons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Sealed class used for logging various messages on the console:
    /// <list type="bullet">
    /// <item> 
    /// <description><see cref="HighScore()"/></description> 
    /// </item>
    /// <item> 
    /// <description><see cref="AddScore"/></description> 
    /// </item>
    /// <item> 
    /// <description><see cref="ToString"/></description> 
    /// </item>
    /// </list> 
    /// </summary>
    public class HighScore
    {
        private const int MaxScoreCount = 5;
        private readonly SortedList<int, Score> scoreList;
        private readonly IComparer<int> descendingComparer = new ScoreComparer();

        /// <summary>
        /// A constructor used to instantiate the class.
        /// </summary>
        public HighScore()
        {
            this.scoreList = new SortedList<int, Score>(this.descendingComparer);
        }

        /// <summary>
        /// A method used for adding scores to a scorelist.
        /// </summary>
        /// <param name="scoreToAdd">The parameter the method is called upon.</param>
        /// <exception cref="System.ArgumentNullException">An exception is thrown if 
        /// there is no score to add.</exception>
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

        /// <summary>
        /// A method used for creating messages announcing the top players.
        /// </summary>
        /// <returns>The method returns a new string.</returns>
        public override string ToString()
        {
            if (this.scoreList.Count == 0)
            {
                return "The scoreboard is empty";
            }

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Top performers:");

            foreach (var score in this.scoreList)
            {
                stringBuilder.AppendLine(score.Value.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}