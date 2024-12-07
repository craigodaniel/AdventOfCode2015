
using System.Diagnostics;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdventOfCode2015.Solutions
{
    public class Day12
    {
        // --- Day 12: JSAbacusFramework.io ---
        // https://adventofcode.com/2015/day/12
        //
        // Part1 Sum all numbers in file
        // Part 2 Sum all numbers but ignore any object with property value "red"
        // 65402

        private static string fileDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
        private static string fileName = "2015_12_input.txt";
        private static string input = File.ReadAllText(fileDir + "\\" + fileName);

        public static void Part1()
        {
            Stopwatch sw = Stopwatch.StartNew();

            bool isNegative = false;
            bool isEndofNumber = false;
            string numStr = "";
            int sum = 0;


            for (int i = 0; i < input.Length; i++)
            {
                
                if (Char.IsAsciiDigit(input[i]))
                {
                    if (i != 0){if (input[i - 1] == '-') { isNegative = true; }} //check for negative sign

                    if (i != input.Length - 1) { if (!Char.IsAsciiDigit(input[i +1])){ isEndofNumber = true;}} //check for end of number string

                    if (i == input.Length - 1) { isEndofNumber= true;} //check for number ending at end of document

                    numStr += input[i];

                    if (isEndofNumber)
                    {
                        //Console.WriteLine($"{numStr} is neg: {isNegative}");

                        if (isNegative) { sum -= int.Parse(numStr); }
                        else { sum += int.Parse(numStr); }

                        isNegative = false;
                        isEndofNumber = false;
                        numStr = "";
                    }
                }
                
                
            }


            sw.Stop();
            Console.WriteLine($"Part 1 Runtime (ms): {sw.ElapsedMilliseconds}");
            Console.WriteLine($"Sum of all numbers in document: {sum}");
            
        }

        public static void Part2()
        {
            Stopwatch sw = Stopwatch.StartNew();
            dynamic inputObj = JsonConvert.DeserializeObject(input);

            long sum = GetSum(inputObj, "red");

            sw.Stop();

            Console.WriteLine($"Part 2 Sum: {sum}");
            Console.WriteLine($"Part 2 Runtime (ms): {sw.ElapsedMilliseconds}");
        }


        private static long GetSum(JObject o, string avoid = null)
        {
            
            bool shouldAvoid = o.Properties()
                .Select(a => a.Value).OfType<JValue>()
                .Select(v => v.Value).Contains(avoid);
            if (shouldAvoid) return 0;
            

            long sum = 0;

            foreach (dynamic a in o.Properties())
            {
                sum += (long)GetSum(a.Value, avoid);
            }

            return sum;
        }

        private static long GetSum(JArray arr, string avoid)
        {
            long sum = 0;

            foreach (dynamic a in arr)
            {
                sum += (long)GetSum(a, avoid);
            }

            return sum;
        }

        private static long GetSum(JValue val, string avoid)
        {
            if (val.Type == JTokenType.Integer)
            {
                return (long)val.Value;
            }
            else
            {
                return 0;
            }
        }
    }
}
