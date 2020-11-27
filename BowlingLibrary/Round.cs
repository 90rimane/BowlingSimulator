using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingLibrary
{
    public class Round
    {
        public Round()
        {
            Score = 0;
        }

        public void Roll(int pins)
        {
            Score += pins;
        }
        public int Score { get; set; }
    }
}
