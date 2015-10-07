// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScoreComparer.cs" company="Team-Baloon-Pop">
//   Team-Baloon-Pop
// </copyright>
// <summary>
//   An internal class used for comparison of two integers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PoppingBaloons
{
    using System.Collections.Generic;

    /// <summary>
    /// An internal class used for comparison of two integers:
    /// <list type="bullet">
    /// <item> 
    /// <description><see cref="Compare"/></description> 
    /// </item>
    /// </list> 
    /// </summary>

    internal class ScoreComparer : IComparer<int>
    {
        /// <summary>
        /// A method used to compare two integers.
        /// </summary>
        /// <param name="first">The integer the method is called upon.</param>
        /// <param name="second">The integer the method is called upon.</param>
        /// <returns>Returns a value less than 0, 0 or greater than zero, depending
        /// on the result of the comparison.</returns>
        public int Compare(int first, int second)
        {
            return second.CompareTo(first);
        }
    }
}