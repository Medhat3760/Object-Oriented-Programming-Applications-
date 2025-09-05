using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class MyDateFunctionLib
    {

        public struct stDate
        {

            public short year;
            public short month;
            public short day;

        }

        public static stDate GetSystemDate()
        {

            DateTime now = DateTime.Now;

            stDate date;
            date.year = (short)now.Year;
            date.month = (short)now.Month;
            date.day = (short)now.Day;

            return date;

        }

        public static short ReadYear()
        {

            short year;

            Console.Write("\nEnter a Year? ");
            year = short.Parse(Console.ReadLine());

            return year;

        }

        public static short ReadMonth()
        {

            short month;

            Console.Write("\nEnter a Month? ");
            month = short.Parse(Console.ReadLine());

            return month;

        }

        public static short ReadDay()
        {

            short day;

            Console.Write("\nEnter a Day? ");
            day = short.Parse(Console.ReadLine());

            return day;

        }

        public static stDate ReadFullDate()
        {

            stDate date;

            date.day = ReadDay();
            date.month = ReadMonth();
            date.year = ReadYear();

            return date;

        }

        public static bool IsLeapYear(short year)
        {

            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);

        }

        public static short NumberOfDaysInAMonth(short month, short year)
        {

            if (month < 1 || month > 12)
            {
                return 0;
            }

            short[] arrNumberOfDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            return (month == 2) ? ((short)(IsLeapYear(year) ? 29 : 28)) : arrNumberOfDays[month - 1];

        }

        public static bool IsLastDayInMonth(stDate date)
        {

            return (date.day == NumberOfDaysInAMonth(date.month, date.year));

        }

        public static bool IsLastMonthInYear(short month)
        {

            return month == 12;

        }

        public static stDate IncreaseDateByOneDay(stDate date)
        {

            if (IsLastDayInMonth(date))
            {

                if (IsLastMonthInYear(date.month))
                {
                    date.year++;
                    date.month = 1;
                    date.day = 1;
                }
                else
                {
                    date.month++;
                    date.day = 1;
                }

            }
            else
            {
                date.day++;
            }

            return date;

        }

        public static stDate IncreaseDateByXDays(stDate date, int days)
        {

            for (int i = 0; i < days; i++)
            {
                date = IncreaseDateByOneDay(date);
            }

            return date;

        }

        public static stDate IncreaseDateByOneWeek(stDate date)
        {
            return IncreaseDateByXDays(date, 7);
        }

        public static stDate IncreaseDateByXWeeks(stDate date, int weeks)
        {

            for (int i = 0; i < weeks; i++)
            {
                date = IncreaseDateByOneWeek(date);
            }

            return date;

        }

        public static stDate IncreaseDateByOneMonth(stDate date)
        {

            if (IsLastMonthInYear(date.month))
            {
                date.year++;
                date.month = 1;
            }
            else
            {
                date.month++;
            }

            short numberOfDaysInCurrentMonth = NumberOfDaysInAMonth(date.month, date.year);

            if (date.day > numberOfDaysInCurrentMonth)
            {
                date.day = numberOfDaysInCurrentMonth;
            }

            return date;

        }

        public static stDate IncreaseDateByXMonths(stDate date, int months)
        {

            for (int i = 0; i < months; i++)
            {
                date = IncreaseDateByOneMonth(date);
            }

            return date;

        }

        public static stDate IncreaseDateByOneYear(stDate date)
        {
            //date.year++;
            //return date;

            return IncreaseDateByXMonths(date, 12);
        }

        public static stDate IncreaseDateByXYears(stDate date, int years)
        {

            for (int i = 0; i < years; i++)
            {
                date = IncreaseDateByOneYear(date);
            }

            return date;

        }

        public static stDate IncreaseDateByXYearsFaster(stDate date, short years)
        {

            date.year += years;

            return date;

        }

        public static stDate IncreaseDateByOneDecade(stDate date)
        {
            //date.year += 10;
            //return date;

            return IncreaseDateByXYears(date, 10);
        }

        public static stDate IncreaseDateByXDecades(stDate date, short decades)
        {

            for (short i = 0; i < decades * 10; i++)
            {
                date = IncreaseDateByOneYear(date);
            }

            return date;

        }

        public static stDate IncreaseDateByXDecadesFaster(stDate date, short decades)
        {

            date.year += (short)(decades * 10);

            return date;

        }

        public static stDate IncreaseDateByOneCentury(stDate date)
        {

            //date.year += 100;
            //return date;

            return IncreaseDateByXDecades(date, 10);
        }

        public static stDate IncreaseDateByOneMillennium(stDate date)
        {
            //date.year += 1000;
            //return date;

            return IncreaseDateByXYears(date, 1000);
        }

    }
}
