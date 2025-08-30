using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;

namespace Bank_System
{
    public class clsFindUserScreen : clsScreen
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

        public static void ShowFindUserScreen()
        {

            _DrawScreenHeader("\t     Find User Screen");

            Console.Write("\nPlease enter User Name? ");
            string userName = clsInputValidate.ReadString();

            while (!clsUser.IsUserExist(userName))
            {

                Console.Write("\nUser name is not found, choose another one: ");
                userName = clsInputValidate.ReadString();

            }

            clsUser user1 = clsUser.Find(userName);

            if (!user1.IsEmpty())
            {
                Console.WriteLine("\nUser is Found :-)");
            }
            else
            {
                Console.WriteLine("\nUser is Not Found! :-(");
            }

            _PrintUser(user1);

        }

    }
}
