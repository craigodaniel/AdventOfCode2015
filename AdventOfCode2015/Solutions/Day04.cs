using System;
using System.Text;
using System.Security.Cryptography;

namespace AdventOfCode2015.Solutions
{
    public class Day04
    {
        //--- Day 4: The Ideal Stocking Stuffer ---
        //https://adventofcode.com/2015/day/4
        //
        //
        // holy schnikes...

        public static void Part1()
        {
            string input = "bgvyzdsv";
            bool isComplete = false;

            for (int i = 0; i < 2147483647; i++)
            {
                string num = i.ToString();

                string source = input + num; //source is of form abcdef123456

                using (MD5 md5Hash = MD5.Create())
                {
                    string hash = GetMd5Hash(md5Hash, source);
                    //Console.WriteLine("The MD5 hash of " + source + " is: " + hash + ".");
                    
                    if (hash.Substring(0,5) == "00000")
                    {
                        Console.WriteLine("The MD5 hash of " + source + " is: " + hash + ".");
                        Console.WriteLine("Complete! Answer: " + i.ToString());
                        isComplete = true;
                    }
                }

                if (isComplete) { break; }
            }
            
            if (!isComplete) { Console.WriteLine("No answer found :("); }

        }
        public static void Part2()
        {
            string input = "bgvyzdsv";
            bool isComplete = false;

            for (int i = 0; i < 2147483647; i++)
            {
                string num = i.ToString();

                string source = input + num; //source is of form abcdef123456

                using (MD5 md5Hash = MD5.Create())
                {
                    string hash = GetMd5Hash(md5Hash, source);
                    //Console.WriteLine("The MD5 hash of " + source + " is: " + hash + ".");

                    if (hash.Substring(0, 6) == "000000")
                    {
                        Console.WriteLine("The MD5 hash of " + source + " is: " + hash + ".");
                        Console.WriteLine("Complete! Answer: " + i.ToString());
                        isComplete = true;
                    }
                }

                if (isComplete) { break; }
            }

            if (!isComplete) { Console.WriteLine("No answer found :("); }
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

    }
}
