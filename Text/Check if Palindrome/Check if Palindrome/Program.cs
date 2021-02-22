using System;

/*Check if Palindrome 
 * Checks if the string entered by the user is a palindrome. That is that it reads the same forwards as backwards like “racecar”*/

namespace Check_if_Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            bool active = true;
            Console.WriteLine(isPalindrome("racecar") ? "True" : "False");
            Console.WriteLine(isPalindrome("apple") ? "True" : "False");
            while(active)
            {
                Console.WriteLine("Enter a word, I will check if it a Palindrome");
                string userInput = Console.ReadLine();

                Console.WriteLine(isPalindrome(userInput));

                if(userInput == "quit" || userInput == "q" || userInput == "Q")
                {
                    active = false;
                }
            }
        }

        static bool isPalindrome(string input)
        {
            string reversedWord = "";
            string compareWord = "";
            for(var i = input.Length - 1; i >= 0; i--)
            {
                if(input[i] != ' ')
                {
                    reversedWord += input[i];
                }
            }

            for(var i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    compareWord += input[i];
                }
            }

            Console.WriteLine(reversedWord);
            Console.WriteLine(compareWord);
            if (compareWord == reversedWord) return true;
            else if (compareWord != reversedWord) return false;
            else return false;
        }
    }
}
