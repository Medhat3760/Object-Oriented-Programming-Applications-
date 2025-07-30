using Date_Library_Project;
namespace Utility_Library_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(clsUtil.RandomNumber(1, 10));
            Console.WriteLine(clsUtil.GetRandomCharacter(clsUtil.enCharType.MixChar));
            Console.WriteLine(clsUtil.GenerateWord(clsUtil.enCharType.MixChar, 8));
            Console.WriteLine(clsUtil.GenerateKey(clsUtil.enCharType.MixChar));
            clsUtil.GenerateKeys(10, clsUtil.enCharType.MixChar);

            Console.WriteLine();

            int x = 10, y = 20;
            Console.WriteLine(x + " " + y);
            clsUtil.Swap(ref x, ref y);
            Console.WriteLine(x + " " + y);

            Console.WriteLine();

            double a = 10.5, b = 20.5;
            Console.WriteLine(a + " " + b);
            clsUtil.Swap(ref a, ref b);
            Console.WriteLine(a + " " + b);

            Console.WriteLine();

            string s1 = "Ali", s2 = "Ahmed";
            Console.WriteLine(s1 + " " + s2);
            clsUtil.Swap(ref s1, ref s2);
            Console.WriteLine(s1 + " " + s2);

            Console.WriteLine();

            char ch1 = 'A', ch2 = 'B';
            Console.WriteLine(ch1 + " " + ch2);
            clsUtil.Swap(ref ch1, ref ch2);
            Console.WriteLine(ch1 + " " + ch2);

            Console.WriteLine();

            bool flag1 = true, flag2 = false;
            Console.WriteLine(flag1 + " " + flag2);
            clsUtil.Swap(ref flag1, ref flag2);
            Console.WriteLine(flag1 + " " + flag2);

            Console.WriteLine();

            clsDate d1 = new clsDate(1, 10, 2022), d2 = new clsDate(1, 1, 2022);
            Console.WriteLine(d1.DateToString() + " " + d2.DateToString());
            clsUtil.Swap(ref d1, ref d2);
            Console.WriteLine(d1.DateToString() + " " + d2.DateToString());

            // Shuffle Array

            int[] arr1 = { 1, 2, 3, 4, 5 };

            clsUtil.ShuffleArray(arr1, arr1.Length);

            Console.WriteLine("\nArray 1 After Shuffle:");

            for (int i = 0; i < arr1.Length; i++)
            {

                Console.Write(arr1[i] + " ");

            }
            Console.WriteLine();

            string[] arr2 = { "Abdelrahman", "Medhat", "Rushdy", "Tawfik" };

            clsUtil.ShuffleArray(arr2, arr2.Length);

            Console.WriteLine("\nArray 2 After Shuffle:");

            for (int i = 0; i < arr2.Length; i++)
            {

                Console.Write(arr2[i] + " ");

            }
            Console.WriteLine();

            int[] arr3 = new int[10];
            int arrLength = 5;
            clsUtil.FillArrayWithRandomNumbers(arr3, arrLength, 1, 100);

            clsUtil.AddArrayElement(-100, arr3, ref arrLength);

            Console.WriteLine("\nArray 3 After Fill:");

            for (int i = 0; i < arrLength; i++)
            {

                Console.Write(arr3[i] + " ");

            }
            Console.WriteLine();

            string[] arr4 = new string[5];

            clsUtil.FillArrayWithRandomWords(arr4, 5, clsUtil.enCharType.MixChar, 8);

            Console.WriteLine("\nArray 4 After Fill:");

            for (int i = 0; i < 5; i++)
            {

                Console.WriteLine(arr4[i]);

            }

            string[] arr5 = new string[5];

            clsUtil.FillArrayWithRandomKeys(arr5, 5, clsUtil.enCharType.MixChar);

            Console.WriteLine("\nArray 5 After Fill:");

            for (int i = 0; i < 5; i++)
            {

                Console.WriteLine(arr5[i]);

            }

            Console.WriteLine($"\nText1{clsUtil.Tabs(5)}Text2");

            const short encryptionKey = 2;

            string textAfterEncryption, textAfterDecryption;
            string text = "Abdelrahman Medhat";

            textAfterEncryption = clsUtil.EncryptText(text, encryptionKey);
            textAfterDecryption = clsUtil.DecryptText(textAfterEncryption, encryptionKey);

            Console.WriteLine("\nText After Encryption: " + textAfterEncryption);
            Console.WriteLine("Text After Decryption: " + textAfterDecryption);

        }
    }
}