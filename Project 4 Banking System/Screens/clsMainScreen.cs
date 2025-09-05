using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_System.Core;
using Bank_System.Screens.Client;
using MyLib;
using static Bank_System.Globals;
using Bank_System.Screens.User;
using Bank_System.Screens.Currency;

namespace Bank_System.Screens
{
    public class clsMainScreen : clsScreen
    {

        private enum enMainMenuOptions
        {
            eListClient = 1, eAddNewClient = 2, eDeleteClient = 3, eUpdateClient = 4,
            eFindClient = 5, eTransactions = 6, eManageUsers = 7, eLoginRegister = 8, eCurrencyExchange = 9, eExit = 10
        }

        private static short _ReadMainMenuOption()
        {

            Console.Write("".PadLeft(35) + "Choose what do you want to do? [1 to 10]? ");
            short choice = clsInputValidate.ReadShortNumberBetween(1, 10, "Enter Number between 1 to 10? ");

            return choice;

        }

        private static void _GoBackToMainMenu()
        {

            Console.Write("\n\n" + "".PadLeft(35) + "\tPress any key to go back to Main Menu...");
            Console.ReadKey();

            ShowMainMenu();

        }

        private static void _ShowAllClientsScreen()
        {

            //Console.WriteLine("\nClient List Screen Will be here...");

            clsClientListScreen.ShowClientsList();

        }

        private static void _ShowAddNewClientsScreen()
        {

            //Console.WriteLine("\nAdd New Client Screen Will be here...");

            clsAddNewClientScreen.ShowAddNewClientScreen();

        }

        private static void _ShowDeleteClientScreen()
        {

            //Console.WriteLine("\nDelete Client Screen Will be here...");

            clsDeleteClientScreen.ShowDeleteClientScreen();

        }

        private static void _ShowUpdateClientScreen()
        {

            //Console.WriteLine("\nUpdate Client Screen Will be here...");

            clsUpdateClientScreen.ShowUpdateClientScreen();

        }

        private static void _ShowFindClientScreen()
        {

            //Console.WriteLine("\nFind Client Screen Will be here...");

            clsFindClientScreen.ShowFindClientScreen();

        }

        private static void _ShowTransactionsMenu()
        {

            //Console.WriteLine("\nTransactions Menu Will be here...");

            clsTransactionsScreen.ShowTransactionsMenu();

        }

        private static void _ShowManageUsersMenu()
        {

            //Console.WriteLine("\nUsers Menu Will be here...");

            clsManageUsersScreen.ShowManageUsersMenu();

        }

        private static void _ShowLoginRegisterScreen()
        {

            clsLoginRegisterScreen.ShowLoginRegisterScreen();

        }

        private static void _ShowCurrencyExchangeMainScreen()
        {

            clsCurrencyExchangeMainScreen.ShowCurrenciesMenu();

        }

        private static void _Logout()
        {

            currentUser = clsUser.Find("", "");

            //then it will go back to main function.

        }

        private static void _PerformMainMenuOption(enMainMenuOptions mainMenuOption)
        {

            switch (mainMenuOption)
            {

                case enMainMenuOptions.eListClient:
                    Console.Clear();
                    _ShowAllClientsScreen();
                    _GoBackToMainMenu();
                    break;

                case enMainMenuOptions.eAddNewClient:
                    Console.Clear();
                    _ShowAddNewClientsScreen();
                    _GoBackToMainMenu();
                    break;

                case enMainMenuOptions.eDeleteClient:
                    Console.Clear();
                    _ShowDeleteClientScreen();
                    _GoBackToMainMenu();
                    break;

                case enMainMenuOptions.eUpdateClient:
                    Console.Clear();
                    _ShowUpdateClientScreen();
                    _GoBackToMainMenu();
                    break;

                case enMainMenuOptions.eFindClient:
                    Console.Clear();
                    _ShowFindClientScreen();
                    _GoBackToMainMenu();
                    break;

                case enMainMenuOptions.eTransactions:
                    Console.Clear();
                    _ShowTransactionsMenu();
                    _GoBackToMainMenu();
                    break;

                case enMainMenuOptions.eManageUsers:
                    Console.Clear();
                    _ShowManageUsersMenu();
                    _GoBackToMainMenu();
                    break;

                case enMainMenuOptions.eLoginRegister:
                    Console.Clear();
                    _ShowLoginRegisterScreen();
                    _GoBackToMainMenu();
                    break;

                case enMainMenuOptions.eCurrencyExchange:
                    Console.Clear();
                    _ShowCurrencyExchangeMainScreen();
                    _GoBackToMainMenu();
                    break;

                case enMainMenuOptions.eExit:
                    Console.Clear();
                    //_ShowEndScreen();
                    _Logout();
                    break;

            }

        }

        public static void ShowMainMenu()
        {

            Console.Clear();

            _DrawScreenHeader("\t       Main Screen");

            Console.WriteLine("\n" + new string(' ', 35) + "==================================================");
            Console.WriteLine(new string(' ', 35) + "\t\t\tMain Menu");
            Console.WriteLine(new string(' ', 35) + "==================================================");

            Console.WriteLine("".PadLeft(35) + "\t[1] Show Client List.");
            Console.WriteLine("".PadLeft(35) + "\t[2] Add New Client.");
            Console.WriteLine("".PadLeft(35) + "\t[3] Delete Client.");
            Console.WriteLine("".PadLeft(35) + "\t[4] Update Client Info.");
            Console.WriteLine("".PadLeft(35) + "\t[5] Find Client.");
            Console.WriteLine("".PadLeft(35) + "\t[6] Transactions.");
            Console.WriteLine("".PadLeft(35) + "\t[7] Manage Users.");
            Console.WriteLine("".PadLeft(35) + "\t[8] Login Register.");
            Console.WriteLine("".PadLeft(35) + "\t[9] Currency Exchange.");
            Console.WriteLine("".PadLeft(35) + "\t[10] Logout.");

            Console.WriteLine(new string(' ', 35) + "==================================================");

            _PerformMainMenuOption((enMainMenuOptions)_ReadMainMenuOption());

        }

    }
}
