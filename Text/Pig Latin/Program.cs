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

            //To do - fix input to upper
            Console.WriteLine(PigLatinGenerator("DREDGER"));
            Console.ReadKey();
        }

        static string PigLatinGenerator(string input)
        {
            string generatedWord = "";
            string letterDataStore = "";
            bool foundFirstVowel = false;

            Console.WriteLine(input);

            foreach(char letter in input)
            {
                //if letter is a consonant
                if (LetterTypeChecker(letter) && foundFirstVowel == false)
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
            generatedWord += letterDataStore + "ay";
            return generatedWord;
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


        //Just to verify my variables haven't changed
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
