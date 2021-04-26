using System;

namespace StringExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            string original = "VisualStudio";
            string reversed = Reverse(original);

            Console.WriteLine("Original=" + original);
            Console.WriteLine("Reversed=" + reversed);
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

        private static string Reverse(string text)
        {
            char[] reversed = new char[text.Length];

            /* 
             *  index =>          | Length (=5)
             * --------------------------------
             *  0 | 1 | 2 | 3 | 4 |
             * --------------------------------
             *  H | e | l | l | o |
             * --------------------------------
             *    |   |   |   |   |
             * --------------------------------
             * 1) when Index = 0 => 4 (Length - index - 1)
             * 2) when Index = 1 => 3 (Length - index - 1)
             * 3) when Index = 2 => 2 (Length - index - 1)
             * 4) when Index = 3 => 1 (Length - index - 1)
             * 5) when Index = 4 => 0 (Length - index - 1)
             */

            for (int index = 0; index < text.Length; index++)
            {
                char c = text[index];
                int indexInReversed = text.Length - index - 1;

                reversed[indexInReversed] = c;
            }

            return new string(reversed);
        }
    }
}
