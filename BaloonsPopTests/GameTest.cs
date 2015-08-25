namespace BaloonsPopTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PoppingBaloons;

    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void TestIfDisplayScoreBoardMethodReturnsProperStringWithEmptyScoreboard()
        {
            Game testGame = new Game();
            string expected = "The scoreboard is empty\r\n";

            string actual = testGame.DisplayScoreboard();

            Assert.AreEqual(expected, actual);
        }
    }
}
