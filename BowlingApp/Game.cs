using System;
using BowlingLibrary;

namespace BowlingApp
{
    public class Game
    {
        readonly People[] persons = new People[4];
        public int totalScore = 10;
        public string newName;
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
                            PreparePlay();
                            break;
                        }
                    case ConsoleKey.L:
                        {
                            ListPlayerAndScores();
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
        //Get player Name
        private void PreparePlay()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of players:(Max 4 players!)");
                try
                {
                    while (true)
                    {
                        int playerNumber = Convert.ToInt32(Console.ReadLine());
                        if (playerNumber > 0 && playerNumber < 5)
                        {
                            for (int i = 0; i < playerNumber; i++)
                            {
                                Console.Clear();
                                Console.Write("Player{0}, Enter name:", i + 1);
                                newName = Console.ReadLine();

                                Play();
                            }
                            break;
                        }
                        else
                            Console.WriteLine("Enter between 1-4:");
                    }
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter integer:");
                }
            }
            Run();
        }
        //Play game
        private void Play()
        {
            Console.Clear();
            Round player = new Round();
            People people = new People(newName,totalScore);      //totalScore= 0
            Console.WriteLine("\tHello {0}\n",people.Name);
            for (int i = 0; i < 10; i++)
            {
                int newPins1, newPins2;         //first ball and second ball hitting
                while (true)
                {
                    try
                    {
                        while (true)
                        {
                            Console.Write("Frame{0}: ", i + 1);
                            Console.Write("\tBall1: ");
                            newPins1 = int.Parse(Console.ReadLine());
                            if (newPins1 >= 0 && newPins1 <= 10)
                            {
                                player.Roll(newPins1);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Enter number of hitted pins.(1 to 10)");
                            }
                        }
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Enter just number:");
                    }
                }
                if (newPins1 == 10)
                {
                    if (i == 9)                            //frame 10, Extra ball
                    {
                        Console.Write("\t\tBall2: ");
                        int strikeBonus = int.Parse(Console.ReadLine());
                        player.Roll(strikeBonus);

                        Console.Write("\t\tBall3: ");
                        int newPins3 = int.Parse(Console.ReadLine());
                        player.Roll(newPins3);

                        Console.WriteLine("Score: {0}\n" +
                    "--------------------------", player.Score);
                    }
                    else
                    {
                        Console.WriteLine("\t\tBall2: /");
                        Console.WriteLine("Score: {0}\n" +
                            "--------------------------", player.Score);
                    }
                }
                else                         // (!newPins1 == 10)
                {
                    //Second ball hitting
                    while (true)
                    {
                        int leftPins = 10 - newPins1;
                        try
                        {
                            while (true)
                            {
                                try
                                {
                                    if (i < 9)
                                    {
                                        while (true)
                                        {
                                            Console.Write("\t\tBall2: ");
                                            newPins2 = int.Parse(Console.ReadLine());
                                            int totalPins = newPins1 + newPins2;
                                            if (newPins2 <= leftPins && newPins2 >= 0)
                                            {
                                                player.Roll(newPins2);
                                                Console.WriteLine("Score: {0}\n" +
                                                                 "--------------------------", player.Score);
                                                break;
                                            }
                                            else
                                            { Console.WriteLine("Only {0} pins left.", leftPins); }
                                        }
                                    }
                                    else if (i == 9)                             //frame10 Sparebonus
                                    {
                                        while (true)
                                        {
                                            Console.Write("\t\tBall2: ");
                                            newPins2 = int.Parse(Console.ReadLine());
                                            int totalPins = newPins1 + newPins2;
                                            if (newPins2 <= leftPins && newPins2 >= 0)
                                            {
                                                if (totalPins == 10)
                                                {
                                                    player.Roll(newPins2);
                                                    Console.Write("\t\tBall3: ");
                                                    int spareBonus = int.Parse(Console.ReadLine());
                                                    player.Roll(spareBonus);
                                                    Console.WriteLine("Score: {0}\n" +
                                                                 "--------------------------", player.Score);
                                                    break;
                                                }
                                                else
                                                {
                                                    player.Roll(newPins2);
                                                    Console.WriteLine("Score: {0}\n" +
                                                                     "---------------------------", player.Score);
                                                    break;
                                                }
                                            }
                                            else
                                            { Console.WriteLine("Only {0} pins left.", leftPins); }
                                        }
                                    }
                                    break;
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Enter a integer...");
                                }
                            }
                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Enter just number:");
                        }
                    }
                }
            }
                totalScore = player.Score;
                Console.WriteLine("Total Score: {0}\n",totalScore);

            for (int j = 0; j < persons.Length; j++)
            {
                if (persons[j] == null)
                {
                    persons[j] = new People(newName,totalScore);                               
                    break;
                }
                else
                {
                    continue;
                }
            }

            Console.WriteLine("You are done, Good Job!");
            Console.WriteLine("Enter any key to continue...");
            Console.ReadKey();
        }
        //List player
        private void ListPlayerAndScores()
        {
            Console.Clear();
            Console.WriteLine("\tPlayer Scores:\n");
            int personsNumber = 0;
            foreach(People person in persons)
            {
                personsNumber++;
                if (person == null)
                {
                    Console.WriteLine("Player{0}: \tNo player played.", personsNumber);
                }
                else
                {
                    Console.WriteLine("Player{0}: \t{1}'s Score:{2}",personsNumber,person.Name,person.TotalScore);
                }
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
        }
    }
}