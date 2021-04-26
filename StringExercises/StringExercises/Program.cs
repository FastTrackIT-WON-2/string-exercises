using System;

namespace StringExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            CountVowels();
        }

        private static void CountVowels()
        {
            /*
             * We read a string from console / keyboard
             * Problem: how many vowels are in the read text?
            */

            Console.Write("Please enter the text:");
            string text = Console.ReadLine();

            int nrOfVowels = 0;
            for (int index = 0; index < text.Length; index++)
            {
                char c = text[index];
                bool isVowel =  c == 'a' ||
                                c == 'e' ||
                                c == 'i' ||
                                c == 'o' ||
                                c == 'u';

                if (isVowel)
                {
                    nrOfVowels++;
                }
            }

            /*
             * Or using foreach:
             * 
            foreach (char c in text)
            {
                bool isVowel = c == 'a' ||
                                c == 'e' ||
                                c == 'i' ||
                                c == 'o' ||
                                c == 'u';

                if (isVowel)
                {
                    nrOfVowels++;
                }
            }
            */

            Console.WriteLine("Nr of vowels=" + nrOfVowels);
        }

        private static bool IsNumber(string text)
        {
            /*
             * Considering a text, return a flag that is true if the text represents a number,
             * or false otherwise.
             */

            // int.MaxValue = 2147483647;
            // long.MaxValue = 9223372036854775807

            bool isNumber = long.TryParse(text, out long result);

            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
