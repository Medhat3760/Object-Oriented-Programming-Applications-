using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;
namespace Bank_System
{
    public class clsScreen
    {

        protected static void _DrawScreenHeader(string title, string subTitle = "")
        {

            Console.WriteLine(clsUtil.Tabs(5)+ new string('_',40));
            Console.WriteLine($"\n{clsUtil.Tabs(5)}{title}");

            if(subTitle != "")
            {
                Console.WriteLine($"{clsUtil.Tabs(5)}{subTitle}");               
            }

            Console.WriteLine(clsUtil.Tabs(5) + new string('_', 40));



        }

    }
}
