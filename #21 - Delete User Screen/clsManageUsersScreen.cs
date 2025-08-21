using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;

namespace Bank_System
{
    public class clsManageUsersScreen : clsScreen
    {

        enum enManageUsersMenuOptions { eListUsers = 1, eAddNewUser = 2, eDeleteUser = 3, eUpdateUser = 4, eFindUser = 5, eMainMenu = 6 }

        private static short _ReadManageUsersMenuOption()
        {

            Console.Write("".PadLeft(35) + "Choose what do you want to do? [1 to 6]? ");
            short choice = clsInputValidate.ReadShortNumberBetween(1, 6, "Enter Number between 1 to 6? ");

            return choice;

        }

        private static void _ShowListUsersScreen()
        {

            //Console.WriteLine("\nList Users Screen will be here...");

            clsUserListScreen.ShowUsersList();

        }

        private static void _GoBackToManageUsersMenu()
        {

            Console.Write("\n\n" + "".PadLeft(35) + "\tPress any key to go back to Manage Users Menu...");
            Console.ReadKey();

            ShowManageUsersMenu();

        }

        private static void _ShowAddNewUserScreen()
        {

            //Console.WriteLine("\nAdd New Users Screen will be here...");

            clsAddNewUserScreen.ShowAddNewUserScreen();

        }

        private static void _ShowDeleteUserScreen()
        {

            //Console.WriteLine("\nDelete User Screen will be here...");

            clsDeleteUserScreen.ShowDeleteUserScreen();

        }

        private static void _ShowUpdateUserScreen()
        {

            Console.WriteLine("\nUpdate User Screen will be here...");

        }

        private static void _FindUserScreen()
        {

            Console.WriteLine("\nFind User Screen will be here...");


        }

        private static void _PerformManageUsersMenuOption(enManageUsersMenuOptions manageUsersMenuOption)
        {

            switch (manageUsersMenuOption)
            {

                case enManageUsersMenuOptions.eListUsers:
                    Console.Clear();
                    _ShowListUsersScreen();
                    _GoBackToManageUsersMenu();
                    break;

                case enManageUsersMenuOptions.eAddNewUser:
                    Console.Clear();
                    _ShowAddNewUserScreen();
                    _GoBackToManageUsersMenu();
                    break;

                case enManageUsersMenuOptions.eDeleteUser:
                    Console.Clear();
                    _ShowDeleteUserScreen();
                    _GoBackToManageUsersMenu();
                    break;

                case enManageUsersMenuOptions.eUpdateUser:
                    Console.Clear();
                    _ShowUpdateUserScreen();
                    _GoBackToManageUsersMenu();
                    break;

                case enManageUsersMenuOptions.eFindUser:
                    Console.Clear();
                    _FindUserScreen();
                    _GoBackToManageUsersMenu();
                    break;

                case enManageUsersMenuOptions.eMainMenu:
                    //do nothing here the main screen will handle it :-)
                    break;

            }

        }

        public static void ShowManageUsersMenu()
        {

            Console.Clear();

            _DrawScreenHeader("\t  Manage Users Screen");

            Console.WriteLine("\n" + "".PadLeft(35) + "===================================================");
            Console.WriteLine("".PadLeft(35) + "\t\t   Manage Users Menu");
            Console.WriteLine("".PadLeft(35) + "===================================================");

            Console.WriteLine("".PadLeft(35) + "\t[1] List Users.");
            Console.WriteLine("".PadLeft(35) + "\t[2] Add New User.");
            Console.WriteLine("".PadLeft(35) + "\t[3] Delete User.");
            Console.WriteLine("".PadLeft(35) + "\t[4] Update User.");
            Console.WriteLine("".PadLeft(35) + "\t[5] Find User.");
            Console.WriteLine("".PadLeft(35) + "\t[6] Main Menu.");

            Console.WriteLine("".PadLeft(35) + "===================================================");

            _PerformManageUsersMenuOption((enManageUsersMenuOptions)_ReadManageUsersMenuOption());

        }

    }
}
