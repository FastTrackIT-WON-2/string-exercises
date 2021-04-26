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

            Console.WriteLine("Nr of vowels=" + nrOfVowels);
        }
    }
}
