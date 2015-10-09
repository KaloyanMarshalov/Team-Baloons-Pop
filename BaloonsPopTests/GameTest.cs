namespace BaloonsPopTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PoppingBaloons;
    using PoppingBaloons.Interfaces;

    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void TestIfOutputIsCorrectWithNoScore()
        {
            ILogger logger = ConsoleLogger.LoggerInstance;
            Game newGame = new Game(logger);

            string expected = "The scoreboard is empty";
            string actual = newGame.DisplayScoreboard();
          
            Assert.AreEqual(expected, actual);
        }
    }
}
