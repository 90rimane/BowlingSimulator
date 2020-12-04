using System;
using System.Collections.Generic;

namespace BowlingLibrary
{
    public class Round
    {
        public int Roll(int ball1, int ball2, People player)
        {
            int totalPins = ball1 + ball2;
            if (totalPins > 10 || totalPins < 0 || ball1 < 0 || ball1 > 10 || ball2 < 0 || ball2 > 10)
                throw new ArgumentException();

            int tmpFramePoint = totalPins;
            if (ball1 == 10)
            {
                player.FrameScores.Add(
                    new Scores(ball1, ball2, tmpFramePoint, 'X')
                    );
            }
            else if (ball1 + ball2 == 10)
            {
                player.FrameScores.Add(
                    new Scores(ball1, ball2, tmpFramePoint, '/')
                    );
            }
            else
            {
                player.FrameScores.Add(
                    new Scores(ball1, ball2, tmpFramePoint, '0')
                    );
            }

            return tmpFramePoint;
        }
        public int Score(People player)
        {
            int totalScore = 0;
            int framePoint = 0;
            for (int i = 0; i < player.FrameScores.Count; i++)
            {
                if (i < 10)
                {
                    framePoint = player.FrameScores[i].Score;
                    if (player.FrameScores[i].SpareOrStrike == 'X')
                    {
                        framePoint += player.FrameScores[i + 1].Ball2;
                        if (player.FrameScores[i + 1].SpareOrStrike == 'X')
                            framePoint += player.FrameScores[i + 2].Ball1;
                        else
                            framePoint += player.FrameScores[i + 1].Ball2;
                    }
                    else if (player.FrameScores[i].SpareOrStrike == '/')
                    {
                        framePoint += player.FrameScores[i + 1].Ball1;
                    }
                    totalScore += framePoint;
                }
            }
            player.TotalScores = totalScore;
            return totalScore;
        }
    }
}
