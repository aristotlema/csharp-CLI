using System;

/*Coin Flip Simulation 
 * Write some code that simulates flipping a single coin however many times the user decides. 
 * The code should record the outcomes and count the number of tails and heads.*/

namespace Coin_Flip_Simulation
{
    class Program
    {
        static readonly Random result = new Random();
        static void Main(string[] args)
        {
            int totalFlips = 0;
            int sideUp = 0;
            int scoreKeeper = 0;

            Console.WriteLine("How many flips would you like to do?");
            string input = Console.ReadLine();
            int flipCount = Int32.Parse(input);

            for(var i = 0; i < flipCount; i++)
            {
                totalFlips++;
                sideUp = coinFlipper();
                if(sideUp == 0)
                {
                    Console.WriteLine($"{sideUp} - Heads");
                }
                else if(sideUp == 1)
                {
                    scoreKeeper++;
                    Console.WriteLine($"{sideUp} - Tails");
                }    
                    
            }

            Console.WriteLine($"Total flips: {totalFlips}");
            Console.WriteLine($"Heads: {totalFlips - scoreKeeper} - Tails:{(totalFlips + scoreKeeper) - totalFlips}");
        }

        static int coinFlipper()
        {
            return result.Next(0, 2);
        }

    }
}
