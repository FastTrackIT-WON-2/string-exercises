using System;

namespace StringExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Format("{0,-15}{1,-5}{2,7}{3,7}{4,7}",
                            "Produs",
                            "UM",
                            "Pret",
                            "Cant",
                            "Total"));
            PrintProductLine("Paine", "buc", 4, 1);
            PrintProductLine("Cafea", "buc", 7, 2);
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

            Console.WriteLine($"Nr of vowels={nrOfVowels}");
        }

        private static void GetReversedString_And_CheckIfPalindrome()
        {
            string original = "Sator Arepo Tenet Opera Rotas";
            string reversed = Reverse(original);
            bool isPalindrome = IsPalindrome(original);

            Console.WriteLine("Original=" + original);
            Console.WriteLine("Reversed=" + reversed);
            Console.WriteLine("IsPalindrome=" + isPalindrome);
        }

        private static void CountOccurencesOfText()
        {
            int count = NumberOfOccurences("This is a test and another test", "test");
            Console.WriteLine(count);
        }

        private static void ReplaceAndRemoveSubstrings()
        {
            string text = "This is a test and another test.";

            string replaced = text.Replace("test", "test123", StringComparison.OrdinalIgnoreCase);
            Console.WriteLine(replaced);

            string removed = text.Remove(5, 3);
            Console.WriteLine(removed);

            string removed2 = text.Replace("test", "", StringComparison.OrdinalIgnoreCase)
                                  .Replace("  ", " ", StringComparison.OrdinalIgnoreCase)
                                  .Replace(" .", ".", StringComparison.OrdinalIgnoreCase);
            Console.WriteLine(removed2);
        }

        private static void NullOrEmpty_vs_NullOrWhitespaces()
        {
            Console.WriteLine(string.IsNullOrEmpty(null));
            Console.WriteLine(string.IsNullOrEmpty(""));
            Console.WriteLine(string.IsNullOrEmpty("    "));

            Console.WriteLine("-------------------------------");

            Console.WriteLine(string.IsNullOrWhiteSpace(null));
            Console.WriteLine(string.IsNullOrWhiteSpace(""));
            Console.WriteLine(string.IsNullOrWhiteSpace("    "));
        }

        private static int NumberOfOccurences(string text, string substring)
        {
            if (string.IsNullOrEmpty(text))
            {
                return 0;
            }

            if (string.IsNullOrEmpty(substring))
            {
                return 0;
            }

            int nrOfOccurences = 0;

            bool endOfText = false;

            /* Example:
             * ---------------------------------------
             * text = "HelloWorld"
             * substring = "o"
             * ---------------------------------------
             * | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9
             * ---------------------------------------
             * | H | e | l | l | o | W | o | r | l | d
             * ---------------------------------------
             * 1) Caut "substring" incepand de la indexul 0
             * IndexOf(substring, 0) => 4
             *      - incrementam: nr de aparitii
             *      - mutam pozitia de cautare dupa textul gasit:4 + 1 (=substring.Length)
             * 2) Caut "substring" incepand de la indexul 5
             * IndexOf(substring, 5) => 6
             *      - incrementam: nr de aparitii
             *      - mutam pozitia de cautare dupa textul gasit:6 + 1 (=substring.Length)
             * 3) Caut "substring" incepand de la indexul 7
             * IndexOf(substring, 7) => -1
             *      => am terminat (am ajuns la capatul sirului)
             */

            int indexStart = 0;
            while (!endOfText)
            {
                int foundAtIndex = text.IndexOf(substring, indexStart, StringComparison.OrdinalIgnoreCase);
                if (foundAtIndex  >= 0)
                {
                    nrOfOccurences++;
                    indexStart = foundAtIndex + substring.Length;
                }
                else
                {
                    endOfText = true;
                }
            }

            return nrOfOccurences;
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

        private static bool IsPalindrome(string text)
        {
            string reversed = Reverse(text);
            bool isPalyndrome = string.Equals(text, reversed, StringComparison.OrdinalIgnoreCase);
            return isPalyndrome;
        }

        private static void PrintProductLine(
            string productName,
            string um,
            float price,
            float quantity)
        {
            float total = price * quantity;
            /*
            string line = string.Format("{0,-15}{1,-5}{2,7:C}{3,7}{4,7:C}",
                            productName,
                            um,
                            price,
                            quantity,
                            total); */

            string line = $"{productName,-15}{um,-5}{price,7:C}{quantity,7}{total,7:C}";
            Console.WriteLine(line);
        }
    }
}
