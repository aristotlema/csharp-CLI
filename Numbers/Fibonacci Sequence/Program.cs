using System;

/*Fibonacci Sequence - 
 * Enter a number and have the program generate the Fibonacci sequence to that number or to the Nth number.*/

namespace Fibonacci_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many numbers of the Fibonacci Sequence?");
            string input = Console.ReadLine();
            int count = Int32.Parse(input);

            if (count >= 20 || count < 0)
            {
                Console.WriteLine("Sorry that number was to large");
            }
            else
            {
                for (var i = 0; i < count; i++)
                {
                    Console.WriteLine(fibCalc(i));
                }
            }
            
        }

        static int fibCalc(int counter)
        {
            if (counter == 0)
                return 0;
            if (counter == 1)
                return 1;
            return fibCalc(counter - 1) + fibCalc(counter - 2);
        }
    }
}
