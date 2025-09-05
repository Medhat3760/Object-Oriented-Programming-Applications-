using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_System.Core;
using MyLib;
using static Bank_System.Globals;
namespace Bank_System.Screens
{
    public class clsScreen
    {

        protected static void _DrawScreenHeader(string title, string subTitle = "")
        {

            Console.WriteLine(clsUtil.Tabs(5) + new string('_', 40));
            Console.WriteLine($"\n{clsUtil.Tabs(5)}{title}");

            if (subTitle != "")
            {
                Console.WriteLine($"{clsUtil.Tabs(5)}{subTitle}");
            }

            Console.WriteLine(clsUtil.Tabs(5) + new string('_', 40));

            Console.WriteLine($"\n{clsUtil.Tabs(5)}{"User: "}{currentUser.UserName}");
            Console.WriteLine($"{clsUtil.Tabs(5)}{"Date: "}{clsDate.DateToString(new clsDate())}");

        }

        protected static bool _CheckAccessRights(clsUser.enPermissions permission)
        {

            if (!currentUser.CheckAccessPermission(permission))
            {

                Console.WriteLine(clsUtil.Tabs(5) + new string('_', 40));
                Console.WriteLine($"\n{clsUtil.Tabs(5)}{"   Access Denied!, Contact your Admin."}");
                Console.WriteLine(clsUtil.Tabs(5) + new string('_', 40));

                return false;

            }

            return true;

        }

    }
}
