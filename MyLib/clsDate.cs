using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class clsDate
    {

        private short _day;
        private short _month;
        private short _year;

        public clsDate()
        {

            DateTime now = DateTime.Now;

            _day = (short)now.Day;
            _month = (short)now.Month;
            _year = (short)now.Year;

        }

        public clsDate(short day, short month, short year)
        {

            _day = day;
            _month = month;
            _year = year;

        }

        public clsDate(string stringDate)
        {

            List<string> lDate = clsString.Split(stringDate, "/");

            _day = short.Parse(lDate[0]);
            _month = short.Parse(lDate[1]);
            _year = short.Parse(lDate[2]);

        }

        public clsDate(short dayOrderInYear, short year)
        {

            clsDate date = GetDateFromDayOrderInAYear(dayOrderInYear, year);

            _day = date.Day;
            _month = date.Month;
            _year = date.Year;

        }

        public short Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public short Month
        {
            get { return _month; }
            set { _month = value; }
        }

        public short Day
        {
            get { return _day; }
            set { _day = value; }
        }

        public static string DateToString(clsDate date)
        {
            return $"{date.Day}/{date.Month}/{date.Year}";
        }

        public string DateToString()
        {
            return DateToString(this);
        }

        public void Print()
        {
            Console.WriteLine(DateToString());
        }

        public static clsDate GetSystemDate()
        {

            DateTime now = DateTime.Now;

            short day = (short)now.Day;
            short month = (short)now.Month;
            short year = (short)now.Year;

            return new clsDate(day, month, year);

        }
        
        public static string GetSystemDateTimeString()
        {

            DateTime now = DateTime.Now;

            short day = (short)now.Day;
            short month = (short)now.Month;
            short year = (short)now.Year;
            short hour = (short)now.Hour;
            short minute = (short)now.Minute;
            short second = (short)now.Second;

            return $"{day}/{month}/{year} - {hour}:{minute}:{second}";

        }

        public static bool IsValidDate(clsDate date)
        {

            if (date.Year < 1)
            {
                return false;
            }

            if (date.Month < 1 || date.Month > 12)
            {
                return false;
            }

            short daysInMonth = NumberOfDaysInAMonth(date.Month, date.Year);

            if (date.Day < 1 || date.Day > daysInMonth)
            {
                return false;
            }

            return true;

        }

        public bool IsValidDate()
        {
            return IsValidDate(this);
        }

        public static bool IsLeapYear(short year)
        {
            return (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
        }

        public bool IsLeapYear()
        {
            return IsLeapYear(_year);
        }

        public static short NumberOfDaysInAYear(short year)
        {
            return IsLeapYear(year) ? (short)366 : (short)365;
        }

        public short NumberOfDaysInAYear()
        {
            return NumberOfDaysInAYear(_year);
        }

        public static short NumberOfHoursInAYear(short year)
        {
            return (short)(NumberOfDaysInAYear(year) * 24);
        }

        public short NumberOfHoursInAYear()
        {
            return NumberOfHoursInAYear(_year);
        }

        public static int NumberOfMinutesInAYear(short year)
        {
            return NumberOfHoursInAYear(year) * 60;
        }

        public int NumberOfMinutesInAYear()
        {
            return NumberOfMinutesInAYear(_year);
        }

        public static int NumberOfSecondsInAYear(short year)
        {
            return NumberOfMinutesInAYear(year) * 60;
        }

        public int NumberOfSecondsInAYear()
        {
            return NumberOfSecondsInAYear(_year);
        }

        public static short NumberOfDaysInAMonth(short month, short year)
        {

            if (month < 1 || month > 12)
            {
                return 0;
            }

            short[] arrNumberOfDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            return (month == 2) ? (IsLeapYear(year) ? (short)29 : (short)28) : arrNumberOfDays[month - 1];

        }

        public short NumberOfDaysInAMonth()
        {
            return NumberOfDaysInAMonth(_month, _year);
        }

        public static short NumberOfHoursInAMonth(short month, short year)
        {
            return (short)(NumberOfDaysInAMonth(month, year) * 24);
        }

        public short NumberOfHoursInAMonth()
        {
            return NumberOfHoursInAMonth(_month, _year);
        }

        public static int NumberOfMinutesInAMonth(short month, short year)
        {
            return NumberOfHoursInAMonth(month, year) * 60;
        }

        public int NumberOfMinutesInAMonth()
        {
            return NumberOfMinutesInAMonth(_month, _year);
        }

        public static int NumberOfSecondsInAMonth(short month, short year)
        {
            return NumberOfMinutesInAMonth(month, year) * 60;
        }

        public int NumberOfSecondsInAMonth()
        {
            return NumberOfSecondsInAMonth(_month, _year);
        }

        public static short GetDayOfWeekOrder(short day, short month, short year)
        {

            short d, a, y, m;

            a = (short)((14 - month) / 12);
            y = (short)(year - a);
            m = (short)(month + 12 * a - 2);

            d = (short)((day + y + (y / 4) - (y / 100) + (y / 400) + ((31 * m) / 12)) % 7);

            return d;

        }

        public short GetDayOfWeekOrder()
        {
            return GetDayOfWeekOrder(_day, _month, _year);
        }

        public static string GetDayShortName(short dayOrder)
        {

            string[] arrDayNames = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            return arrDayNames[dayOrder];

        }

        public static string GetDayShortName(short day, short month, short year)
        {

            string[] arrDayNames = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            return arrDayNames[GetDayOfWeekOrder(day, month, year)];

        }

        public string GetDayShortName()
        {
            return GetDayShortName(_day, _month, _year);
        }

        public static string GetMonthShortName(short month)
        {

            string[] arrMonthNames = { "Jan", "Feb", "Mar", "Apr", "May", "Jun",
                                       "jul", "Aug" ,"Sep" ,"Oct" ,"Nov" ,"Dec" };

            return arrMonthNames[month - 1];

        }

        public string GetMonthShortName()
        {
            return GetMonthShortName(_month);
        }

        public static void PrintMonthCalender(short month, short year)
        {

            short current = GetDayOfWeekOrder(1, month, year);

            short numberOfDays = NumberOfDaysInAMonth(month, year);

            Console.WriteLine($"\n  __________________{GetMonthShortName(month)}____________\n");

            Console.WriteLine("  Sun  Mon  Tue  Wed  Thu  Fri  Sat");

            short i;
            for (i = 0; i < current; i++)
            {

                Console.Write("     ");
            }

            for (short j = 1; j <= numberOfDays; j++)
            {

                Console.Write($"{j,5}");

                if (++i == 7)
                {

                    i = 0;
                    Console.WriteLine();

                }

            }

            Console.WriteLine("\n  _________________________________\n");

        }

        public void PrintMonthCalender()
        {
            PrintMonthCalender(_month, _year);
        }

        public static void PrintYearCalendar(short year)
        {

            Console.WriteLine("\n  _________________________________\n");
            Console.WriteLine($"\t  Calendar - {year}");
            Console.WriteLine("  _________________________________\n");

            for (short i = 1; i <= 12; i++)
            {

                PrintMonthCalender(i, year);

            }

        }

        public void PrintYearCalendar()
        {
            PrintYearCalendar(_year);
        }

        public static short GetDaysFromTheBeginingOfTheYear(clsDate date)
        {

            short numOfDays = 0;

            for (short i = 1; i < date.Month; i++)
            {

                numOfDays += NumberOfDaysInAMonth(i, date.Year);

            }

            numOfDays += date.Day;

            return numOfDays;

        }

        public static short DaysFromTheBeginingOfTheYear(short day, short month, short year)
        {

            short numOfDays = 0;

            for (short i = 1; i < month; i++)
            {

                numOfDays += NumberOfDaysInAMonth(i, year);

            }

            numOfDays += day;

            return numOfDays;

        }

        public short DaysFromTheBeginingOfTheYear()
        {
            return DaysFromTheBeginingOfTheYear(_day, _month, _year);
        }

        public static clsDate GetDateFromDayOrderInAYear(short dayOrderInAYear, short year)
        {

            clsDate date = new clsDate();

            short remainingDays = dayOrderInAYear;
            short monthDays;

            date.Year = year;
            date.Month = 1;

            while (true)
            {

                monthDays = NumberOfDaysInAMonth(date.Month, year);

                if (remainingDays > monthDays)
                {
                    remainingDays -= monthDays;
                    date.Month++;
                }
                else
                {
                    date.Day = remainingDays;
                    break;
                }

            }

            return date;

        }

        public static clsDate AddDays(short days, clsDate date)
        {

            short remainingDays = (short)(days + DaysFromTheBeginingOfTheYear(date.Day, date.Month, date.Year));
            short monthDays;

            date.Month = 1;

            while (true)
            {

                monthDays = NumberOfDaysInAMonth(date.Month, date.Year);

                if (remainingDays > monthDays)
                {
                    remainingDays -= monthDays;
                    date.Month++;

                    if (date.Month > 12)
                    {
                        date.Year++;
                        date.Month = 1;
                    }

                }
                else
                {

                    date.Day = remainingDays;
                    break;

                }
            }

            return date;

        }

        public void AddDays(short days)
        {

            short remainingDays = (short)(days + DaysFromTheBeginingOfTheYear(_day, _month, _year));
            short monthDays;

            _month = 1;

            while (true)
            {

                monthDays = NumberOfDaysInAMonth(_month, _year);

                if (remainingDays > monthDays)
                {
                    remainingDays -= monthDays;
                    _month++;

                    if (_month > 12)
                    {
                        _year++;
                        _month = 1;
                    }

                }
                else
                {

                    _day = remainingDays;
                    break;

                }
            }

        }

        public static bool IsDate1BeforeDate2(clsDate date1, clsDate date2)
        {

            if (date1.Year != date2.Year)
                return date1.Year < date2.Year;

            if (date1.Month != date2.Month)
                return date1.Month < date2.Month;

            return date1.Day < date2.Day;

        }

        public bool IsDateBeforeDate2(clsDate date2)
        {
            return IsDate1BeforeDate2(this, date2);
        }

        public static bool IsDate1EqualDate2(clsDate date1, clsDate date2)
        {

            return (date1.Year == date2.Year && date1.Month == date2.Month && date1.Day == date2.Day);

        }

        public bool IsDateEqualDate2(clsDate date2)
        {

            return IsDate1EqualDate2(this, date2);

        }

        public static bool IsLastDayInMonth(clsDate date)
        {

            return (date.Day == NumberOfDaysInAMonth(date.Month, date.Year));

        }

        public bool IsLastDayInMonth()
        {
            return IsLastDayInMonth(this);
        }

        public static bool IsLastMonthInYear(short month)
        {

            return month == 12;

        }

        public bool IsLastMonthInYear()
        {
            return _month == 12;
        }

        public static clsDate AddOneDay(clsDate date)
        {

            if (IsLastDayInMonth(date))
            {

                if (IsLastMonthInYear(date.Month))
                {
                    date.Day = 1;
                    date.Month = 1;
                    date.Year++;
                }
                else
                {
                    date.Day = 1;
                    date.Month++;
                }

            }
            else
            {
                date.Day++;
            }

            return date;

        }

        public void AddOneDay()
        {

            if (IsLastDayInMonth(this))
            {

                if (IsLastMonthInYear(_month))
                {
                    _day = 1;
                    _month = 1;
                    _year++;
                }
                else
                {
                    _day = 1;
                    _month++;
                }

            }
            else
            {
                _day++;
            }

        }

        public static void SwapDates(ref clsDate date1, ref clsDate date2)
        {

            clsDate temp = date1;
            date1 = date2;
            date2 = temp;

        }

        public static int GetDifferenceInDays(clsDate date1, clsDate date2, bool includeEndDay = false)
        {

            int days = 0;
            short sign = 1;

            if (!IsDate1BeforeDate2(date1, date2))
            {
                SwapDates(ref date1, ref date2);
                sign = -1;
            }

            for (short i = date1.Year; i < date2.Year; i++)
            {
                days += IsLeapYear(i) ? 366 : 365;
            }

            days += (GetDaysFromTheBeginingOfTheYear(date2) - GetDaysFromTheBeginingOfTheYear(date1));

            if (includeEndDay)
            {
                days++;
            }

            return days * sign;

        }

        public int GetDifferenceInDays(clsDate date2, bool includeEndDay = false)
        {
            return GetDifferenceInDays(this, date2, includeEndDay);
        }

        public static short CalculateAgeInDays(clsDate dateOfBirth)
        {
            return (short)GetDifferenceInDays(dateOfBirth, GetSystemDate(), true);
        }
        //above no need to have nonstatic function for the object because it does not depend on any data from it.

        public static clsDate IncreaseDateByXDays(clsDate date, short days)
        {

            for (short i = 0; i < days; i++)
            {
                date = AddOneDay(date);
            }

            return date;

        }

        public void IncreaseDateByXDays(short days)
        {

            for (short i = 0; i < days; i++)
            {
                AddOneDay();
            }

        }

        public static clsDate IncreaseDateByOneWeek(clsDate date)
        {
            return IncreaseDateByXDays(date, 7);
        }

        public void IncreaseDateByOneWeek()
        {

            IncreaseDateByXDays(7);

        }

        public static clsDate IncreaseDateByXWeeks(clsDate date, short weeks)
        {

            for (short i = 0; i < weeks; i++)
            {
                date = IncreaseDateByOneWeek(date);
            }

            return date;

        }

        public void IncreaseDateByXWeeks(short weeks)
        {

            for (short i = 0; i < weeks; i++)
            {
                IncreaseDateByOneWeek();
            }

        }

        public static clsDate IncreaseDateByOneMonth(clsDate date)
        {

            if (IsLastMonthInYear(date.Month))
            {
                date.Year++;
                date.Month = 1;
            }
            else
            {
                date.Month++;
            }

            short numberOfDaysInCurrentMonth = NumberOfDaysInAMonth(date.Month, date.Year);

            if (date.Day > numberOfDaysInCurrentMonth)
            {
                date.Day = numberOfDaysInCurrentMonth;
            }

            return date;

        }

        public void IncreaseDateByOneMonth()
        {
            if (IsLastMonthInYear(Month))
            {
                Year++;
                Month = 1;
            }
            else
            {
                Month++;
            }

            short numberOfDaysInCurrentMonth = NumberOfDaysInAMonth(Month, Year);

            if (Day > numberOfDaysInCurrentMonth)
            {
                Day = numberOfDaysInCurrentMonth;
            }

        }

        public static clsDate IncreaseDateByXMonths(clsDate date, short months)
        {

            for (short i = 0; i < months; i++)
            {
                date = IncreaseDateByOneMonth(date);
            }

            return date;

        }

        public void IncreaseDateByXMonths(short months)
        {

            for (short i = 0; i < months; i++)
            {
                IncreaseDateByOneMonth();
            }

        }

        public static clsDate IncreaseDateByOneYear(clsDate date)
        {

            date.Year++;

            short numberOfDaysInCurrentMonth = NumberOfDaysInAMonth(date.Month, date.Year);

            if (date.Day > numberOfDaysInCurrentMonth)
            {
                date.Day = numberOfDaysInCurrentMonth;
            }

            return date;

        }

        public void IncreaseDateByOneYear()
        {

            Year++;

            short numberOfDaysInCurrentMonth = NumberOfDaysInAMonth(Month, Year);

            if (Day > numberOfDaysInCurrentMonth)
            {
                Day = numberOfDaysInCurrentMonth;
            }

        }

        public static clsDate IncreaseDateByXYears(clsDate date, short years)
        {

            date.Year += years;

            short numberOfDaysInCurrentMonth = NumberOfDaysInAMonth(date.Month, date.Year);

            if (date.Day > numberOfDaysInCurrentMonth)
            {
                date.Day = numberOfDaysInCurrentMonth;
            }

            return date;

        }

        public void IncreaseDateByXYears(short years)
        {

            Year += years;

            short numberOfDaysInCurrentMonth = NumberOfDaysInAMonth(Month, Year);

            if (Day > numberOfDaysInCurrentMonth)
            {
                Day = numberOfDaysInCurrentMonth;
            }

        }

        public static clsDate IncreaseDateByOneDecade(clsDate date)
        {

            return IncreaseDateByXYears(date, 10);

        }

        public void IncreaseDateByOneDecade()
        {

            IncreaseDateByXYears(10);

        }

        public static clsDate IncreaseDateByXDecades(clsDate date, short decades)
        {

            date.Year += (short)(decades * 10);

            short numberOfDaysInCurrentMonth = NumberOfDaysInAMonth(date.Month, date.Year);

            if (date.Day > numberOfDaysInCurrentMonth)
            {
                date.Day = numberOfDaysInCurrentMonth;
            }

            return date;

        }

        public void IncreaseDateByXDecades(short decades)
        {

            Year += (short)(decades * 10);

            short numberOfDaysInCurrentMonth = NumberOfDaysInAMonth(Month, Year);

            if (Day > numberOfDaysInCurrentMonth)
            {
                Day = numberOfDaysInCurrentMonth;
            }

        }

        public static clsDate IncreaseDateByOneCentury(clsDate date)
        {

            return IncreaseDateByXDecades(date, 10);

        }

        public void IncreaseDateByOneCentury()
        {

            IncreaseDateByXDecades(10);

        }

        public static clsDate IncreaseDateByOneMillennium(clsDate date)
        {
            return IncreaseDateByXYears(date, 1000);
        }

        public void IncreaseDateByOneMillennium()
        {

            IncreaseDateByXYears(1000);

        }

        public static clsDate DecreaseDateByOneDay(clsDate date)
        {

            if (date.Day == 1)
            {

                if (date.Month == 1)
                {
                    date.Year--;
                    date.Month = 12;
                    date.Day = 31;

                }
                else
                {
                    date.Month--;
                    date.Day = NumberOfDaysInAMonth(date.Month, date.Year);
                }

            }
            else
            {
                date.Day--;
            }

            return date;

        }

        public void DecreaseDateByOneDay()
        {

            if (Day == 1)
            {

                if (Month == 1)
                {
                    Year--;
                    Month = 12;
                    Day = 31;

                }
                else
                {
                    Month--;
                    Day = NumberOfDaysInAMonth(Month, Year);
                }

            }
            else
            {
                Day--;
            }

        }

        public static clsDate DecreaseDateByXDays(clsDate date, short days)
        {

            for (short i = 0; i < days; i++)
            {
                date = DecreaseDateByOneDay(date);
            }

            return date;

        }

        public void DecreaseDateByXDays(short days)
        {

            for (short i = 0; i < days; i++)
            {
                DecreaseDateByOneDay();
            }

        }

        public static clsDate DecreaseDateByOneWeek(clsDate date)
        {

            return DecreaseDateByXDays(date, 7);

        }

        public void DecreaseDateByOneWeek()
        {

            DecreaseDateByXDays(7);

        }

        public static clsDate DecreaseDateByXWeeks(clsDate date, short weeks)
        {

            for (short i = 0; i < weeks; i++)
            {
                date = DecreaseDateByOneWeek(date);
            }

            return date;

        }

        public void DecreaseDateByXWeeks(short weeks)
        {

            for (short i = 0; i < weeks; i++)
            {
                DecreaseDateByOneWeek();
            }

        }

        public static clsDate DecreaseDateByOneMonth(clsDate date)
        {

            if (date.Month == 1)
            {
                date.Year--;
                date.Month = 12;
            }
            else
            {
                date.Month--;
            }

            short numberOfDaysInCurrentMonth = NumberOfDaysInAMonth(date.Month, date.Year);

            if (date.Day > numberOfDaysInCurrentMonth)
            {
                date.Day = numberOfDaysInCurrentMonth;
            }

            return date;

        }

        public void DecreaseDateByOneMonth()
        {

            if (Month == 1)
            {
                Year--;
                Month = 12;
            }
            else
            {
                Month--;
            }

            short numberOfDaysInCurrentMonth = NumberOfDaysInAMonth(Month, Year);

            if (Day > numberOfDaysInCurrentMonth)
            {
                Day = numberOfDaysInCurrentMonth;
            }

        }

        public static clsDate DecreaseDateByXMonths(clsDate date, short months)
        {

            for (short i = 0; i < months; i++)
            {

                date = DecreaseDateByOneMonth(date);

            }

            return date;

        }

        public void DecreaseDateByXMonths(short months)
        {

            for (short i = 0; i < months; i++)
            {

                DecreaseDateByOneMonth();

            }

        }

        public static clsDate DecreaseDateByOneYear(clsDate date)
        {

            date.Year--;

            short numberOfDaysInCurrentMonth = NumberOfDaysInAMonth(date.Month, date.Year);

            if (date.Day > numberOfDaysInCurrentMonth)
            {
                date.Day = numberOfDaysInCurrentMonth;
            }

            return date;

        }

        public void DecreaseDateByOneYear()
        {

            Year--;

            short numberOfDaysInCurrentMonth = NumberOfDaysInAMonth(Month, Year);

            if (Day > numberOfDaysInCurrentMonth)
            {
                Day = numberOfDaysInCurrentMonth;
            }

        }

        public static clsDate DecreaseDateByXYears(clsDate date, short years)
        {

            date.Year -= years;

            short numberOfDaysInCurrentMonth = NumberOfDaysInAMonth(date.Month, date.Year);

            if (date.Day > numberOfDaysInCurrentMonth)
            {
                date.Day = numberOfDaysInCurrentMonth;
            }

            return date;

        }

        public void DecreaseDateByXYears(short years)
        {

            Year -= years;

            short numberOfDaysInCurrentMonth = NumberOfDaysInAMonth(Month, Year);

            if (Day > numberOfDaysInCurrentMonth)
            {
                Day = numberOfDaysInCurrentMonth;
            }

        }

        public static clsDate DecreaseDateByOneDecade(clsDate date)
        {

            return DecreaseDateByXYears(date, 10);

        }

        public void DecreaseDateByOneDecade()
        {

            DecreaseDateByXYears(10);

        }

        public static clsDate DecreaseDateByXDecades(clsDate date, short decades)
        {

            date.Year -= (short)(decades * 10);

            short numberOfDaysInCurrentMonth = NumberOfDaysInAMonth(date.Month, date.Year);

            if (date.Day > numberOfDaysInCurrentMonth)
            {
                date.Day = numberOfDaysInCurrentMonth;
            }

            return date;

        }

        public void DecreaseDateByXDecades(short decades)
        {

            Year -= (short)(decades * 10);

            short numberOfDaysInCurrentMonth = NumberOfDaysInAMonth(Month, Year);

            if (Day > numberOfDaysInCurrentMonth)
            {
                Day = numberOfDaysInCurrentMonth;
            }

        }

        public static clsDate DecreaseDateByOneCentury(clsDate date)
        {

            return DecreaseDateByXDecades(date, 10);

        }

        public void DecreaseDateByOneCentury()
        {

            DecreaseDateByXDecades(10);

        }

        public static clsDate DecreaseDateByOneMillennium(clsDate date)
        {

            return DecreaseDateByXYears(date, 1000);
        }

        public void DecreaseDateByOneMillennium()
        {

            DecreaseDateByXYears(1000);

        }

        public static bool IsEndOfWeek(clsDate date)
        {

            return GetDayOfWeekOrder(date.Day, date.Month, date.Year) == 6;

        }

        public bool IsEndOfWeek()
        {

            return IsEndOfWeek(this);

        }

        public static bool IsWeekEnd(clsDate date)
        {
            //Weekends are Fri and Sat

            short dayIndex = GetDayOfWeekOrder(date.Day, date.Month, date.Year);

            return dayIndex == 5 || dayIndex == 6;

        }

        public bool IsWeekEnd()
        {

            return IsWeekEnd(this);

        }

        public static bool IsBusinessDay(clsDate date)
        {

            return !IsWeekEnd(date);

        }

        public bool IsBusinessDay()
        {

            return IsBusinessDay(this);

        }

        public static short GetDaysUntilEndOfWeek(clsDate date)
        {

            return (short)(6 - GetDayOfWeekOrder(date.Day, date.Month, date.Year));

        }

        public short GetDaysUntilEndOfWeek()
        {

            return GetDaysUntilEndOfWeek(this);

        }

        static short GetDaysUntilEndOfMonth(clsDate date)
        {

            clsDate endOfMonthDate = new clsDate();

            endOfMonthDate.Day = NumberOfDaysInAMonth(date.Month, date.Year);
            endOfMonthDate.Month = date.Month;
            endOfMonthDate.Year = date.Year;

            return (short)GetDifferenceInDays(date, endOfMonthDate, true);

        }

        public short GetDaysUntilEndOfMonth()
        {

            return GetDaysUntilEndOfMonth(this);

        }

        public static short GetDaysUntilEndOfYear(clsDate date)
        {
            clsDate endYearDate = new clsDate();
            endYearDate.Day = 31;
            endYearDate.Month = 12;
            endYearDate.Year = date.Year;

            return (short)GetDifferenceInDays(date, endYearDate, true);
        }

        public short GetDaysUntilEndOfYear()
        {

            return GetDaysUntilEndOfYear(this);

        }

        public static short CalculateBusinessDays(clsDate dateFrom, clsDate dateTo)
        {

            short days = 0;

            while (IsDate1BeforeDate2(dateFrom, dateTo))
            {

                if (IsBusinessDay(dateFrom))
                {
                    days++;
                }

                dateFrom = AddOneDay(dateFrom);

            }

            return days;

        }

        public static short CalculateVacationDays(clsDate dateFrom, clsDate dateTo)
        {

            return CalculateBusinessDays(dateFrom, dateTo);

        }
        //above method is eough , no need to have method for the object

        public static clsDate CalculateVacationReturnDate(clsDate dateFrom, short vacationDays)
        {
            // تخطي الويك إند في أول يوم
            while (IsWeekEnd(dateFrom))
            {
                dateFrom = AddOneDay(dateFrom);
            }

            // عدّ أيام الإجازة
            while (vacationDays > 0)
            {
                if (!IsWeekEnd(dateFrom))
                {
                    vacationDays--;
                }

                dateFrom = AddOneDay(dateFrom);
            }

            // لو يوم العودة ويك إند، عدّي للي بعده
            while (IsWeekEnd(dateFrom))
            {
                dateFrom = AddOneDay(dateFrom);
            }

            return dateFrom;
        }

        public static bool IsDate1AfterDate2(clsDate date1, clsDate date2)
        {

            return !IsDate1BeforeDate2(date1, date2) && !IsDate1EqualDate2(date1, date2);

        }

        public bool IsDateAfterDate2(clsDate date2)
        {

            return IsDate1AfterDate2(this, date2);

        }

        public enum enDateCompare { Before = -1, Equal = 0, After = 1 }

        public static enDateCompare CompareDates(clsDate date1, clsDate date2)
        {

            if (IsDate1BeforeDate2(date1, date2))
            {
                return enDateCompare.Before;
            }

            if (IsDate1EqualDate2(date1, date2))
            {
                return enDateCompare.Equal;
            }

            return enDateCompare.After;

        }

        public enDateCompare CompareDates(clsDate date2)
        {

            return CompareDates(this, date2);

        }

        public static string FormatDate(clsDate date, string delim = "/", string dateFormat = "dd/mm/yyyy")
        {

            string formattedDateString;

            formattedDateString = clsString.ReplaceWord(dateFormat, "dd", date.Day.ToString(), delim);
            formattedDateString = clsString.ReplaceWord(formattedDateString, "mm", date.Month.ToString(), delim);
            formattedDateString = clsString.ReplaceWord(formattedDateString, "yyyy", date.Year.ToString(), delim);

            return formattedDateString;

        }

        public string FormatDate(string delim = "/", string dateFormat = "dd/mm/yyyy")
        {

            return FormatDate(this, delim, dateFormat);

        }


    }
}
