namespace BaloonsPopTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PoppingBaloons;

    [TestClass]
    public class ScoreTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExpectScoreConstructorToThrowOnInvalidPointsParameterer()
        {
            Score score = new Score("Player", -1);
        }
    }
}