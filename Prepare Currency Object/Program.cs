namespace Prepare_Currency_Object
{
    internal class Program
    {

        private static void _PrintCurrency(clsCurrency currency)
        {

            Console.WriteLine("\nCurrency Card:");
            Console.WriteLine("______________________");

            Console.WriteLine("\nCountry    : " + currency.Country);
            Console.WriteLine("Code       : " + currency.CurrencyCode);
            Console.WriteLine("Name       : " + currency.CurrencyName);
            Console.WriteLine("Rate(1$) = : " + currency.Rate.ToString());

            Console.WriteLine("______________________");

        }

        static void Main(string[] args)
        {

            clsCurrency currency1 = clsCurrency.FindByCode("jod");

            if (currency1.IsEmpty())
            {
                Console.WriteLine("\nCurrency Not Found! :-(");
            }
            else
            {
                _PrintCurrency(currency1);
            }

            clsCurrency currency2 = clsCurrency.FindByCountry("egypt");

            if (currency2.IsEmpty())
            {
                Console.WriteLine("\nCurrency Not Found! :-(");
            }
            else
            {
                _PrintCurrency(currency2);
            }

            Console.WriteLine("\nCurrency1 After Updating Rate:");

            currency1.UpdateRate(0.71);

            _PrintCurrency(currency1);

        }
    }
}