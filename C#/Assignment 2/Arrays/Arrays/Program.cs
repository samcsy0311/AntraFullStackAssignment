using System;
using System.Collections.Generic;
using System.Linq;

namespace Arrays
{
     class Program
     {
          static void Main(string[] args)
          {
               //Copy Array
               int[] intArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
               int[] newIntArr = new int[intArr.Length];

               for (int i = 0; i < intArr.Length; i++)
               {
                    newIntArr[i] = intArr[i];
               }

               printArray(intArr, "old array");
               printArray(newIntArr, "new array");

               //To do list
               string input = "";
               List<string> toDoList = new List<string>();
               Console.WriteLine("Enter command (+ item, - item, or -- to clear)):");
               input = Console.ReadLine();
               while (!(input.Equals("q") || input.Equals("Q")))
               {
                    string command = input.Substring(0, 2);
                    string item = input.Substring(2);
                    switch (command)
                    {
                         case "+ ":
                              toDoList.Add(item);
                              break;
                         case "- ":
                              toDoList.Remove(item);
                              break;
                         case "--":
                              toDoList.Clear();
                              break;
                         default:
                              input = "Q";
                              break;
                    }
                    Console.WriteLine("Enter command (+ item, - item, or -- to clear)):");
                    input = Console.ReadLine();
               }
               Console.WriteLine();
               Console.WriteLine("To Do List: ");
               printList(toDoList);

               // Prime number
               printArray(FindPrimesInRange(1, 10), "Prime Numbers");

               //Sum rotation array
               Console.WriteLine("Please enter the array:");
               string str = Console.ReadLine();
               string[] tokens = str.Split(' ');
               int[] numbers = Array.ConvertAll(tokens, int.Parse);
               Console.WriteLine("How many rotations?");
               int k = int.Parse(Console.ReadLine());
               int[] sum = rotationSum(numbers, k);
               printArray(sum, "rotated sum");

               //longest sequence
               Console.WriteLine("Please enter the array:");
               str = Console.ReadLine();
               tokens = str.Split(' ');
               numbers = Array.ConvertAll(tokens, int.Parse);
               printLongestSequence(numbers);

               //most frequent number
               Console.WriteLine("Please enter the array:");
               str = Console.ReadLine();
               tokens = str.Split(' ');
               numbers = Array.ConvertAll(tokens, int.Parse);
               Console.WriteLine("The most frequent number is " + mostFrequent(numbers, numbers.Length));
          }

          static void printArray (int[] arr, String name)
          {
               Console.Write(name + ": [");
               for (int i = 0; i < arr.Length - 1; i++)
               {
                    Console.Write(arr[i] + ", ");
               }
               Console.WriteLine(arr[arr.Length - 1] + "]");
          }

          static void printList (List<string> ls)
          {
               for (int i = 0; i < ls.Count; ++i)
               {
                    Console.WriteLine(ls[i]);
               }
          }

          static int[] FindPrimesInRange(int startNum, int endNum)
          {
               List<int> ls = new List<int>();
               int flag = 0;
               for (int i = startNum; i <= endNum; i++)
               {
                    flag = 0;
                    for (int j = 2; j <= i/2; j++)
                    {
                         if (i % j == 0)
                         {
                              // not prime
                              flag = 1;
                              break;
                         }
                    }
                    if (flag == 0 && i != 1)
                         ls.Add(i);          //prime
               }
               return ls.ToArray();
          }

          static int[] rotationSum (int[] arr, int k)
          {
               int[] sum = new int[arr.Length];

               for (int r = 1; r <= k; ++r)
               {
                    for (int l = 0; l < arr.Length; ++l)
                    {
                         sum[(l + r) % arr.Length] += arr[l];
                    }
               }
               return sum;
          }

          static void printLongestSequence(int[] numbers)
          {
               int count = 1;
               int longestNum = numbers[0];
               int longestCount = 1;

               for (int i = 1; i < numbers.Length; i++)
               {
                    if (numbers[i] != numbers[i - 1])
                    {
                         count = 0;
                    }

                    count++;
                    
                    if (count > longestCount)
                    {
                         longestCount = count;
                         longestNum = numbers[i];
                    }
               }
               Console.WriteLine(string.Join(" ", Enumerable.Repeat(longestNum, longestCount)));
          }

          static int mostFrequent(int[] arr, int n)
          {

               int res = -1;
               int max = 1;
               for (int i = 0; i < n; i++)
               {
                    int count = 0;
                    for (int j = 0; j < n; j++)
                    {
                         if (arr[i] == arr[j])
                         {
                              count++;
                         }
                    }
                    if (count > max)
                    {
                         res = arr[i];
                         max = count;
                    }

               }

               return res;
          }
     }
}
