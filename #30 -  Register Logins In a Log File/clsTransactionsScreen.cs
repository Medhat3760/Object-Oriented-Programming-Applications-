using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;

namespace Bank_System
{
    public class clsTransactionsScreen : clsScreen
    {

        private enum enTransactionsMenuOptions { eDeposite = 1, eWithdraw = 2, eShowTotalBalances = 3, eShowMainMenu = 4 };

        private static short _ReadTransactionsMenuOption()
        {

            Console.Write("".PadLeft(35) + "Choose what do you want to do [1 to 4]? ");
            short choice = clsInputValidate.ReadShortNumberBetween(1, 4, "Enter Number between 1 to 4? ");

            return choice;

        }

        private static void _ShowDepositeScreen()
        {

            //Console.WriteLine("\nDeposite screen will be here...");

            clsDepositScreen.ShowDepositeScreen();

        }

        private static void _GoBackToTransactionsMenu()
        {

            Console.WriteLine("\n\n" + "".PadLeft(35) + "Press any key to go back to Transactions Menu...");
            Console.ReadKey();

            ShowTransactionsMenu();

        }

        private static void _ShowWithdrawScreen()
        {

            //Console.WriteLine("\nWithdraw screen will be here...");

            clsWithdrawScreen.ShowWithdrawScreen();

        }

        private static void _ShowTotalBalancesScreen()
        {

            //Console.WriteLine("\nTotal Balances screen will be here...");

            clsTotalBalancesScreen.ShowTotalBalancesScreen();

        }

        private static void _PerformTransactionsMenuOption(enTransactionsMenuOptions transactionsMenuOption)
        {

            switch (transactionsMenuOption)
            {

                case enTransactionsMenuOptions.eDeposite:
                    Console.Clear();
                    _ShowDepositeScreen();
                    _GoBackToTransactionsMenu();
                    break;

                case enTransactionsMenuOptions.eWithdraw:
                    Console.Clear();
                    _ShowWithdrawScreen();
                    _GoBackToTransactionsMenu();
                    break;

                case enTransactionsMenuOptions.eShowTotalBalances:
                    Console.Clear();
                    _ShowTotalBalancesScreen();
                    _GoBackToTransactionsMenu();
                    break;

                case enTransactionsMenuOptions.eShowMainMenu:
                    //do nothing here the main screen will handle it :-)
                    break;

            }

        }

        public static void ShowTransactionsMenu()
        {

            if (!_CheckAccessRights(clsUser.enPermissions.pTranactions))
            {
                return; // this will exit the function and it will not continue
            }

            Console.Clear();

            _DrawScreenHeader("\t   Transactions Screen");

            Console.WriteLine("\n" + "".PadLeft(35) + "===================================================");
            Console.WriteLine("".PadLeft(35) + "\t\t   Transactions Menu");
            Console.WriteLine("".PadLeft(35) + "===================================================");

            Console.WriteLine("".PadLeft(35) + "\t[1] Deposite.");
            Console.WriteLine("".PadLeft(35) + "\t[2] Withdraw.");
            Console.WriteLine("".PadLeft(35) + "\t[3] Total Balances.");
            Console.WriteLine("".PadLeft(35) + "\t[4] Main Menu.");

            Console.WriteLine("".PadLeft(35) + "===================================================");

            _PerformTransactionsMenuOption((enTransactionsMenuOptions)_ReadTransactionsMenuOption());

        }

    }
}
