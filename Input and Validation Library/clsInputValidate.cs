using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Date_Library_Project;
using Utility_Library_Project;

namespace Input_and_Validation_Library
{
    public class clsInputValidate
    {

        public static bool IsNumberBetween(int number, int from, int to)
        {

            return number >= from && number <= to;

        }
        
        public static bool IsNumberBetween(double number, double from, double to)
        {

            return number >= from && number <= to;

        }
        
        public static bool IsDateBetween(clsDate date, clsDate dateFrom, clsDate dateTo)
        {

            if(!clsDate.IsDate1BeforeDate2(dateFrom, dateTo))
            {
                clsUtil.Swap(ref dateFrom, ref dateTo);
            }
            
            return !(clsDate.IsDate1BeforeDate2(date, dateFrom)||clsDate.IsDate1AfterDate2(date, dateTo));

        }
        
        public static int ReadIntNumber(string errorMessage  = "Invalid Number, Enter again?")
        {

            int number;

            while(!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine(errorMessage);
            }

            return number;

        }

        public static int ReadIntNumberBetween(int from, int to, string errorMessage = "Number is not Within range, Enter again:")
        {
            int number = ReadIntNumber();

            while (!IsNumberBetween(number, from, to))
            {

                Console.WriteLine(errorMessage);

                number = ReadIntNumber();

            }
            return number;
        }

        public static double ReadDblNumber(string errorMessage  = "Invalid Number, Enter again? ")
        {

            double number;

            while(!double.TryParse(Console.ReadLine(), out number) /*|| number == (int)number*/)
            {
                Console.WriteLine(errorMessage);
            }

            return number;

        }

        public static double ReadDblNumberBetween(double from, double to, string errorMessage = "Number is not Within range, Enter again:")
        {

            double number = ReadDblNumber();

            while (!IsNumberBetween(number, from, to))
            {

                Console.WriteLine(errorMessage);

                number = ReadDblNumber();

            }

            return number;

        }

        public static bool IsValidDate(clsDate date)
        {

            return date.IsValidDate();

        }



    }
}
