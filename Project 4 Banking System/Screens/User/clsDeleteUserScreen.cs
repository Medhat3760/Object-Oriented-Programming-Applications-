using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_System.Core;
using MyLib;

namespace Bank_System.Screens.User
{
    public class clsDeleteUserScreen : clsScreen
    {

        private static void _PrintUser(clsUser user)
        {

            Console.WriteLine("\nUser Card:");
            Console.WriteLine("________________________________");
            Console.WriteLine($"First Name  : {user.FirstName}");
            Console.WriteLine($"Last Name   : {user.LastName}");
            Console.WriteLine($"Full Name   : {user.getFullName}");
            Console.WriteLine($"Email       : {user.Email}");
            Console.WriteLine($"Phone       : {user.Phone}");
            Console.WriteLine($"User Name   : {user.UserName}");
            Console.WriteLine($"Password    : {user.Password}");
            Console.WriteLine($"Permissions : {user.Permissions}");
            Console.WriteLine("________________________________");

        }

        public static void ShowDeleteUserScreen()
        {

            _DrawScreenHeader("\t   Delete User Screen");

            Console.Write("\nPlease enter User Name? ");
            string userName = clsInputValidate.ReadString();

            while (!clsUser.IsUserExist(userName))
            {

                Console.WriteLine("\nUser is not found, choose another one: ");
                userName = clsInputValidate.ReadString();

            }

            clsUser user1 = clsUser.Find(userName);
            _PrintUser(user1);

            if (clsInputValidate.ReadYesOrNo("\nAre you sure you want to delete this user? (Y/N)? "))
            {

                if (user1.Delete())
                {

                    Console.WriteLine("\nUser Deleted Successfully :-)");
                    _PrintUser(user1);

                }
                else
                {
                    Console.WriteLine("\nError: User is not Deleted.");
                }

            }

        }

    }
}
