using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;
namespace Bank_System
{
    public class clsMainScreen : clsScreen
    {

        private enum enMainMenuOptions
        {
            eListClient = 1, eAddNewClient = 2, eDeleteClient = 3, eUpdateClient = 4,
            eFindClient = 5, eTransactions = 6, eManageUsers = 7, eExit = 8
        }

        private static short _ReadMainMenuOption()
        {

            Console.Write("".PadLeft(35) + "Choose what do you want to do? [1 to 8]? ");
            short choice = clsInputValidate.ReadShortNumberBetween(1, 8, "Enter Number between 1 to 8? ");

            return choice;

        }

        private static void _GoBackToMainMenu()
        {

            Console.Write("\n" + "".PadLeft(35) + "\tPress any key to go back to Main Menu...");
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

            Console.WriteLine("\nAdd New Client Screen Will be here...");

        }

        private static void _ShowDeleteClientScreen()
        {

            Console.WriteLine("\nDelete Client Screen Will be here...");

        }
        
        private static void _ShowUpdateClientScreen()
        {

            Console.WriteLine("\nUpdate Client Screen Will be here...");

        }
        
        private static void _ShowFindClientScreen()
        {

            Console.WriteLine("\nFind Client Screen Will be here...");

        }
        
        private static void _ShowTransactionsMenu()
        {

            Console.WriteLine("\nTransactions Menu Will be here...");

        }
        
        private static void _ShowManageUsersMenu()
        {

            Console.WriteLine("\nUsers Menu Will be here...");

        }
        
        private static void _ShowEndScreen()
        {

            Console.WriteLine("\nEnd Screen Will be here...");

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
                    break;

                case enMainMenuOptions.eManageUsers:
                    Console.Clear();
                    _ShowManageUsersMenu();
                    break;

                case enMainMenuOptions.eExit:
                    Console.Clear();
                    _ShowEndScreen();
                    //Login();
                    break;

            }

        }

        public static void ShowMainMenu()
        {

            Console.Clear();

            _DrawScreenHeader("\t\tMain Screen");

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
            Console.WriteLine("".PadLeft(35) + "\t[8] Logout.");

            Console.WriteLine(new string(' ', 35) + "==================================================");

            _PerformMainMenuOption((enMainMenuOptions)_ReadMainMenuOption());

        }

    }
}
