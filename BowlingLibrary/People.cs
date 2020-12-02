using System;


namespace BowlingLibrary
{
    public class People
    {
        public People(string name, int totalScore)
        {
            Name = name;
            TotalScore = totalScore;
        }
        public string Name { get; set; }
        public int TotalScore { get; set; }
    }
}
