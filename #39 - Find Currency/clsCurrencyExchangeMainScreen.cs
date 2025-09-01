using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;
namespace Bank_System
{
    public class clsCurrencyExchangeMainScreen : clsScreen
    {

        private enum enCurrencyExchangeMenuOption { eListCurrencies = 1, eFindCurrency = 2, eUpdateCurrencyRate = 3,
            eCurrencyCalculator = 4, eMainMenu = 5
        };

        private static short _ReadCurrencyExchangeMenuOption()
        {

            Console.Write($"{"".PadLeft(35)}Choose What do you want to do? [1 to 5]? ");
            return clsInputValidate.ReadShortNumberBetween(1, 5, "Enter Number between 1 to 10? ");

        }

        private static void _ShowCurrenciesListScreen()
        {

            //Console.WriteLine("\nCurrencies List Screen will be here...");

            clsCurrenciesListScreen.ShowCurrenciesList();

        }

        private static void _GoBackToCurrenciesMenu()
        {

            Console.Write($"\n{"".PadLeft(35)}\tPress any key to go back to Currencies Menu. . .");
            Console.ReadKey();

            ShowCurrenciesMenu();

        }

        private static void _ShowFindCurrenciesScreen()
        {

            //Console.WriteLine("\nFind Currencies Screen will be here...");

            clsFindCurrenciesScreen.ShowFindCurrenciesScreen();

        }

        private static void _ShowUpdateCurrencyRateScreen()
        {

            Console.WriteLine("\nUpdate Currency Rate Screen will be here...");

        }

        private static void _ShowCurrencyCalculatorScreen()
        {

            Console.WriteLine("\nCurrency Calculator Screen will be here...");

        }

        private static void _PerformCurrenciesMainMenuOption(enCurrencyExchangeMenuOption currencyExchangeMenuOption)
        {

            switch(currencyExchangeMenuOption)
            {

                case enCurrencyExchangeMenuOption.eListCurrencies:
                    Console.Clear();
                    _ShowCurrenciesListScreen();
                    _GoBackToCurrenciesMenu();
                    break;

                case enCurrencyExchangeMenuOption.eFindCurrency:
                    Console.Clear();
                    _ShowFindCurrenciesScreen();
                    _GoBackToCurrenciesMenu();
                    break;

                case enCurrencyExchangeMenuOption.eUpdateCurrencyRate:
                    Console.Clear();
                    _ShowUpdateCurrencyRateScreen();
                    _GoBackToCurrenciesMenu();
                    break;

                case enCurrencyExchangeMenuOption.eCurrencyCalculator:
                    Console.Clear();
                    _ShowCurrencyCalculatorScreen();
                    _GoBackToCurrenciesMenu();
                    break;

                case enCurrencyExchangeMenuOption.eMainMenu:
                    //do nothing here the main screen will handle it :-)
                    break;

            }

        }

        public static void ShowCurrenciesMenu()
        {

            Console.Clear();

            _DrawScreenHeader("      Currency Exchange Main Screen");

            Console.WriteLine($"\n{"".PadLeft(35)}{new string ('=',50)}");
            Console.WriteLine("".PadLeft(35) + "\t\tCurrency Exchange Menu");
            Console.WriteLine($"{"".PadLeft(35)}{new string('=', 50)}");

            Console.WriteLine("".PadLeft(35) + "\t[1] List Currencies.");
            Console.WriteLine("".PadLeft(35) + "\t[2] Find Currency.");
            Console.WriteLine("".PadLeft(35) + "\t[3] Update Rate.");
            Console.WriteLine("".PadLeft(35) + "\t[4] Currency Calculator.");
            Console.WriteLine("".PadLeft(35) + "\t[5] Main Menu.");

            Console.WriteLine($"{"".PadLeft(35)}{new string('=', 50)}");

            _PerformCurrenciesMainMenuOption((enCurrencyExchangeMenuOption)_ReadCurrencyExchangeMenuOption());

        }

    }
}
