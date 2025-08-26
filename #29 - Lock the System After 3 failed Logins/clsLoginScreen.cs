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

        private const short _MAX_TRIALS = 3;

        private static bool _Login()
        {

            bool isLoginFailed = false;

            string userName, password;

            short remainingTrials = _MAX_TRIALS;

            do
            {

                if (isLoginFailed)
                {

                    remainingTrials--;

                    Console.WriteLine("\n" + "".PadLeft(40) + "Invalid UserName/Password!");
                    Console.WriteLine($"{"".PadLeft(40)}You have {remainingTrials} trial(s) to login.");

                }

                if(remainingTrials == 0)
                {

                    Console.WriteLine($"\n{"".PadLeft(40)}You are locked after {_MAX_TRIALS} failed trial(s).");
                    return false;

                }

                Console.Write("\n" + "".PadLeft(40) + "Enter Username? ");
                userName = clsInputValidate.ReadString();

                Console.Write("\n" + "".PadLeft(40) + "Enter Password? ");
                password = clsInputValidate.ReadString();

                currentUser = clsUser.Find(userName, password);

                isLoginFailed = currentUser.IsEmpty();

            } while (isLoginFailed);

            clsMainScreen.ShowMainMenu();

            return true;

        }

        public static bool ShowLoginScreen()
        {

            Console.Clear();

            _DrawScreenHeader("\t      Login Screen");

            return _Login();

        }

    }
}
