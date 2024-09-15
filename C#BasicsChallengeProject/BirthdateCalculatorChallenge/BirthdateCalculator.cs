using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_BasicsChallengeProject.BirthdateCalculatorChallenge
{
    public static class BirthdateCalculator
    {
        public const int DAYS_PER_YEAR = 365;
        public const int MONTHS_PER_YEAR = 12;
        public const int DAYS_PER_WEEK = 7;
        public const int WEEKENDS_PER_WEEK = 2;
        public static void Run()
        {
            DateTime birthdate = new DateTime(1989, 01, 21);
            Console.WriteLine(CalculateAgeInDays(birthdate));
            Console.WriteLine(CalculateAgeInYears(birthdate));
            Console.WriteLine(CalculateAgeInMonths(birthdate));
            Console.WriteLine(CalaculateDaysToNextBirthday(birthdate));
            Console.WriteLine(CalaculateDaysToNextBirthday(new DateTime(1986, 12, 28)));
            Console.WriteLine(WeekendsTillBirthday(birthdate));

        }

        public static int CalculateAgeInDays(DateTime birthdate)
        {
            DateTime today = DateTime.Now.Date;

            return ((int)(today - birthdate).TotalDays);
        }

        public static int CalculateAgeInMonths(DateTime birthdate)
        {
            bool isDatePassed = isDatePassedThisMonth(birthdate.Date.Day);

            int monthsPassedAfterBirthDayThisYear;

            if (isDatePassed == true)
            {
                monthsPassedAfterBirthDayThisYear = DateTime.Now.Date.Month - birthdate.Date.Month;
            }
            else
            {
                monthsPassedAfterBirthDayThisYear = DateTime.Now.Date.Month - birthdate.Date.Month - 1;
            }

            int months = CalculateAgeInYears(birthdate) * MONTHS_PER_YEAR + monthsPassedAfterBirthDayThisYear;
            return months;
        }

        public static int CalculateAgeInYears(DateTime birthdate)
        {
            return (int)(CalculateAgeInDays(birthdate) / DAYS_PER_YEAR);
        }

        public static int CalaculateDaysToNextBirthday(DateTime birthdate)
        {
            bool dayIsPassed = isBirthdayPassedThisYear(birthdate);
            int thisYear = DateTime.Now.Year,
                nextYear = thisYear + 1,
                endOfThisYearIndex = new DateTime(thisYear, 12, 31).DayOfYear,
                birthDayThisYearIndex = new DateTime(thisYear, birthdate.Month, birthdate.Day).DayOfYear,
                birthdayNextYearIndex = new DateTime(nextYear, birthdate.Month, birthdate.Day).DayOfYear,
                todayIndex = DateTime.Today.Date.DayOfYear;

            if (dayIsPassed == true)
            {
                int daysToEndOfAYear = endOfThisYearIndex - todayIndex;
                return daysToEndOfAYear + birthdayNextYearIndex;
            }
            else
            {
                return birthDayThisYearIndex - todayIndex;
            }
        }

        public static int WeekendsTillBirthday(DateTime birthdate)
        {
            int daysToNextWeekend = DateTime.Today.GetDaysToNextWeekend();

            int totalDaysLeft = CalaculateDaysToNextBirthday(birthdate);
            
            int todaySaturday = DateTime.Today.IsTodaySaturday() ? 1 : 0;
            

            double preciseNumbersOfWeekends 
                = (totalDaysLeft - daysToNextWeekend) / (double)DAYS_PER_WEEK * (double)WEEKENDS_PER_WEEK + todaySaturday;
            
            return (int)preciseNumbersOfWeekends;        
        }

        private static bool isDatePassedThisMonth(int date)
        {
            return date <= DateTime.Now.Date.Day;
        }

        private static bool isBirthdayPassedThisYear(DateTime birthdate)
        {
            DateTime today = DateTime.Now.Date;

            return new DateTime(today.Year,birthdate.Month,birthdate.Day) <= today.Date;
        }

        private static int GetDaysToNextWeekend(this DateTime value)
        {
            var day = value.DayOfWeek;

            switch(day)
            {
                case DayOfWeek.Monday: return 5;
                case DayOfWeek.Tuesday: return 4;
                case DayOfWeek.Wednesday: return 3;
                case DayOfWeek.Thursday: return 2;
                case DayOfWeek.Friday: return 1;
                case DayOfWeek.Saturday: return 0;
                case DayOfWeek.Sunday: return 0;
                default: break;
            }

            return 0;
        }

        private static bool IsTodaySunday()
        {
            return DateTime.Today.DayOfWeek == DayOfWeek.Sunday;
        }

        private static bool IsTodaySunday(this DateTime value)
        {
            return value.DayOfWeek == DayOfWeek.Sunday;
        }

        private static bool IsTodaySaturday()
        {
            return DateTime.Today.DayOfWeek == DayOfWeek.Saturday;
        }

        private static bool IsTodaySaturday(this DateTime value)
        {
            return value.DayOfWeek == DayOfWeek.Saturday;
        }

    }
}
