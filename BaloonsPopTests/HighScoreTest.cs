namespace UnitTestProject1
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PoppingBaloons;

    [TestClass]
    public class HighScoreTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfAddScoreMethodThrowsOnNullParameterPassed()
        {
            HighScore highScore = new HighScore();
            highScore.AddScore(null);
        }

        [TestMethod]
        public void TestIfOutputIsCorrectWithNoScore()
        {
            HighScore highScore = new HighScore();

            string expected = "The scoreboard is empty";
            string actual = highScore.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIfOutputIsCorrectWithOneScore()
        {
            HighScore highScore = new HighScore();
            Score score = new Score("Player", 100);
            highScore.AddScore(score);
            
            string expected = "Top performers:\r\nPlayer 100\r\n";
            string actual = highScore.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIfOutputIsCorrectWithThreeScores()
        {
            HighScore highScore = new HighScore();

            for (int i = 1; i < 4; i++)
            {
                string name = String.Format("Player {0}", i);

                Score score = new Score(name, 100 * i);
                highScore.AddScore(score);
            }

            string expected = "Top performers:\r\nPlayer 3 300\r\nPlayer 2 200\r\nPlayer 1 100\r\n";
            string actual = highScore.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIfOutputIsCorrectWithSixScoresAndTheLastAddedIsBiggest()
        {
            HighScore highScore = new HighScore();

            for (int i = 1; i < 7; i++)
            {
                string name = String.Format("Player {0}", i);

                Score score = new Score(name, 100 * i);
                highScore.AddScore(score);
            }

            string expected = "Top performers:\r\nPlayer 6 600\r\nPlayer 5 500\r\nPlayer 4 400\r\nPlayer 3 300\r\nPlayer 2 200\r\n";
            string actual = highScore.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIfOutputIsCorrectWithSixScoresAndTheLastAddedIsSmallest()
        {
            HighScore highScore = new HighScore();

            for (int i = 6; i > 0; i--)
            {
                string name = String.Format("Player {0}", i);

                Score score = new Score(name, 100 * i);
                highScore.AddScore(score);
            }

            string expected = "Top performers:\r\nPlayer 6 600\r\nPlayer 5 500\r\nPlayer 4 400\r\nPlayer 3 300\r\nPlayer 2 200\r\n";
            string actual = highScore.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIfOutputIsCorrectWithSixDifferentScores()
        {
            HighScore highScore = new HighScore();

            highScore.AddScore(new Score("Ivan Ivanov", 1200));
            highScore.AddScore(new Score("Georgi Georgiev", 3600));
            highScore.AddScore(new Score("Petar Petrov", 200));
            highScore.AddScore(new Score("Maria Petrova", 10200));
            highScore.AddScore(new Score("Galq Georgieva", 50));
            highScore.AddScore(new Score("Ivanka Ivanova", 1750));

            string expected = "Top performers:\r\nMaria Petrova 10200\r\nGeorgi Georgiev 3600\r\nIvanka Ivanova 1750\r\nIvan Ivanov 1200\r\nPetar Petrov 200\r\n";
            string actual = highScore.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
