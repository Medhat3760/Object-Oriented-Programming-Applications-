using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;

namespace Bank_System
{
    public class clsLoginRegisterScreen : clsScreen
    {

        private static void _PrintLoginRegisterRecordLine(clsUser.stLoginRegisterRecord record)
        {

            Console.Write($"{"".PadLeft(10)}| {record.dateTime.PadRight(21)}");
            Console.Write($"{"".PadLeft(10)}| {record.userName.PadRight(15)}");
            Console.Write($"{"".PadLeft(10)}| {record.password.PadRight(15)}");
            Console.Write($"{"".PadLeft(10)}| {record.permissions.ToString().PadRight(12)}");

        }

        public static void ShowLoginRegisterScreen()
        {

            if(!_CheckAccessRights(clsUser.enPermissions.pShowLogRegister))
            {
                return;
            }

            List<clsUser.stLoginRegisterRecord> listLoginRegisterRecord = clsUser.GetLoginRegisterList();

            string title = "\tLogin Register List Screen";
            string subTitle = $"\t      ({listLoginRegisterRecord.Count}) Record(s).";

            _DrawScreenHeader(title, subTitle);

            Console.WriteLine($"\n{"".PadLeft(10)}{new string('_', 100)}\n");

            Console.Write($"{"".PadLeft(10)}| {"Date/Time".PadRight(21)}");
            Console.Write($"{"".PadLeft(10)}| {"User Name".PadRight(15)}");
            Console.Write($"{"".PadLeft(10)}| {"Password".PadRight(15)}");
            Console.Write($"{"".PadLeft(10)}| {"Permissions".PadRight(12)}");

            Console.WriteLine($"\n{"".PadLeft(10)}{new string('_', 100)}\n");


            if (listLoginRegisterRecord.Count == 0)
            {
                Console.WriteLine("\n"+clsUtil.Tabs(4)+"No Logins Available in The System!");
            }
            else
            {

                foreach(clsUser.stLoginRegisterRecord record in listLoginRegisterRecord)
                {

                    _PrintLoginRegisterRecordLine(record);

                    Console.WriteLine();

                }

            }

            Console.WriteLine($"\n{"".PadLeft(10)}{new string('_', 100)}\n");

        }

    }
}
