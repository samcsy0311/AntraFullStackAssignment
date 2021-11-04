using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace String
{
     class Program
     {
          static void Main(string[] args)
          {
               Console.Write("Enter a string: ");
               string str = Console.ReadLine();
               Console.WriteLine("Reverse using character array: " + reverse1(str));
               reverse2(str);
               Console.WriteLine(ReverseWordsOnly(str));
               palindromeString(str);
               parseURL(str);
          }

          public static string reverse1 (string str)
          {
               char[] characters = str.ToCharArray();
               Array.Reverse(characters);
               
               return new string(characters);
          }

          public static void reverse2(string str)
          {
               Console.Write("Reverse using for loop: ");
               for (int i = str.Length-1; i >= 0; i--)
               {
                    Console.Write(str[i]);
               }
               Console.WriteLine();
          }

          public static string ReverseWordsOnly(string str)
          {
               //return String.Join(" ", str.Split('.', ' ').Reverse()).ToString();
               //string[] strArr = str.Split('.', ' ', ',', ':', ';', '=', '(', ')', '&', '[', ']', '!', '?', '\"', '\'', '\\', '/');
               //Array.Reverse(strArr);
               //return string.Join(' ', strArr).ToString();
               //string[] temp = new string[strArr.Length];
               char[] charArr = str.ToCharArray();
               List<string> ls = new List<string>();
               string temp = "";
               foreach (char c in charArr)
               {
                    if (c != '.' && c!= ' ' && c!= ',' && c != ':' && c != '!' && c != '?' && c != '\"' && c!= '\'' && c != '/' &&
                        c != ';' && c!= '=' && c!= '(' && c != ')' && c != '&' && c != '[' && c != ']'  && c != '\\')
                    {
                         temp += c;
                    }
                    else if (c == ' ')
                    {
                         ls.Add(temp);
                         temp = "";
                    }
                    else
                    {
                         ls.Add(temp);
                         ls.Add(c.ToString());
                         temp = "";
                    }
               }

               List<string> reverseLs = new List<string>(ls);
               reverseLs.Reverse();
               string[] lsStr = ls.ToArray();
               string[] rvStr = reverseLs.ToArray();
               int j = 0;
               for (int i = 0; i < lsStr.Length; i++)
               {
                    string s = lsStr[i];
                    if (s.Length > 1 || s == "a" || s == "A")
                    {
                         lsStr[i] = nextString(rvStr, ref j);
                    }
               }
               string result = string.Join(" ", lsStr);
               result = Regex.Replace(result, " , ", ",");
               result = Regex.Replace(result, " ! ", "!");

               return result;

          }

          private static string nextString(string[] s, ref int j)
          {
               for (int i = j + 1; i < s.Length; i++)
               {
                    if (s[i].Length > 1 || s[i].Equals("A") || s[i].Equals("a"))
                    {
                         j = i;
                         return s[i];
                    }
               }
               j = s.Length;
               return "";
          }

          public static void palindromeString (string str)
          {
               str = Regex.Replace(str, @"[^\w\d\s]", " ");
               str = str.Replace("  ", " ");
               string[] strArr = str.Split(' ');
               List<string> palindrome = new List<string>();

               foreach (string temp in strArr)
               {
                    if (checkPalindrome(temp))
                    {
                         if (!palindrome.Contains(temp))
                         {
                              palindrome.Add(temp);
                         }
                    }
               }
               string[] palindromeArray = palindrome.ToArray();
               Array.Sort(palindromeArray);

               for (int i = 0; i < palindromeArray.Length -1; ++i)
               {
                    Console.Write(palindromeArray[i] + ", ");
               }
               Console.Write(palindromeArray[palindromeArray.Length - 1]);
          }

          private static bool checkPalindrome (string str)
          {
               return str.SequenceEqual(reverse1(str));
          }

          public static void parseURL (string url)
          {
               string protocol = "";
               string server = "";
               string resource = "";
               if (url.Contains("://"))
               {
                    string[] twoParts = url.Split("://");
                    protocol = twoParts[0];
                    if (twoParts[1].Contains("/"))
                    {
                         twoParts = twoParts[1].Split("/");
                         server = twoParts[0];
                         resource = twoParts[1];
                    }
                    else
                    {
                         server = twoParts[1];
                    }
               }
               else
               {
                    if (url.Contains("/"))
                    {
                         string[] twoParts = url.Split("/");
                         server = twoParts[0];
                         resource = twoParts[1];
                    }
                    else
                    {
                         server = url;
                    }
               }
               Console.WriteLine("[Protocol] = \"" + protocol + "\"");
               Console.WriteLine("[Server] = \"" + server + "\"");
               Console.WriteLine("[Resource] = \"" + resource + "\"");
          }
     }
}
