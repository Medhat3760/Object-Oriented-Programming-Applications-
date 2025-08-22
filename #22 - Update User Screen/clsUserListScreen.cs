using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    public class clsUserListScreen : clsScreen
    {

        private static void _PrintUserRecordLine(clsUser user)
        {

            Console.Write("".PadLeft(10) + "| " + user.UserName.PadRight(10));
            Console.Write("| " + user.getFullName.PadRight(25));
            Console.Write("| " + user.Phone.PadRight(12));
            Console.Write("| " + user.Email.PadRight(20));
            Console.Write("| " + user.Password.PadRight(9));
            Console.Write("| " + user.Permissions.ToString().PadRight(14));

        }

        public static void ShowUsersList()
        {

            List<clsUser> lUsers = clsUser.GetUsersList();

            string title = "\t    User List Screen";
            string subTitle = $"\t      ({lUsers.Count}) User(s).";

            _DrawScreenHeader(title, subTitle);

            Console.WriteLine("\n" + "".PadLeft(10) + "____________________________________________________________________________________________________\n");

            Console.Write("".PadLeft(10) + "| " + "UserName".PadRight(10));
            Console.Write("| " + "Full Name".PadRight(25));
            Console.Write("| " + "Phone".PadRight(12));
            Console.Write("| " + "Email".PadRight(20));
            Console.Write("| " + "Password".PadRight(9));
            Console.Write("| " + "Permissions".PadRight(14));

            Console.WriteLine("\n" + "".PadLeft(10) + "____________________________________________________________________________________________________\n");

            if (lUsers.Count == 0)
            {

                Console.WriteLine("\n\t\t\t\t\tNo Users Available in the System!");

            }
            else
            {

                foreach (clsUser user in lUsers)
                {

                    _PrintUserRecordLine(user);
                    Console.WriteLine();

                }

            }

            Console.WriteLine("\n" + "".PadLeft(10) + "____________________________________________________________________________________________________\n");


        }

    }
}
