using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Date_Library_Project;
namespace Utility_Library_Project
{
    public class clsUtil
    {

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
  
        public static string Tabs(short numberOfTabs)
        {

            StringBuilder sb = new StringBuilder();

            for(short i =1; i <= numberOfTabs; i++)
            {
                sb.Append("\t");
            }

            return sb.ToString();

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

                Console.WriteLine($"Key [{i}]"+ AlignNumberColumn(i) + GenerateKey(charType));
            }
        }

        public static void Swap(ref int a, ref int b)
        {

            int temp;  // Temporary variable to hold one of the values
            temp = a;  // Store the value of A in Temp
            a = b;     // Assign the value of B to A
            b = temp;  // Assign the value stored in Temp (which is the original A) to B

        }

        public static void Swap(ref double a, ref double b)
        {

            double temp = a;
            a = b;
            b = temp;

        }
        
        public static void Swap(ref string a, ref string b)
        {

            string temp = a;
            a = b;
            b = temp;

        }
        
        public static void Swap(ref char a, ref char b)
        {

            char temp = a;
            a = b;
            b = temp;

        }

        public static void Swap(ref bool a, ref bool b)
        {

            bool temp = a;
            a = b;
            b = temp;

        }

        public static void Swap(ref clsDate a, ref clsDate b)
        {

            clsDate.SwapDates(ref a, ref b);

        }

        public static void ShuffleArray(int[] arr, int arrLength)
        {

            for (int i = 0; i < arrLength; i++)
            {

                Swap(ref arr[i], ref arr[RandomNumber(0, arrLength - 1)]); 

            }

        }

        public static void ShuffleArray(string[] arr, int arrLength)
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

        public static string EncryptText(string text, short encryptionKey)
        {

            char[] arrChar = text.ToCharArray();

            for(int i=0; i < arrChar.Length; i++)
            {

                arrChar[i] =  (char)(arrChar[i] + encryptionKey);

            }

            return new string(arrChar);
            
        }
        
        public static string DecryptText(string text, short encryptionKey)
        {

            char[] arrChar = text.ToCharArray();

            for(int i=0; i < arrChar.Length; i++)
            {

                arrChar[i] =  (char)(arrChar[i] - encryptionKey);

            }

            return new string(arrChar);
            
        }

    }
}
