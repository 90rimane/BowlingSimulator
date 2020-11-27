using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingLibrary;

namespace BowlingGameTest
{
    [TestClass]
    public class BowlingTest
    {
        [TestMethod]
        public void RoundTest()
        {
            var game = new Round();
            for (int i = 0; i < 20; i++)
            {
                Round.Roll(0);
            }
            Assert.AreEqual(0, Round.Score);
        }
    }
}
