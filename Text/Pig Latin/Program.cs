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

        static string PigLatinGenerator(string input)
        {
            string upperInput = input.ToUpper();

            string generatedWord = "";
            string letterDataStore = "";
            bool foundFirstVowel = false;
            bool startedWithVowel = false;

            Console.WriteLine(input);

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

        // TO DO - Issue with returning the last word correctly
        static string StringDeconstructor(string input)
        {
            int count = 0;

            Console.WriteLine(input.Length);

            string currentWord = "";
            string currentSentance = "";
            foreach(char letter in input)
            {
                

                if (letter == ' ' || count > input.Length)
                {
                    currentWord = PigLatinGenerator(currentWord);
                    currentSentance += currentWord + " ";
                    currentWord = "";
                }
                else if (letter != ' ')
                {

                    currentWord += letter;
                }

                count++;
            }
            return currentSentance;
        }


        public static bool LetterTypeChecker(char letterCheck)
        {
            if (consonant.Contains(letterCheck))
                return true;
            else if (vowel.Contains(letterCheck))
                return false;
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
