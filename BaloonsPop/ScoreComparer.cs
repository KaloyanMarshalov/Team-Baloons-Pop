namespace PoppingBaloons
{
    using System.Collections.Generic;

    internal class ScoreComparer : IComparer<int>
    {
        public int Compare(int first, int second)
        {
            return second.CompareTo(first);
        }
    }
}