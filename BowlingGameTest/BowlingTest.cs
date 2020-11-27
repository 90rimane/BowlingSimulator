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
            var game = SetupRound();

            RollPins(game,20,0);

            Assert.AreEqual(0, game.Score);
        }
        [TestMethod]
        public void TestHittingOnePin()
        {
            var game = SetupRound();

            RollPins(game, 20, 1);

            Assert.AreEqual(20, game.Score);
        }
        [TestMethod]
        public void TestOneSpare()
        {
            var game = SetupRound();

            game.Roll(5);
            game.Roll(5);
            game.Roll(3);
            RollPins(game, 17, 0);

            Assert.AreEqual(16, game.Score);
        }

        private void RollPins(Round game,int RollsNumber, int HittedPinsPerRoll)
        {
            for (int i = 0; i < RollsNumber; i++)
            {
                game.Roll(HittedPinsPerRoll);
            }
        }

        private Round SetupRound()
        {
            return new Round();
        }

    }
}
