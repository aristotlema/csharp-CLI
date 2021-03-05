using System;
using System.Collections.Generic;
using System.Linq;

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
            string[] arrOfStrings = input.Split(' ');
            List<string> pigLatinOfStrings = new();

            foreach(string word in arrOfStrings)
            {
                pigLatinOfStrings.Add(PigLatinGenerator(word));
            }

            return string.Join(' ', pigLatinOfStrings);
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
                //If the very first letter is a vowel - place a return statement and exit the function here
                if(count == 0 && LetterTypeChecker(letter) == false)
                {
                    foundFirstVowel = true;
                    startedWithVowel = true;
                    generatedWord = input + "yay";
                    return generatedWord.ToLower();
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

/*            if(startedWithVowel)
            {
                generatedWord += "yay";o
            }*/
                 if(startedWithVowel == false)
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
