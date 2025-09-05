using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_System.Core;
using MyLib;

namespace Bank_System.Screens.Currency
{
    public class clsFindCurrenciesScreen : clsScreen
    {

        private static void _PrintCurrency(clsCurrency currency)
        {

            Console.WriteLine("\nCurrency Card:");
            Console.WriteLine("____________________________");

            Console.WriteLine("\nCountry    : " + currency.Country);
            Console.WriteLine("Code       : " + currency.CurrencyCode);
            Console.WriteLine("Name       : " + currency.CurrencyName);
            Console.WriteLine("Rate(1$) = : " + currency.Rate.ToString());

            Console.WriteLine("____________________________");


        }

        private static void _ShowResult(clsCurrency currency)
        {

            if (!currency.IsEmpty())
            {

                Console.WriteLine("\nCurrency is Found :-)");

                _PrintCurrency(currency);

            }
            else
            {
                Console.WriteLine("\nCurrency is NOT Found :-(");
            }

        }

        public static void ShowFindCurrenciesScreen()
        {

            _DrawScreenHeader("\t   Find Currency Screen");

            Console.Write("\nFind By: [1] Code or [2] Country ? ");
            short choice = clsInputValidate.ReadShortNumberBetween(1, 2, "Enter [1] or [2]? ");

            if (choice == 1)
            {

                Console.Write("\nPlease Enter Currency Code: ");
                string currencyCode = clsInputValidate.ReadString();

                clsCurrency currency1 = clsCurrency.FindByCode(currencyCode);

                _ShowResult(currency1);

            }
            else
            {

                Console.Write("\nPlease Enter Country Name: ");
                string country = clsInputValidate.ReadString();

                clsCurrency currency1 = clsCurrency.FindByCountry(country);

                _ShowResult(currency1);

            }

        }

    }
}
