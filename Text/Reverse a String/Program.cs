using System;

/*    Reverse a String 
 *    Enter a string and the program will reverse it and print it out.*/


namespace Reverse_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input a string, I will reverse it");
            string inputString = Console.ReadLine();
            string outputString = "";


            for(var i = inputString.Length; i --> 0;)
            {
                outputString += inputString[i];
                
            }

            Console.WriteLine(outputString);

        }
    }
}
