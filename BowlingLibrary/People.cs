using System;
using System.Collections.Generic;


namespace BowlingLibrary
{
    public class People
    {
        public People(string name, int totalScores = 0)
        {
            Name = name;
            TotalScores = totalScores;
            List<Scores> frameScores = new List<Scores>();
            FrameScores = frameScores;
        }
        public string Name { get; set; }
        public int TotalScores { get; set; }
        public List<Scores> FrameScores { get; set; }

    }
}
