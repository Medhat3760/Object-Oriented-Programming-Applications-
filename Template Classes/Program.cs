namespace Template_Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Calculator<int> intCalc = new Calculator<int>(2, 1);
            Calculator<float> floatCalc = new Calculator<float>(2.4f, 1.2f);

            Console.WriteLine("\nInt Results:");
            intCalc.PrintResults();

            Console.WriteLine("\nFloat Results:");
            floatCalc.PrintResults();   

        }
    }
}