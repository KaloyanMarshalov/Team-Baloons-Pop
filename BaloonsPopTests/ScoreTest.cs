﻿namespace BaloonsPopTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PoppingBaloons.Scores;

    [TestClass]
    public class ScoreTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExpectScoreToThrowWhenInitializedWithInvalidPoints()
        {
            Score score = new Score("Player", -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExpectScoreToThrowWhenInitializedWithLongName()
        {
            Score score = new Score("Playerwithveryverylongname", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExpectScoreToThrowWhenInitializedWithShortName()
        {
            Score score = new Score("Pl", 10);
        }

        [TestMethod]
        public void ExpectScoreNotToThrowWhenInitializedWithValidParameters()
        {
            Score score = new Score("Player", 10);
            string playerName = score.PlayerName;

            Assert.AreEqual(playerName, "Player");
        }

        [TestMethod]
        public void ExpectToStringToReturnProperResult()
        {
            Score score = new Score("Player", 100);
            string expected = "Player 100"; 
            string actual = score.ToString();

            Assert.AreEqual(actual, expected);
        }
    }
}