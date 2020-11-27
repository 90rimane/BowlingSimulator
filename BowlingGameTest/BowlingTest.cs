using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingLibrary;

namespace BowlingGameTest
{
    [TestClass]
    public class BowlingTest
    {
        [TestMethod]
        public void TestRound()
        {
            var game = new Round();
            for (int i = 0; i < 20; i++)
            {
                game.Roll(0);
            }
            Assert.AreEqual(0, game.Score);
        }
    }
    [TestClass]
    public class Tes
    {
        [TestMethod]
        public void TestHittingOnePinPerRoll()
        {
            var game = new Round();
            for (int i = 0; i < 20; i++)
            {
                game.Roll(1);
            }
            Assert.AreEqual(20, game.Score);
        }
    }
}
