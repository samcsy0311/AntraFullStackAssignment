using System;

namespace _02UnderstandingTypes
{
     class Program
     {
          static void Main(string[] args)
          {
               DataType obj = new DataType();
               obj.printDataType();

               Console.Write("Enter the number of centuries: ");
               int x = Convert.ToInt32(Console.ReadLine());
               printConversion(Convert.ToUInt32(x));



          }

          static void printConversion (uint x)
          {
               uint year = x * 100;
               uint days = year/100 * 36524;
               uint hours = days * 24;
               ulong minutes = hours * 60;
               ulong seconds = minutes * 60;
               ulong millisecounds = seconds * 1000;
               ulong microseconds = millisecounds * 1000;
               ulong nanoseconds = microseconds * 1000;

               Console.WriteLine(x + " centuries = " + year + " years = " + days + " days = " +
                    hours + " hours = " + minutes + " minutes = " + seconds + " seconds = " + 
                    millisecounds + " milliseconds = " + microseconds + " microseconds = " + nanoseconds + " nanoseconds");
               //Console.WriteLine(x);
          }
     }
}
