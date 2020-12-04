using System;
using System.Text.RegularExpressions;
using BowlingLibrary;

namespace BowlingApp
{
    public class Helper
    {
        public static void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        public static int VerifyInt(string number)
        {
            bool isOkay = false;
            isOkay = int.TryParse(number, out int result);
            while (!isOkay)
            {
                Console.WriteLine("Invalid input, try again.");
                isOkay = int.TryParse(Console.ReadLine(), out result);
            }
            return result;
        }
        public static bool IsLeterNumber(string input)
        {
            bool isOkay = true;
            if (input.Length < 3 || input.Length > 20)
                isOkay = false;
            if (!Regex.IsMatch(input, @"^[a-zA-Z0-9]+$"))
                isOkay = false;
            if (String.IsNullOrWhiteSpace(input))
                isOkay = false;

            return isOkay;
        }
        public static string VerifyString(string input)
        {
            while (!IsLeterNumber(input))
            {
                Console.WriteLine("Enter only Letter and number.");
                input = Console.ReadLine();
            }
            return input;
        }

    }
}
