using System;

/*Find PI to the Nth Digit - 
 * Enter a number and have the program generate PI up to that many decimal places. 
 * Keep a limit to how far the program will go.
 
 
find the length of the number where the nth digit is from
find the actual number where the nth digit is from
find the nth digit and return
 
 */

namespace FindPiToTheNthDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            double pi = Math.PI;

            string piParse = pi.ToString();
            string printedPi = "";

            Console.WriteLine("How many Decimal Places of Pi?");
            string input = Console.ReadLine();

            int userInput = Int32.Parse(input);

            if(userInput > 15)
            {
                Console.WriteLine("Sorry That number was too large");
            }
            else
            {
                for (var i = 0; i < userInput + 2; i++)
                {
                    printedPi += String.Join("", piParse[i]);
                }
                Console.WriteLine(printedPi);
            }

            
        }
    }
}
