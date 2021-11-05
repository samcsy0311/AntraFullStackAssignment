using System;
using System.Collections.Generic;

namespace WorkingWithMethods
{
     class Program
     {
          static void Main(string[] args)
          {
               int[] numbers = GenerateNumbers(10);
               Reverse(numbers);
               PrintNumbers(numbers);

               //Fibonacci
               for (int i = 1; i <= 10; i++)
               {
                    Console.WriteLine(Fibonacci(i));
               }

               // Working days
               Console.Write("Enter the first date (mm-dd-yyyy): ");
               string date1= Console.ReadLine();
               Console.Write("Enter the second date (mm-dd-yyyy): ");
               string date2 = Console.ReadLine();

               DateTime day1 = DateTime.Parse(date1);
               DateTime day2 = DateTime.Parse(date2);
               List<DateTime> holidays = GetHolidays();
               int numOfWorkingDays = WorkDays(day1, day2, holidays);
               Console.WriteLine("The number of working days between these two dates: " + numOfWorkingDays);
          }

          static int[] GenerateNumbers(int n)
          {
               int[] arr = new int[n];

               for (int i = 1; i <= n; ++i)
               {
                    arr[i - 1] = i;
               }
               return arr;
          }

          static void Reverse(int[] arr)
          {
               int[] arr2 = (int[]) arr.Clone();
               for (int i = 0; i < arr.Length; i++)
               {
                    arr[i] = arr2[arr.Length - i - 1];
               }
          }

          static void PrintNumbers(int[] arr)
          {
               foreach(int num in arr)
               {
                    Console.Write(num + " ");
               }
          }

          static int Fibonacci (int n)
          {
               if (n == 1)
                    return 1;
               return _Fibonacci(n - 1, 1, 1);
          }

          static int _Fibonacci(int lvl, int current, int previous)
          {
               if (lvl == 1)
               {
                    return current;
               }
               return _Fibonacci(lvl - 1, current + previous, current);
          }

          static int WorkDays (DateTime day1, DateTime day2, List<DateTime> holiday)
          {
               int count = 0;

               foreach(DateTime day in EachDay(day1, day2))
               {
                    if (!(day.DayOfWeek == DayOfWeek.Sunday || day.DayOfWeek == DayOfWeek.Saturday || 
                         holiday.Contains(day)))
                    {
                         count++;
                    }
               }

               return count;
          }

          static List<DateTime> GetHolidays ()
          {
               List<DateTime> holidays = new List<DateTime>();
               holidays.Add(DateTime.Parse("01-01-2021"));
               holidays.Add(DateTime.Parse("01-18-2021"));
               holidays.Add(DateTime.Parse("01-20-2021"));
               holidays.Add(DateTime.Parse("02-15-2021"));
               holidays.Add(DateTime.Parse("05-31-2021"));
               holidays.Add(DateTime.Parse("06-18-2021"));
               holidays.Add(DateTime.Parse("07-05-2021"));
               holidays.Add(DateTime.Parse("09-06-2021"));
               holidays.Add(DateTime.Parse("10-11-2021"));
               holidays.Add(DateTime.Parse("11-11-2021"));
               holidays.Add(DateTime.Parse("11-25-2021"));
               holidays.Add(DateTime.Parse("12-24-2021"));
               return holidays;
          }

          public static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
          {
               for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                    yield return day;
          }
     }
}
