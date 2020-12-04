using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingLibrary
{
    public class Scores
    {
        public Scores(int ball1, int ball2, int score, char spareOrStrike)
        {
            Ball1 = ball1;
            Ball2 = ball2;
            Score = score;
            SpareOrStrike = spareOrStrike;
        }
        public int Ball1 { get; set; }
        public int Ball2 { get; set; }
        public int Score { get; set; }
        public char SpareOrStrike { get; set; }
    }
}
