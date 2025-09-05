using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class MyGetFunctionLib
    {

        public enum enCharType { SmallLetter = 1, CapitalLetter = 2, SpecialCharacter = 3, Digit = 4 }


        // Random number generator function

        static Random random = new Random(); // Create an instance of Random

        public static int RandomNumber(int from, int to)
        {

            //int randNum = random.Next()%(to-from+1)+from;
            int randNum = random.Next(from, to + 1);  // Inclusive of upper bound

            return randNum;

        }


        // Function to get a random character based on character type
        public static char GetRandomCharacter(enCharType charType)
        {

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
                    //  return ' ';
                    throw new ArgumentException("Invalid Character Type");

            }

        }


        // Function to generate a random word based on char type and length
        public static string GenerateRandomWord(enCharType charType, short length)
        {

            string word = "";

            for (int i = 1; i <= length; i++)
            {

                word += GetRandomCharacter(charType);

            }

            return word;

        }


        // Function to generate a key with the format "AAAA-BBBB-CCCC-DDDD"
        public static string GenerateKey()
        {

            string key = "";

            key = GenerateRandomWord(enCharType.CapitalLetter, 4) + "-";
            key += GenerateRandomWord(enCharType.CapitalLetter, 4) + "-";
            key += GenerateRandomWord(enCharType.CapitalLetter, 4) + "-";
            key += GenerateRandomWord(enCharType.CapitalLetter, 4);

            return key;

        }


        // Procedure to generate multiple keys
        public static void GenerateKeys(short numberOfKeys)
        {

            for (int i = 1; i <= numberOfKeys; i++)
            {

                Console.WriteLine($"Key [{i}] : " + GenerateKey());
            }
        }


        // Function to extract the decimal (fractional) part of any given floating-point number.
        public static float GetFractionPart(float number)
        {
            // Subtract the integer part of the number from the original number to get the fractional part.
            // (int)number converts the float to an integer, discarding the decimal part.
            return number - (int)number;

        }


        // Function to get the reversed number
        public static int ReverseNumber(int number)
        {

            // remainder will hold the last digit of the number
            // number2 will store the reversed number as we build it
            int remainder = 0, number2 = 0;


            while (number > 0) // Loop until the number is reduced to 0
            {

                remainder = number % 10; // Get the last digit of the original number (remainder)
                number = number / 10;    // Remove the last digit from the number by dividing it by 10

                // Build the reversed number by multiplying number2 by 10 (shifting digits leftto make space for the new digit)
                // and adding the remainder (last digit of the original number)
                number2 = number2 * 10 + remainder;

            }

            return number2; // Return the reversed number

        }


        public static int MaxNumberInArray(int[] arr, int arrLength)
        {

            int max = 0;
            max = arr[0];

            for (int i = 0; i < arrLength; i++)
            {

                if (arr[i] > max)
                {
                    max = arr[i];
                }

            }

            return max;

        }


        public static int SecondMaxNumberInArray(int[] arr, int arrLength)
        {

            int max = arr[0], max2 = arr[0];

            for (int i = 0; i < arrLength; i++)
            {

                if (arr[i] > max)
                {
                    max = arr[i];
                }

            }

            if (max == max2)
            {

                max2 = arr[1];

            }

            for (int i = 0; i < arrLength; i++)
            {

                if (arr[i] == max)
                {
                    continue;
                }

                if (arr[i] > max2)
                {

                    max2 = arr[i];
                }

            }

            return max2;

        }


        public static int MinNumberInArray(int[] arr, int arrLength)
        {

            int min = arr[0];

            for (int i = 0; i < arrLength; i++)
            {

                if (arr[i] < min)
                {
                    min = arr[i];
                }

            }

            return min;

        }


        public static int SecondMinNumberInArray(int[] arr, int arrLength)
        {

            int min = arr[0], min2 = arr[0];

            for (int i = 0; i < arrLength; i++)
            {

                if (arr[i] < min)
                {
                    min = arr[i];
                }

            }

            if (min == min2)
            {
                min2 = arr[1];
            }

            for (int i = 0; i < arrLength; i++)
            {

                if (arr[i] == min)
                {
                    continue;
                }

                if (arr[i] < min2)
                {

                    min2 = arr[i];

                }

            }

            return min2;

        }

        public struct stDate
        {

            public short year;
            public short month;
            public short day;

        }

        public static stDate GetSystemDate()
        {

            DateTime now = DateTime.Now;

            stDate date;
            date.year = (short)now.Year;
            date.month = (short)now.Month;
            date.day = (short)now.Day;

            return date;

        }

    }
}
