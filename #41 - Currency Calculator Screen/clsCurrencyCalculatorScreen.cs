using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;

namespace Bank_System
{
    public class clsCurrencyCalculatorScreen : clsScreen
    {

        private static clsCurrency _GetCurrency(string message)
        {

            Console.Write(message);
            string currencyCode = clsInputValidate.ReadString();

            while (!clsCurrency.IsCurrencyExist(currencyCode))
            {

                Console.Write("\nCurrency is not found, Enter another Code: ");
                currencyCode = clsInputValidate.ReadString();

            }

            return clsCurrency.FindByCode(currencyCode);

        }

        private static double _ReadAmount()
        {

            Console.Write("\nEnter Amount to Exchange: ");
            double amount = clsInputValidate.ReadPositiveDblNumber();

            return amount;

        }

        private static void _PrintCurrencyCard(clsCurrency currency, string title)
        {

            Console.WriteLine($"\n{title}");
            Console.WriteLine("____________________________");

            Console.WriteLine("\nCountry    : " + currency.Country);
            Console.WriteLine("Code       : " + currency.CurrencyCode);
            Console.WriteLine("Name       : " + currency.CurrencyName);
            Console.WriteLine("Rate(1$) = : " + currency.Rate.ToString());

            Console.WriteLine("____________________________");

        }

        private static void _PrintCalculationResults(double amount, clsCurrency currencyFrom, clsCurrency currencyTo)
        {

            _PrintCurrencyCard(currencyFrom, "Convert From:");

            double amountInUSD = currencyFrom.ConvertToUSD(amount);

            Console.WriteLine($"\n{amount} {currencyFrom.CurrencyCode} = {amountInUSD} USD");

            if (currencyTo.CurrencyCode == "USD")
            {
                return;
            }

            Console.WriteLine("\nConverting From USD");
            _PrintCurrencyCard(currencyTo, "To:");

            double amountInCurrency2 = currencyFrom.ConvertToAnotherCurrency(amount, currencyTo);

            Console.WriteLine($"\n{amount} {currencyFrom.CurrencyCode} = {amountInCurrency2} {currencyTo.CurrencyCode}");
        
        }

        public static void ShowCurrencyCalculatorScreen()
        {

            do
            {

                Console.Clear();

                _DrawScreenHeader("\tCurrency Calculator Screen");

                clsCurrency currencyFrom = _GetCurrency("\nPlease Enter Currency1 Code: ");
                clsCurrency currencyTo = _GetCurrency("\nPlease Enter Currency2 Code: ");

                double amount = _ReadAmount();

                _PrintCalculationResults(amount, currencyFrom, currencyTo);

            } while (clsInputValidate.ReadYesOrNo("\nDo you want to perform another calculation? (Y/N)? "));

        }

    }
}
