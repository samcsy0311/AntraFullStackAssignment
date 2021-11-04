using System;

namespace _02UnderstandingTypes
{
     public class DataType
     {
          public void printDataType()
          {
               Console.WriteLine("sbyte:");
               Console.WriteLine("Number of bytes: 1 \t Min: -128 \t\t\t\t Max: 127");
               Console.WriteLine();

               Console.WriteLine("byte:");
               Console.WriteLine("Number of bytes: 1 \t Min: 0 \t\t\t\t Max: 255");
               Console.WriteLine();

               Console.WriteLine("short:");
               Console.WriteLine("Number of bytes: 2 \t Min: -32768 \t\t\t\t Max: 32787");
               Console.WriteLine();

               Console.WriteLine("ushort:");
               Console.WriteLine("Number of bytes: 2 \t Min: 0 \t\t\t\t Max: 65535");
               Console.WriteLine();

               Console.WriteLine("int:");
               Console.WriteLine("Number of bytes: 4 \t Min: -2,147,483,648 \t\t\t Max: 2,147,483,647");
               Console.WriteLine();

               Console.WriteLine("uint:");
               Console.WriteLine("Number of bytes: 4 \t Min: 0 \t\t\t\t Max: 4,294,967,295");
               Console.WriteLine();

               Console.WriteLine("long:");
               Console.WriteLine("Number of bytes: 8 \t Min: -9,223,372,036,854,775,808 \t Max: 9,223,372,036,854,775,807");
               Console.WriteLine();

               Console.WriteLine("ulong:");
               Console.WriteLine("Number of bytes: 8 \t Min: 0 \t\t\t\t Max: 18,446,744,073,709,551,615");
               Console.WriteLine();

               Console.WriteLine("float:");
               Console.WriteLine("Number of bytes: 4 \t Min: ±1.5 x 10^−45 \t\t\t Max: ±3.4 x 10^38");
               Console.WriteLine();

               Console.WriteLine("double:");
               Console.WriteLine("Number of bytes: 8 \t Min: ±5.0 × 10^−324 \t\t\t Max: ±1.7 × 10^308");
               Console.WriteLine();

               Console.WriteLine("decimal:");
               Console.WriteLine("Number of bytes: 16 \t Min: ±1.0 x 10^-28 \t\t\t Max: ±7.9228 x 10^28");
               Console.WriteLine();
          }
     }
}

