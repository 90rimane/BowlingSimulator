using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingLibrary
{
    public class ScoreHistory
    {
        public ScoreHistory(string name, int scores)
        {
            Name = name;
            Scores = scores;
        }
        public string Name { get; set; }
        public int Scores { get; set; }
    }
}

