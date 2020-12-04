using System;
using Xunit;
using BowlingLibrary;
using BowlingApp;
using System.Collections.Generic;

namespace BowlingProject.UnitTest
{
    public class BowlingProjectTests
    {
        public People CreatePlayer(string name)
        {
            People person = new People(name);
            return person;
        }
        public void CreatePlayerAndAddToList(string name)
        {
            Game.AddPlayerToList(name);
        }
        [Fact]
        public void ReturnFramePoint_Roll2and2_Return4()
        {
            var Round = new Round();
            People Player = CreatePlayer("Ali");

            int actual = Round.Roll(2, 2, Player);

            Assert.Equal(4, actual);
        }
        [Fact]
        public void ReturnFramePoint_Roll0and0_Return0()
        {
            var Round = new Round();
            People Player = CreatePlayer("Ali");

            int actual = Round.Roll(0, 0, Player);

            Assert.Equal(0, actual);
        }

        [Fact]
        public void ReturnFramePoint_BallOneMinusValue_ThrowArgumentException()
        {
            var Round = new Round();
            People Player = CreatePlayer("Ali");

            Assert.Throws<ArgumentException>(() => Round.Roll(-2, 2, Player));
        }

        [Fact]
        public void ReturnFramePoint_BallTwoMinusValue_ThrowArgumentException()
        {
            var Round = new Round();
            People Player = CreatePlayer("Ali");

            Assert.Throws<ArgumentException>(() => Round.Roll(2, -2, Player));
        }

        [Fact]
        public void ReturnFramePoint_RollMoreThan10_ThrowArgumentException()
        {
            var Round = new Round();
            People Player = CreatePlayer("Ali");

            Assert.Throws<ArgumentException>(() => Round.Roll(9, 2, Player));
        }
        [Fact]
        public void ReturnTotalScore_RollOnlyZeroes_Return0()
        {
            var Round = new Round();
            People Player = CreatePlayer("Ali");

            int currentScore = 0;
            for (int i = 0; i < 10; i++)
            {
                currentScore = Round.Roll(0, 0, Player);
            }
            int totalScore = Round.Score(Player);

            Assert.Equal(0, Player.TotalScores);
        }
        [Fact]
        public void ReturnTotalScore_RollOnlyOnes_Return10()
        {
            var Round = new Round();
            People Player = CreatePlayer("Ali");

            int currentScore = 0;
            for (int i = 0; i < 10; i++)
            {
                currentScore = Round.Roll(1, 0, Player);
            }
            int totalScore = Round.Score(Player);

            Assert.Equal(10, Player.TotalScores);
        }
        [Fact]
        public void ReturnTotalScore_RollOnlyStrikes_Return300()
        {
            var Round = new Round();
            People Player = CreatePlayer("Ali");

            int currentScore = 0;
            for (int i = 0; i < 12; i++)
            {
                currentScore = Round.Roll(10, 0, Player);
            }
            int totalScore = Round.Score(Player);

            Assert.Equal(300, Player.TotalScores);
        }
        [Fact]
        public void ReturnTotalScore_RollOnly5And5_Return150()
        {
            var Round = new Round();
            People Player = CreatePlayer("Ali");

            int currentScore = 0;
            for (int i = 0; i < 11; i++)
            {
                currentScore = Round.Roll(5, 5, Player);
            }
            int totalScore = Round.Score(Player);

            Assert.Equal(150, Player.TotalScores);
        }
        [Fact]
        public void AddNewPlayer_ReturnPlayerName()
        {
            People person = new People("Ali");

            Assert.Equal("Ali", person.Name);
        }
        [Fact]
        public void ReturnTotalScore_Roll10StrikesAndTwoOnesAsBonusThrows_Return273()
        {
            var Round = new Round();
            People Player = CreatePlayer("Ali");

            int currentScore = 0;
            for (int i = 0; i < 10; i++)
            {
                currentScore = Round.Roll(10, 0, Player);
            }
            Round.Roll(1, 1, Player);

            int totalScore = Round.Score(Player);

            Assert.Equal(273, Player.TotalScores);
        }
        [Fact]
        public void ReturnTotalScore_Roll10StrikesAndOneStrikeAndOneAsBonus_Return291()
        {
            var Round = new Round();
            People Player = CreatePlayer("Ali");

            int currentScore = 0;
            for (int i = 0; i < 11; i++)
            {
                currentScore = Round.Roll(10, 0, Player);
            }
            Round.Roll(1, 0, Player);

            int totalScore = Round.Score(Player);

            Assert.Equal(291, Player.TotalScores);
        }
        [Fact]
        public void ReturnTotalScore_Roll9StrikesAndTwoFivesAndOneOneAsBonus_Return273()
        {
            var Round = new Round();
            People Player = CreatePlayer("Ali");

            int currentScore = 0;
            for (int i = 0; i < 9; i++)
            {
                currentScore = Round.Roll(10, 0, Player);
            }
            Round.Roll(5, 5, Player);
            Round.Roll(1, 0, Player);
            int totalScore = Round.Score(Player);

            Assert.Equal(266, Player.TotalScores);
        }
        [Fact]
        public void ActivePlayers_CreateFourPlayersAndRoll()
        {
            var Round = new Round();
            People person1 = CreatePlayer("Atena");
            People person2 = CreatePlayer("Willi");
            People person3 = CreatePlayer("Tim");
            People person4 = CreatePlayer("Mikael");
            List<People> Players = new List<People>();
            Players.Add(person1);
            Players.Add(person2);
            Players.Add(person3);
            Players.Add(person4);
            int index = 0;
            foreach (var player in Players)
            {
                Round.Roll(1, 1, player);
                if (index == 0)
                {
                    Assert.Equal("Atena", player.Name);
                }
                if (index == 1)
                {
                    Assert.Equal("Willi", player.Name);
                }
                if (index == 2)
                {
                    Assert.Equal("Tim", player.Name);
                }
                if (index == 3)
                {
                    Assert.Equal("Mikael", player.Name);
                }
                index++;
            }

        }

    }
}
