using System;

/*Count Vowels - 
 * Enter a string and the program counts the number of vowels in the text. 
 * For added complexity have it report a sum of each vowel found.*/

namespace Count_Vowels
{
    class Program

    {
        public static readonly string vowels = "aeiou";
        static void Main(string[] args)
        {
            string input = "This countains 7 vowels";
            Console.WriteLine(CountVowels(input));
        }

        static int CountVowels(string input)
        {
            int numVowels = 0;
            foreach(char letter in input)
            {
                if(vowels.Contains(letter))
                {
                    numVowels++;
                }
            }
            return numVowels;
        }
    }
}
