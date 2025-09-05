using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class clsUtil
    {

        public static string ColumnSeparator(int counter)
        {

            if (counter < 10)
            {

                return "   |"; // return a string with 3 spaces followed by a pipe character "|"

            }
            else
            {

                return "  |"; // return a string with 2 spaces followed by a pipe character "|"

            }

        }

        public static string AlignNumberColumn(int number)
        {
            if (number < 10)
                return "     : ";
            else if (number < 100)
                return "    : ";
            else if (number < 1000)
                return "   : ";
            else if (number < 10000)
                return "  : ";
            else if (number < 100000)
                return " : ";
            else
                return ": ";
        }

        public static string FormatCell(string text, short width)
        {

            return text.PadLeft(width); // Aligns the text to the right with the specified width

        }

        public static string Tabs(short numberOfTabs)
        {

            StringBuilder sb = new StringBuilder();

            for (short i = 1; i <= numberOfTabs; i++)
            {
                sb.Append("\t");
            }

            return sb.ToString();

        }

        public static string NewLines(short numberOfLines)
        {

            string newLines = ""; // Initialize an empty string to store the newLines

            for (short i = 0; i < numberOfLines; i++)
            {

                newLines += "\n"; // Append a tab character ("\n") to the string during each iteration

            }

            return newLines; // Return the string with the required number of newLines

        }

        private static Random _random = new Random();

        public static int RandomNumber(int from, int to)
        {

            return _random.Next(from, to + 1);

        }

        public enum enCharType { SmallLetter = 1, CapitalLetter = 2, Digit = 3, MixChar = 4, SpecialCharacter = 5 }

        public static char GetRandomCharacter(enCharType charType)
        {

            if (charType == enCharType.MixChar)
            {
                charType = (enCharType)RandomNumber(1, 3);
            }

            switch (charType)
            {

                case enCharType.SmallLetter:
                    return (char)RandomNumber(97, 122); // ASCII range for lowercase letters

                case enCharType.CapitalLetter:
                    return (char)RandomNumber(65, 90); // ASCII range for uppercase letters

                case enCharType.SpecialCharacter:
                    return (char)RandomNumber(33, 47); // ASCII range for special characters

                case enCharType.Digit:
                    return (char)RandomNumber(48, 57); // ASCII range for digits

                default:
                    return ' ';

            }

        }

        public static string GenerateWord(enCharType charType, short length)
        {

            StringBuilder word = new StringBuilder();

            for (int i = 1; i <= length; i++)
            {

                word.Append(GetRandomCharacter(charType));

            }

            return word.ToString();

        }

        public static string GenerateKey(enCharType charType)
        {

            string key;

            key = GenerateWord(charType, 4) + "-"
                + GenerateWord(charType, 4) + "-"
                + GenerateWord(charType, 4) + "-"
                + GenerateWord(charType, 4);

            return key;

        }

        public static void GenerateKeys(short numberOfKeys, enCharType charType)
        {

            for (int i = 1; i <= numberOfKeys; i++)
            {

                Console.WriteLine($"Key [{i}]" + AlignNumberColumn(i) + GenerateKey(charType));
            }
        }

        public static void Swap<T>(ref T a, ref T b)
        {

            T temp;  // Temporary variable to hold one of the values
            temp = a;  // Store the value of A in Temp
            a = b;     // Assign the value of B to A
            b = temp;  // Assign the value stored in Temp (which is the original A) to B

        }

        public static void ShuffleArray<T>(T[] arr, int arrLength)
        {

            for (int i = 0; i < arrLength; i++)
            {

                Swap(ref arr[i], ref arr[RandomNumber(0, arrLength - 1)]);

            }

        }

        public static void FillArrayWithRandomNumbers(int[] arr, int length, int from, int to)
        {

            for (int i = 0; i < length; i++)
            {

                arr[i] = RandomNumber(from, to);

            }

        }

        public static void FillArrayWithRandomWords(string[] arr, int length, enCharType charType, short wordLength)
        {

            for (int i = 0; i < length; i++)
            {

                arr[i] = GenerateWord(charType, wordLength);

            }

        }

        public static void FillArrayWithRandomKeys(string[] arr, int length, enCharType charType)
        {

            for (int i = 0; i < length; i++)
            {

                arr[i] = GenerateKey(charType);

            }

        }

        public static void AddArrayElement(int number, int[] arr, ref int arrLength)
        {

            arrLength++; //its a new element so we need to increase the array length by 1
            arr[arrLength - 1] = number;

        }

        public static string EncryptText(string text, short encryptionKey = 2)
        {

            char[] arrChar = text.ToCharArray();

            for (int i = 0; i < arrChar.Length; i++)
            {

                arrChar[i] = (char)(arrChar[i] + encryptionKey);

            }

            return new string(arrChar);

        }

        public static string DecryptText(string text, short encryptionKey = 2)
        {

            char[] arrChar = text.ToCharArray();

            for (int i = 0; i < arrChar.Length; i++)
            {

                arrChar[i] = (char)(arrChar[i] - encryptionKey);

            }

            return new string(arrChar);

        }

        public static void SetScreenColor(string message)
        {

            switch (message)
            {

                case "Red":
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White; // Optional: change text color
                    break;
                case "Green":
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "Yellow":
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black; // Black text is easier to read on yellow
                    break;
                case "Blue":
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                default:
                    throw new ArgumentException("Invalid Color");

            }
            // Apply the color change (this affects the console window)
            Console.Clear(); // Clear the console to apply the new background color

        }

        public static string NumberToText(long number)
        {

            if (number < 0)
            {
                return "Negative " + NumberToText(-number);
            }

            if (number == 0)
            {
                return "Zero";
            }

            if (number >= 1 && number <= 19)
            {

                string[] arr = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
                    "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Seventeen", "Eighteen",
                    "Nineteen" };

                return arr[number] + " ";

            }
            else if (number >= 20 && number <= 99)
            {

                string[] arr = { "", "", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty",
                    "Ninety" };

                return arr[number / 10] + "-" + NumberToText(number % 10);

            }
            else if (number >= 100 && number <= 199)
            {

                return "One Hundred " + NumberToText(number % 100);

            }
            else if (number >= 200 && number <= 999)
            {

                return NumberToText(number / 100) + "Hundreds " + NumberToText(number % 100);

            }
            else if (number >= 1000 && number <= 1999)
            {

                return "One Thousand " + NumberToText(number % 1000);

            }
            else if (number >= 2000 && number <= 999999)
            {

                return NumberToText(number / 1000) + "Thousands " + NumberToText(number % 1000);

            }
            else if (number >= 1000000 && number <= 1999999)
            {

                return "One Million " + NumberToText(number % 1000000);

            }
            else if (number >= 2000000 && number <= 999999999)
            {

                return NumberToText(number / 1000000) + "Millions " + NumberToText(number % 1000000);

            }
            else if (number >= 1000000000 && number <= 1999999999)
            {

                return "One Billion " + NumberToText(number % 1000000000);

            }
            else
            {

                return NumberToText(number / 1000000000) + "Billions " + NumberToText(number % 1000000000);

            }

        }

    }
}
