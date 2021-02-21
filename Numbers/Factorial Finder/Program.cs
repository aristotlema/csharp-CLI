using System;

/*Factorial Finder 
 * The Factorial of a positive integer, n, is defined as the product of the sequence n, n-1, n-2, ...1 and the factorial of zero, 0, is defined as being 1. Solve this using both loops and recursion.*/

namespace Factorial_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FactorialForLoop(7));

            Console.WriteLine(FactorialRecursion(5));
        }

        static int FactorialForLoop(int input)
        {
            int currentTotal = input * (input - 1);
            for(var i = input - 2; i > 0; i--)
            {
                currentTotal = i * currentTotal;
            }
            return currentTotal;
        }
        static int FactorialRecursion(int input)
        {
            if (input == 1) 
                return 1;
            return input * FactorialRecursion(input - 1);
        }
    }
}
