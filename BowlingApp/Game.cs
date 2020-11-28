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
        public void Run()
        {
            Round[] person = new Round[4];   // Player max 4 persons

            Round player = new Round();
            for (int i = 0; i < 10; i++)
            {
                int newPins1;
                while (true)
                {
                    try
                    {
                        while (true)
                        {                           
                            Console.Write("Fram {0}:\t", i + 1);
                            Console.Write("\tBall 1: ");
                            newPins1 = int.Parse(Console.ReadLine());
                            if (newPins1 >= 0 && newPins1 <= 10)
                            {
                                player.Roll(newPins1);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Enter count of falled down pins.(1 to 10)");
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
                    Console.WriteLine("\t\tBall 2: /");
                    Console.WriteLine("Score {0}:\n" +
                        "--------------------------", player.Score);
                }
                else
                {
                    while (true)
                    {
                            int leftPins = 10 - newPins1;
                        try
                        {
                            while (true)
                            {
                                Console.Write("\t\tBall 2: ");
                                int newPins2 = int.Parse(Console.ReadLine());
                                if (newPins2 <= leftPins)
                                {
                                    player.Roll(newPins2);
                                    break;
                                }
                                else
                                { Console.WriteLine("Only {0} pins left.", leftPins); }
                            }

                            Console.WriteLine("Score {0}:\n" +
                                "--------------------------", player.Score);
                            break;
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Enter just number:");
                        }
                    }

                }
            }

        }
    }
}
