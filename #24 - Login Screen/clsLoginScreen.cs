using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;
using static Bank_System.Globals;

namespace Bank_System
{
    public class clsLoginScreen : clsScreen
    {

        private static void _Login()
        {

            bool loginFailed = false;

            string userName, password;

            do
            {

                if (loginFailed)
                {
                    Console.WriteLine("\n" + "".PadLeft(40) + "Invalid UserName/Password!");
                }

                Console.Write("\n" + "".PadLeft(40) + "Enter Username? ");
                userName = clsInputValidate.ReadString();

                Console.Write("\n" + "".PadLeft(40) + "Enter Password? ");
                password = clsInputValidate.ReadString();

                currentUser = clsUser.Find(userName, password);

                loginFailed = currentUser.IsEmpty();

            } while (loginFailed);

            clsMainScreen.ShowMainMenu();

        }

        public static void ShowLoginScreen()
        {


            Console.Clear();

            _DrawScreenHeader("\t      Login Screen");

            _Login();

        }

    }
}
