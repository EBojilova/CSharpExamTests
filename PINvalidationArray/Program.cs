using System;
using System.Linq;

namespace PINvalidation
{
    class PINvalidation
    {
        static void Main(string[] args)
        {

            string[] names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (!ValidateNames(names))
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
                return;
            }
            string gender = Console.ReadLine();
            string PIN = Console.ReadLine();
            int year = int.Parse(PIN.Substring(0, 2));
            int month = int.Parse(PIN.Substring(2, 2));
            if (!ValidateMonthAndYear(ref month, ref year))
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
                return;
            }
            int day = int.Parse(PIN.Substring(4, 2));
            if (!ValidateDays(day, year, month))
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
                return;
            }
            if (!ValidateGenderDigit(gender, PIN))
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
                return;
            }
            if (!ChecksumValidation(PIN))
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
                return;
            }
            Console.WriteLine("{{\"name\":\"{0}\",\"gender\":\"{1}\",\"pin\":\"{2}\"}}", string.Join(" ", names), gender, PIN);
        }

        private static bool ChecksumValidation(string PIN)
        {
            int sum = 0;
            //var intList = "12345".Select(digit => int.Parse(digit.ToString()));
            int[] digits = PIN.ToCharArray().Select(x => x - '0').ToArray();//po-dobar variant tai kato ne se parsva
            int[] factors = { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
            for (int i = 0; i < factors.Length; i++)
            {
                sum += digits[i] * factors[i];
            }
            int checksum = sum % 11;
            checksum = checksum < 10 ? checksum : 0;
            return (checksum == digits[9]);
        }

        private static bool ValidateGenderDigit(string gender, string PIN)
        {
            return ((gender == "female" && (PIN[8] - '0') % 2 == 1) || (gender == "male" && (PIN[8] - '0') % 2 == 0));
        }

        private static bool ValidateDays(int day, int year, int month)
        {
            return (day >= 1 && day <= DateTime.DaysInMonth(year, month));
        }

        private static bool ValidateNames(string[] names)
        {
            return ((names.Length == 2) && (names.All(t => char.IsUpper(t.First()))));
        }

        private static bool ValidateMonthAndYear(ref int month, ref int year)
        {
            if (month > 20 && month <= 32)
            {
                year += 1800;
                month -= 20;
            }
            else if (month >= 1 && month <= 12)
            {
                year += 1900;
            }
            else if (month > 40 && month <= 52)
            {
                year += 2000;
                month -= 40;
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
