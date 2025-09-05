using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class MyProcedureLib
    {

        // Procedure to change console colors based on the message
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


        // Function to swap two integers
        public static void SwapNumbers(ref int a, ref int b)
        {

            int temp;  // Temporary variable to hold one of the values
            temp = a;  // Store the value of A in Temp
            a = b;     // Assign the value of B to A
            b = temp;  // Assign the value stored in Temp (which is the original A) to B

        }


        // Procedure to add an element to the array
        public static void AddArrayElement(int number, int[] arr, ref int arrLength)
        {

            arrLength++; //its a new element so we need to increase the array length by 1
            arr[arrLength - 1] = number;

        }


        public static void FillArrayWithRandomNumbers(int[] arr, ref int arrLength)
        {

            arrLength = MyInputLib.ReadPositiveNumber("How many items do you want to fill ?");

            for (int i = 0; i < arrLength; i++)
            {

                arr[i] = MyGetFunctionLib.RandomNumber(-100, 100);

            }

        }

    }
}
