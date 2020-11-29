using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingLibrary;

namespace BowlingApp
{
    class Game
    {
        public string newName;
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t****Welcome to Bowling-Simulator****");
                Console.WriteLine("\nEnter a command:\n" +
                                   "[P] Play\n" +
                                   "[E] Exit");
                ConsoleKeyInfo inputUser = Console.ReadKey(true);
                switch (inputUser.Key)
                {
                    case ConsoleKey.P:
                        {
                            PreparePlay();
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
        public void PreparePlay()
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
                                Run();
                        }
                        else
                            Console.WriteLine("Enter between 1-4:");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter integer:");
                }
            }
        }
        public void Play()
        {
            Console.Clear();
            Round player = new Round(newName);
            Console.WriteLine("\tHello {0}\n", player.Name);
            for (int i = 0; i < 10; i++)
            {
                int newPins1, newPins2;
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
                    if (i == 9)                       //frame 10, Extra ball
                    {
                        Console.Write("\t\tBall2: ");
                        int strikeBonus = int.Parse(Console.ReadLine());
                        player.Roll(strikeBonus);

                        Console.Write("\t\tBall3: ");
                        int newPins3 = int.Parse(Console.ReadLine());
                        player.Roll(newPins3);

                        Console.WriteLine("Score: {0}\n" +
                    "---------------------------", player.Score);
                    }
                    else
                    {
                        Console.WriteLine("\t\tBall2: /");
                        Console.WriteLine("Score: {0}\n" +
                            "---------------------------", player.Score);
                    }
                }
                else                     // (!newPins1 == 10)
                {
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
                                                                 "---------------------------", player.Score);
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
                                                                 "---------------------------", player.Score);
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
            Console.WriteLine("You are done, Good Job!");
            Console.WriteLine("Enter any key to continue...");
            Console.ReadKey();
        }
    }
}