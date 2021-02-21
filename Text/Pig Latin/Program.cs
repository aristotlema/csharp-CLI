using System;

/*Pig Latin - Pig Latin is a game of alterations played on the English language game. 
 * To create the Pig Latin form of an English word the initial consonant sound is transposed to the end of the word and an ay is affixed (Ex.: "banana" would yield anana-bay). 
 * Read Wikipedia for more information on rules.
 
 -create variable to store vowels and constanants
 itirate throught input and transpose all constants before the initial vowel, and affix "ay" onto the end of the input
 if first letter is a vowel, ad "yay", can also chose to add "hay", or "way"
 
 
 */

namespace Pig_Latin
{
    class Program
    {
        public static string vowel = "AEIOU";
        public static string consonant = "BCDFGHJKLMNPQRSTVWXZY";
        static void Main(string[] args)
        {
            /*Checker();*/

            Console.WriteLine(StringDeconstructor("eat my shorts"));

            Console.WriteLine("What do you want to conver to Pig Latin");
            string userInput = Console.ReadLine();

            Console.WriteLine(StringDeconstructor(userInput));
            
            Console.ReadKey();
        }
        static string StringDeconstructor(string input)
        {
            string currentWord = "";
            string currentSentance = "";

            for (var i = 0; i < input.Length; i++)
            {
                //White space or at the end of string
                if (input[i] == ' ' || i == input.Length - 1)
                {
                    currentWord = PigLatinGenerator(currentWord);
                    currentSentance += currentWord + " ";
                    currentWord = "";
                }
                else if (input[i] != ' ')
                {
                    currentWord += input[i];
                }
            }
            return currentSentance;
        }

        static string PigLatinGenerator(string input)
        {
            string upperInput = input.ToUpper();

            string generatedWord = "";
            string letterDataStore = "";
            bool foundFirstVowel = false;
            bool startedWithVowel = false;


            int count = 1;

            foreach(char letter in upperInput)
            {
                //If the very first letter is a vowel
                if(count == 0 && LetterTypeChecker(letter) == false)
                {
                    foundFirstVowel = true;
                    startedWithVowel = true;
                    generatedWord += letter;
                }
                //if letter is a consonant
                else if (LetterTypeChecker(letter) && foundFirstVowel == false)
                {
                    letterDataStore += letter;
                }
                // if letter is a vowel
                else if (LetterTypeChecker(letter) == false || foundFirstVowel)
                {
                    foundFirstVowel = true;
                    generatedWord += letter;
                }    
            }

            if(startedWithVowel)
            {
                generatedWord += "yay";
            }
            else if(startedWithVowel == false)
            {
                generatedWord = generatedWord + letterDataStore + "ay";
            }

            return generatedWord.ToLower();
        }

        public static bool LetterTypeChecker(char letterCheck)
        {
            if (consonant.Contains(letterCheck))
                return true;
            else if (vowel.Contains(letterCheck))
                return false;
            // return false because we do not want to move any characters outside of alphabet
            else
                Console.WriteLine("A critical error has occured");
                return false;
        }


        //Debug to verify my variables haven't changed
        public static bool Checker()
        {
            int count = 0;
            foreach(char letter in vowel)
            {
                count++;
            }
            foreach(char letter in consonant)
            {
                count++;
            }
            Console.WriteLine(count);
            if (count == 26)
            {
                Console.WriteLine("True");
                return true;
            }
            else
            {
                Console.WriteLine("False");
                return false;
            }

        }
    }
}
