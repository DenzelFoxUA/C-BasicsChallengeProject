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

        public static void Run()
        {
            DateTime birthdate = new DateTime(1989,01,21);
            Console.WriteLine(CalculateAgeInDays(birthdate));
            Console.WriteLine(CalculateAgeInYears(birthdate));
            Console.WriteLine(CalculateAgeInMonths(birthdate));
            
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

            if(isDatePassed == true)
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

        private static bool isDatePassedThisMonth(int date)
        {
            return date <= DateTime.Now.Date.Day;
        }
    }
}
