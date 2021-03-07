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
            Checker();

            Console.WriteLine(StringDeconstructor("Bananas are good as shoes"));

            Console.WriteLine("What do you want to conver to Pig Latin");
            string userInput = Console.ReadLine();

            Console.WriteLine(StringDeconstructor(userInput));
            
            Console.ReadKey();
        }

        // Splits words into an array of strings and feeds each item into Pig Latin generator
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

            //If first letter is vowel, return
            if(LetterTypeChecker(upperInput[0]) == false)
            {
                return input.ToLower() + "-yay";
            }
            else
            {
                // loop throught input word. shave off letters and add to letterDataStore until first vowel is found, then all letters are added to the generated word and returned summed
                foreach (char letter in upperInput)
                {
                    if(LetterTypeChecker(letter) && foundFirstVowel == false)
                    {
                        letterDataStore += letter;
                    }
                    else if (LetterTypeChecker(letter) == false || foundFirstVowel)
                    {
                        foundFirstVowel = true;
                        generatedWord += letter;
                    }
                    else
                        Console.WriteLine("Out of bounds parameter");
                }
                return (generatedWord + "-" + letterDataStore + "ay").ToLower();
            }
        }
        public static bool LetterTypeChecker(char letterCheck)
        {
            if (consonant.Contains(letterCheck))
                return true;
            else if (vowel.ToUpper().Contains(letterCheck))
                return false;
            // return false because we do not want to move any characters outside of alphabet.
            else
                Console.WriteLine("either a critial error occured, or non-alphabetic character was entered");
                return false;
        }
        //Debug to verify my variables haven't changed
        public static void Checker()
        {
            int count = 0;
            foreach(char letter in vowel) count++;
            foreach(char letter in consonant) count++;
            if (count != 26)
            {
                Console.WriteLine("Variables have been broken");
            }
                
        }
    }
}
