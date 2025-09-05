using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class MyPrintLib
    {

        public static void PrintIntArray(int[] arr, int arrLength)
        {

            Console.WriteLine("Array elements:\n");

            for (int i = 0; i < arrLength; i++)
            {

                Console.Write(arr[i] + " "); // Print each element followed by a space

            }
            Console.WriteLine("\n"); // Move to the next line after printing the array

        }

        public static void PrintStringArray(string[] arr, int arrLength)
        {

            Console.WriteLine("\nArray Elements:\n");

            // Loop through the array and print each element
            for (int i=0; i < arrLength; i++)
            {

                Console.WriteLine($"Array[{i}] : {arr[i]}");

            }
            Console.WriteLine();

        }

    }
}
