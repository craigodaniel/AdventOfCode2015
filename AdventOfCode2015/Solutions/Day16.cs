using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015.Solutions
{
    public class Day16
    {
        // --- Day 16: Aunt Sue ---
        // https://adventofcode.com/2015/day/16
        //
        // Part 1 runtime: 2.1182ms. The answer is: 213
        // Part 2 runtime: 2.391ms. The answer is: 323
        //
        // Comments: Mother of all if statements...

        private static string fileDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Inputs";
        //private static string fileName = "day16_sample.txt";
        private static string fileName = "day16_actual.txt";
        private static string[] lines = File.ReadAllLines(fileDir + "\\" + fileName);

        public static void Part1()
        {
            long startTime = Stopwatch.GetTimestamp();
            int answer = 0;

            foreach (var line in lines)
            {
                Dictionary<string, int> marker = GetAuntSueMarkers(line);
                if (CheckAuntSue(marker))
                {
                    answer = marker["id"];
                    break;
                }
            }

            TimeSpan elapsedTime = Stopwatch.GetElapsedTime(startTime);
            Console.WriteLine("Part 1 runtime: {0}ms. The answer is: {1}", elapsedTime.TotalMilliseconds, answer);
        }

        public static void Part2()
        {
            long startTime = Stopwatch.GetTimestamp();
            int answer = 0;

            foreach (var line in lines)
            {
                Dictionary<string, int> marker = GetAuntSueMarkers(line);
                if (CheckAuntSuePart2(marker))
                {
                    answer = marker["id"];
                    break;
                }
            }

            TimeSpan elapsedTime = Stopwatch.GetElapsedTime(startTime);
            Console.WriteLine("Part 2 runtime: {0}ms. The answer is: {1}", elapsedTime.TotalMilliseconds, answer);
        }

        private static Dictionary<string,int> GetAuntSueMarkers(string line)
        {
            Dictionary<string,int> marker = new Dictionary<string,int>();
            marker.Add("id", -1);
            marker.Add("children", -1);
            marker.Add("cats", -1);
            marker.Add("samoyeds", -1);
            marker.Add("pomeranians", -1);
            marker.Add("akitas", -1);
            marker.Add("vizslas", -1);
            marker.Add("goldfish", -1);
            marker.Add("trees", -1);
            marker.Add("cars", -1);
            marker.Add("perfumes", -1);

            marker["id"] = int.Parse(line.Split(':')[0].Split(' ')[1]);

            string[] s = line.Split(',');
            for (int i = 0; i < s.Length; i++)
            {
                string key = "";
                int value = -10;

                if (i == 0)
                {
                    string[] a = s[i].Split(":");
                    key = a[1].Trim();
                    value = int.Parse(a[2].Trim());
                }
                else
                {
                    string[] a = s[i].Split(":");
                    key = a[0].Trim();
                    value = int.Parse(a[1].Trim());
                }

                marker[key] = value;
            }

            return marker;
        }

        private static bool CheckAuntSue(Dictionary<string, int> marker)
        {
            bool isMatch = false;

            if (
                (marker["children"] == 3 || marker["children"] == -1) &&
                (marker["cats"] == 7 || marker["cats"] == -1) &&
                (marker["samoyeds"] == 2 || marker["samoyeds"] == -1) &&
                (marker["pomeranians"] == 3 || marker["pomeranians"] == -1) &&
                (marker["akitas"] == 0 || marker["akitas"] == -1) &&
                (marker["vizslas"] == 0 || marker["vizslas"] == -1) &&
                (marker["goldfish"] == 5 || marker["goldfish"] == -1) &&
                (marker["trees"] == 3 || marker["trees"] == -1) &&
                (marker["cars"] == 2 || marker["cars"] == -1) &&
                (marker["perfumes"] == 1 || marker["perfumes"] == -1)
                )
            {
                isMatch = true;
            }

            return isMatch;
        }

        private static bool CheckAuntSuePart2(Dictionary<string, int> marker)
        {
            bool isMatch = false;

            if (
                (marker["children"] == 3 || marker["children"] == -1) &&
                (marker["cats"] > 7 || marker["cats"] == -1) &&
                (marker["samoyeds"] == 2 || marker["samoyeds"] == -1) &&
                (marker["pomeranians"] < 3 || marker["pomeranians"] == -1) &&
                (marker["akitas"] == 0 || marker["akitas"] == -1) &&
                (marker["vizslas"] == 0 || marker["vizslas"] == -1) &&
                (marker["goldfish"] < 5 || marker["goldfish"] == -1) &&
                (marker["trees"] > 3 || marker["trees"] == -1) &&
                (marker["cars"] == 2 || marker["cars"] == -1) &&
                (marker["perfumes"] == 1 || marker["perfumes"] == -1)
                )
            {
                isMatch = true;
            }

            return isMatch;
        }
    }
}
