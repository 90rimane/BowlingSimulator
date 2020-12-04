using System;
using BowlingLibrary;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BowlingApp
{
    public class Game
    {
        public List<People> Players = new List<People>();
        public List<ScoreHistory> History = new List<ScoreHistory>();
        public void Run()
        {
            // Main menu
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t****Welcome to Bowling-Simulator****");
                Console.WriteLine("\nEnter a command:\n\n" +
                                   " [P] Play\n" +
                                   " [L] List Scores\n" +
                                   " [E] Exit");
                ConsoleKeyInfo inputUser = Console.ReadKey(true);
                switch (inputUser.Key)
                {
                    case ConsoleKey.P:
                        {
                            Console.Clear();
                            AddPlayer();
                            int count = 0;
                            while (count < 11)
                            {
                                Console.Clear();
                                PlayGame(count);
                                count++;
                            }
                            Console.WriteLine("god job! You are done.\n");
                            CalculateScore();
                            Helper.PressAnyKeyToContinue();
                            break;
                        }
                    case ConsoleKey.L:
                        {
                            Console.Clear();
                            ShowHighscoreList();
                            break;
                        }
                    case ConsoleKey.E:
                        {
                            Environment.Exit(0);
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Please choose something in the menu.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey(true);
                            break;
                        }
                }
            }
        }

        public void SaveHistory()
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string filePath = Path.Combine(appDataFolder, "ScoreList.csv");
            FileStream fsOverwrite = new FileStream(filePath, FileMode.Create);
            using (StreamWriter swOverwrite = new StreamWriter(fsOverwrite))
            {
                foreach (var score in History)
                {
                    swOverwrite.WriteLine(score.Name + ";" + score.Scores);
                }
            }
        }
        public void ReadFile()
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string filePath = Path.Combine(appDataFolder, "ScoreList.csv");
            if (!File.Exists(filePath))
            {
                using (File.Create(filePath));
            }
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    History.Add(new ScoreHistory(values[0], int.Parse(values[1])));
                }
            }
        }
        public void AddPlayer()
        {
            Console.WriteLine("Enter player number:(1-4 players)");
            int inputUser = int.Parse(Console.ReadLine());
            for (int j = 0; j < inputUser; j++)
            {
                if (Players.Count > 3)
                {
                    Console.WriteLine("Maximum players is 4.");
                    Helper.PressAnyKeyToContinue();
                    return;
                }
                Console.Write("Player{0}, Enter name: ",j+1);
                string temporaryName = Helper.VerifyString(Console.ReadLine());
                AddPlayerToList(temporaryName);
            }
        }
        public void AddPlayerToList(string name)
        {
            Players.Add(new People(name));
        }

        public void ShowHighscoreList()
        {
            int index = 1;
            if (History.Count > 0)
            {
                foreach (var score in History)
                {
                    Console.WriteLine($"{index}. Name: {score.Name}, Scores: {score.Scores}");
                    index++;
                }
            }
            else
            {
                Console.WriteLine("Playerlist is empty. ");
            }
            Helper.PressAnyKeyToContinue();
        }
        public void CalculateScore()
        {
            Round tmp = new Round();
            foreach (var Player in Players)
            {
                Console.WriteLine($"{Player.Name}'s score is: {tmp.Score(Player)}");
                History.Add(new ScoreHistory(Player.Name, tmp.Score(Player)));
            }
            History = History.OrderBy(x => x.Scores).ToList();
            History.Reverse();
            SaveHistory();
            ClearPlayerList();
        }
        private void ClearPlayerList()
        {
            foreach (var player in Players)
            {
                player.FrameScores.Clear();
            }
            Players.Clear();

        }
        public void InserHittingToList(int ball1, int ball2, People player)
        {
            Round tmp = new Round();
            tmp.Roll(ball1, ball2, player);
        }
        public void PlayGame(int count)
        {

            foreach (var Player in Players)
            {
                int ball1 = 0;
                int ball2 = 0;
                if (count == 10)
                {
                    Scores[] tmpArr = Player.FrameScores.ToArray();

                    if (tmpArr[9].SpareOrStrike == 'X')
                    {
                        Console.WriteLine($"Frame{count + 1}\tPlayer {Player.Name}\t Extra Ball");
                        ball1 = Helper.VerifyInt(Console.ReadLine());
                        while (ball1 < 0 || ball1 > 10)
                        {
                            Console.WriteLine("Enter number between 1 and 10.");
                            ball1 = Helper.VerifyInt(Console.ReadLine());
                        }
                        if (ball1 != 10)
                        {
                            Console.WriteLine($"\t\tPlayer {Player.Name}");
                            ball2 = Helper.VerifyInt(Console.ReadLine());
                            while (ball2 < 0 || ball2 > (10 - ball1))
                            {
                                Console.WriteLine($"Only {10 - ball1} pins left.");
                                ball2 = Helper.VerifyInt(Console.ReadLine());
                            }
                            InserHittingToList(ball1, ball2, Player);
                        }
                        else if (ball1 == 10)
                        {
                            InserHittingToList(ball1, ball2, Player);
                            Console.WriteLine($"Player {Player.Name}\t\t Extra Ball2");
                            ball1 = Helper.VerifyInt(Console.ReadLine());
                            while (ball1 < 0 || ball1 > 10)
                            {
                                Console.WriteLine("Enter number between 1 and 10.");
                                ball1 = Helper.VerifyInt(Console.ReadLine());
                            }
                            InserHittingToList(ball1, ball2, Player);
                        }
                    }
                    else if (tmpArr[9].SpareOrStrike == '/')
                    {
                        Console.WriteLine($"Frame{count + 1}\tPlayer {Player.Name}\t ");
                        ball1 = Helper.VerifyInt(Console.ReadLine());
                        while (ball1 < 0 || ball1 > 10)
                        {
                            ball1 = Helper.VerifyInt(Console.ReadLine());
                        }
                        InserHittingToList(ball1, ball2, Player);
                    }
                }
                else
                {

                    Console.WriteLine($"Frame{count + 1}\tPlayer {Player.Name}\t");
                    Console.Write("\tBall1: ");
                    ball1 = Helper.VerifyInt(Console.ReadLine());
                    while (ball1 < 0 || ball1 > 10)
                    {
                        Console.WriteLine("Enter number between 1 and 10.");
                        ball1 = Helper.VerifyInt(Console.ReadLine());
                    }
                    if (ball1 == 10)
                    {
                        InserHittingToList(ball1, ball2, Player);
                        continue;
                    }
                    else
                    {
                        Console.Write("\tBall2: ");
                        ball2 = Helper.VerifyInt(Console.ReadLine());
                        while (ball2 < 0 || ball2 > (10 - ball1))
                        {
                            Console.WriteLine($"Only {10 - ball1} pins left. ");
                            ball2 = Helper.VerifyInt(Console.ReadLine());
                        }

                    }
                    InserHittingToList(ball1, ball2, Player);
                }

            }
            Console.Clear();
        }
        public void WriteAllPlayerNames()
        {
            foreach (var player in Players)
            {
                Console.Write($"{player.Name}, ");
            }
            Console.WriteLine("");
        }
    }
}