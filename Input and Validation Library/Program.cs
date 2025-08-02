using Date_Library_Project;
namespace Input_and_Validation_Library
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(clsInputValidate.IsNumberBetween(5, 1, 10));

            Console.WriteLine(clsInputValidate.IsNumberBetween(10.5, 1.5, 10.8));

            Console.WriteLine(clsInputValidate.IsDateBetween(new clsDate(1,1,2022), new clsDate(1,1,2022), new clsDate(1,1,2025)));

            Console.Write("\nEnter an Integer Number Between [1 to 9]: ");
            int number2 = clsInputValidate.ReadIntNumberBetween(1, 9);
            Console.WriteLine("\nnumber: " + number2);
            
            Console.Write("\nEnter a Double Number Between [1.5 to 9.5]: ");
            double number3 = clsInputValidate.ReadDblNumberBetween(1.5, 9.5);
            Console.WriteLine("\nnumber: " + number3);

            Console.WriteLine("\n"+clsInputValidate.IsValidDate(new clsDate(32, 1, 2024)));

        }
    }
}