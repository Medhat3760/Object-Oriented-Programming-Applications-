using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_System.Core;

namespace Bank_System.Screens.Currency
{
    public class clsCurrenciesListScreen : clsScreen
    {

        private static void _PrintCurrencyRecordLine(clsCurrency currency)
        {

            Console.Write("".PadLeft(10) + "| " + currency.Country.PadRight(30));
            Console.Write("| " + currency.CurrencyCode.PadRight(9));
            Console.Write("| " + currency.CurrencyName.PadRight(40));
            Console.Write("| " + currency.Rate.ToString().PadRight(10));

        }

        public static void ShowCurrenciesList()
        {

            List<clsCurrency> lCurrencies = clsCurrency.GetCurrenciesList();

            string title = "\t  Currencies List Screen";
            string subTitle = $"\t    ({lCurrencies.Count}) Currency.";

            _DrawScreenHeader(title, subTitle);

            Console.WriteLine($"\n{"".PadLeft(10)}{new string('_', 100)}\n");

            Console.Write("".PadLeft(10) + "| " + "Country".PadRight(30));
            Console.Write("| " + "Code".PadRight(10));
            Console.Write("| " + "Name".PadRight(40));
            Console.Write("| " + "Rate/(1$)".PadRight(10));

            Console.WriteLine($"\n{"".PadLeft(10)}{new string('_', 100)}\n");

            if (lCurrencies.Count == 0)
            {
                Console.WriteLine("\n\t\t\t\t\tNo Currencies Available in The System!");
            }
            else
            {

                foreach (clsCurrency currency in lCurrencies)
                {

                    _PrintCurrencyRecordLine(currency);

                    Console.WriteLine();

                }

            }

            Console.WriteLine($"\n{"".PadLeft(10)}{new string('_', 100)}\n");

        }

    }
}
