using System;

/*Count Words in a String
 * Counts the number of individual words in a string. 
 * For added complexity read these strings in from a text file and generate a summary.*/

namespace Count_Words_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            bool active = true;

            string input = "This string contains 5 words";
            Console.WriteLine(input);
            Console.WriteLine(WordCounter(input));

            while (active)
            {
                Console.WriteLine("Enter some words");
                string userInput = Console.ReadLine();
                Console.WriteLine(userInput);
                Console.WriteLine(WordCounter(userInput));

                if (userInput == "quit" || userInput == "q" || userInput == "Q")
                {
                    active = false;
                }
            }

        }

        static int WordCounter(string input)
        {
            int numSpaces = 0;
            foreach(char letter in input)
            {
                if(letter == ' ')
                {
                    numSpaces++;
                }
            }
            return numSpaces + 1;
        }
    }
}
