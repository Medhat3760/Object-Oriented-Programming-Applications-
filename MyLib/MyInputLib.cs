namespace MyLib
{

    public class MyInputLib
    {

        public static int ReadIntNumber(string message)
        {

            Console.WriteLine(message);
            int num = int.Parse(Console.ReadLine());

            return num;

        }

        public static int ReadPositiveNumber(string message)
        {

            int num = 0; 

            do
            {

                Console.WriteLine(message);
                num = int.Parse(Console.ReadLine());

            } while (num <= 0);

            return num;

        }

        public static int ReadNumberInRange(int from, int to, string message)
        {

            int num = 0;
            do
            {

                Console.WriteLine(message);
                num = int.Parse(Console.ReadLine());

            } while (num < from || num > to);

            return num;

        }

        // Procedure to read an array from user input
        public static void ReadIntArray(int[] arr, ref int arrLength)
        {

            Console.WriteLine("Enter number of elements ?");
            arrLength = int.Parse(Console.ReadLine()); // Get array length

            Console.WriteLine("\nEnter array elements:\n");

            for (int i = 0; i < arrLength; i++)
            {

                Console.Write($"Element [{i + 1}] : ");
                arr[i] = int.Parse(Console.ReadLine()); // Read each element

            }
            Console.WriteLine(); // Print new line after reading input

        }

        public static void ReadStringArray(string[] arr, ref int arrLength)
        {

            Console.WriteLine("Enter number of elements ?");
            arrLength = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter array elements :\n");

            for (int i = 0; i < arrLength; i++)
            {

                Console.Write($"Element [{i + 1}] : ");
                arr[i] = Console.ReadLine();

            }
            Console.WriteLine();

        }

    }

}