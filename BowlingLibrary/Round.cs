using System;
using System.Collections.Generic;

namespace BowlingLibrary
{
    public class Round
    {
        private List<int> _rolls = new List<int>(21);
        private int _currentRoll = 0;
        public Round()
        {
            for (int i = 0; i < 22; i++)
            {
                _rolls.Add(0);
            }
        }
        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }
        public int Score
        {
            get
            {
                int score = 0;
                int frameIndex = 0;
                for (int frame = 0; frame < 10; frame++)
                {
                    if (IsStrike(frameIndex))
                    {
                        score += 10 + StrikeBonus(frameIndex);
                        frameIndex++;
                    }
                    else if (IsSpare(frameIndex))
                    {
                        score += 10 + SpareBonus(frameIndex);
                        frameIndex += 2;
                    }
                    else
                    {
                        score += NormalFrameBonus(frameIndex);
                        frameIndex += 2;
                    }
                }
                return score;
            }

        }

        private int NormalFrameBonus(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1];
        }

        private int SpareBonus(int frameIndex)
        {
            return _rolls[frameIndex + 2];
        }

        private int StrikeBonus(int frameIndex)
        {
            return _rolls[frameIndex + 1] + _rolls[frameIndex + 2];
        }

        private bool IsStrike(int frameIndex)
        {
            return _rolls[frameIndex] == 10;

        }

        private bool IsSpare(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1] == 10;
        }
    }
}
