using System;

namespace Exercise03
{
     class Program
     {
          static void Main(string[] args)
          {
               //FizzBuzz
               for (int i = 1; i <= 100; i++)
               {
                    if (i % 3 == 0)
                    {
                         if (i % 5 == 0)
                         {
                              Console.WriteLine("FizzBuzz");
                         }
                         else
                         {
                              Console.WriteLine("Fizz");
                         }
                    }
                    else if (i % 5 == 0)
                    {
                         Console.WriteLine("Buzz");
                    }
                    else
                    {
                         Console.WriteLine(i);
                    }
               }

               //Guess game
               int correctNumber = new Random().Next(3) + 1;
               bool correct = false;
               while (!correct)
               {
                    Console.Write("Enter your guess: ");
                    int x = int.Parse(Console.ReadLine());
                    correct = checkAnswer(x, correctNumber);
               }

               //Pyramid
               printPyramid(25);

               //Birthday age
               Console.Write("Enter your birthday (yyyymmdd): ");
               int birthday = int.Parse(Console.ReadLine());
               int year = birthday / 10000;
               birthday = birthday % 10000;
               int month = birthday / 100;
               int day = birthday % 100;
               DateTime start = new DateTime(year, month, day);
               DateTime end = new DateTime(2021, 11, 3);
               int daysOld = (int)(end - start).TotalDays;
               Console.WriteLine("How many days old: " + daysOld);
               int numDays = 10000 - (daysOld % 10000);
               Console.WriteLine("Number of days to next 10000 anniversary: " + numDays);

               //Greetings
               Console.WriteLine("The current date and time is: " + DateTime.Now);
               int h = DateTime.Now.Hour;
               if (h < 6)
               {
                    Console.WriteLine("Good night zzz");
               }
               else if (h >= 6 && h < 12)
               {
                    Console.WriteLine("Good morning ^^");
               }
               else if (h >= 12 && h < 18)
               {
                    Console.WriteLine("Good afternoon~");
               }
               else
               {
                    Console.WriteLine("Good evening!");
               }

               //Counting 24
               for (int i = 1; i <= 4; ++i)
               {
                    for (int j = 0; j < 24; j += i)
                    {
                         Console.Write(j + ",");
                    }
                    Console.WriteLine(24);
               }

          }

          static bool checkAnswer (int x, int correctNumber)
          {
               if (x < 1 || x > 3)
               {
                    Console.WriteLine("Out of range");
                    Console.WriteLine();
                    return false;
               }
               if (x == correctNumber)
               {
                    Console.WriteLine("You've got the correct answer!");
                    return true;
               }
               else if (x>correctNumber)
               {
                    Console.WriteLine("Your answer is too large");
               }
               else
               {
                    Console.WriteLine("Your answer is too small");
               }
               Console.WriteLine();
               return false;
          }

          static void printPyramid (int numOfStars) 
          {
               int h = (int)Math.Sqrt(numOfStars);

               for (int i = 0; i < h; i ++)
               {
                    // print space
                    for (int j = h-i; j > 0; j--)
                    {
                         Console.Write(" ");
                    }
                    // print star
                    for (int j = 1; j <= 2*i + 1; ++j)
                    {
                         Console.Write("*");
                    }
                    Console.WriteLine();
               }
          }
     }
}
