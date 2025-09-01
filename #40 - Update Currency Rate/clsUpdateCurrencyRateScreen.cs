using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;

namespace Bank_System
{
    public class clsUpdateCurrencyRateScreen : clsScreen
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

        private static double _ReadRate()
        {

            Console.Write("\nEnter New Rate: ");
            double newRate = clsInputValidate.ReadDblNumber();

            return newRate; 

        }

        public static void ShowUpdateCurrencyRateScreen()
        {

            _DrawScreenHeader("\tUpdate Currency Rate Screen");

            Console.Write("\nPlease Enter Currency Code: ");
            string currencyCode = clsInputValidate.ReadString();

            while(!clsCurrency.IsCurrencyExist(currencyCode))
            {

                Console.Write("\nCurrency is not found, Enter another Code: ");
                currencyCode = clsInputValidate.ReadString();

            }

            clsCurrency currency = clsCurrency.FindByCode(currencyCode);

            _PrintCurrency(currency);

            if (clsInputValidate.ReadYesOrNo("\nAre you sure you want to update this Currency Rate? (Y/N)? "))
            {

                Console.WriteLine("\nUpdate Currency Rate:");
                Console.WriteLine("_________________________");

                currency.UpdateRate(_ReadRate());

                Console.WriteLine("\nCurrency Rate Updated Successfully :-)");
                _PrintCurrency(currency);
                
            }

        }

    }
}
