using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingLibrary
{
    public class Round
    {
        private List<int> _rolls = new List<int>(21);
       

        public void Roll(int pins)
        {
            _rolls.Add(pins) ;
        }
        public int Score 
        {
            get
            {
                int score = 0;
                int frameIndex = 0;
                for (int frame = 0; frame<10 ; frame++)
                {
                    if (IsSpare(frameIndex))
                    {
                        //spare
                        score += 10 + _rolls[frameIndex + 2];
                        frameIndex += 2;
                    }
                    else
                    {
                        score += _rolls[frameIndex] + _rolls[frameIndex + 1];
                        frameIndex += 2;
                    }
                }
                return score;
            }
        }

        private bool IsSpare(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1] == 10;
        }
    }
}
