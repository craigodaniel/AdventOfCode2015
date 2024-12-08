using AdventOfCode2015.AocLibrary2015;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015.Solutions
{
    public class Day15
    {
        // --- Day 15: Science for Hungry People ---
        // https://adventofcode.com/2015/day/15
        //
        // Part 1 runtime: 93.2855ms. The answer is: 222870
        // Part 2 runtime: 84.7356ms. The answer is: 117936
        //
        // Comments: 
        // Nested for loops go brrrrrt!
        // Opitimization problem. Possibly a variation of Bounded Knapsack Problem?
        // https://en.wikipedia.org/wiki/Knapsack_problem
        // My solution is inefficent as it iterates through 100+ million possible combinations but is slightly efficient
        // in that it only evaluates the 176,851 possible valid combos.

        private static string fileDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Inputs";
        //private static string fileName = "day15_sample.txt";
        private static string fileName = "day15_actual.txt";
        private static string[] lines = File.ReadAllLines(fileDir + "\\" + fileName);

        public static void Part1()
        {
            long startTime = Stopwatch.GetTimestamp();
            int answer = 0;
            int[,] ingredients = CleanInput();

            for (int i1 = 0; i1 <= 100; i1++)
            {
                for (int i2 = 0;i2 <= 100; i2++)
                {
                    for (int i3 = 0; i3 <= 100; i3++)
                    {
                        for(int i4 = 0; i4 <= 100; i4++)
                        {
                            if (i1 + i2 + i3 + i4 == 100)
                            {
                                int score = 1;

                                for (int col = 0; col < ingredients.GetLength(1) - 1; col++) //sub 1 to ignore calories
                                {
                                    int colTot = (i1 * ingredients[0, col]) + (i2 * ingredients[1, col]) + (i3 * ingredients[2,col]) + (i4 * ingredients[3,col]);
                                    if (colTot < 0)
                                    {
                                        colTot = 0;
                                    }

                                    score = score * colTot;
                                }

                                if (score > answer)
                                {
                                    answer = score;
                                }
                            }
                        }
                    }                    
                }
            }

            TimeSpan elapsedTime = Stopwatch.GetElapsedTime(startTime);
            Console.WriteLine("Part 1 runtime: {0}ms. The answer is: {1}", elapsedTime.TotalMilliseconds, answer);
        }

        public static void Part2()
        {
            long startTime = Stopwatch.GetTimestamp();
            int answer = 0;

            int[,] ingredients = CleanInput();

            for (int i1 = 0; i1 <= 100; i1++)
            {
                for (int i2 = 0; i2 <= 100; i2++)
                {
                    for (int i3 = 0; i3 <= 100; i3++)
                    {
                        for (int i4 = 0; i4 <= 100; i4++)
                        {
                            if (i1 + i2 + i3 + i4 == 100)
                            {
                                int score = 1;

                                int calorieTotal = (i1 * ingredients[0,4]) + (i2 * ingredients[1,4]) + (i3 * ingredients[2,4]) + i4 * ingredients[3,4];
                                if (calorieTotal == 500)
                                {
                                    for (int col = 0; col < ingredients.GetLength(1) - 1; col++) //sub 1 to ignore calories
                                    {
                                        int colTot = (i1 * ingredients[0, col]) + (i2 * ingredients[1, col]) + (i3 * ingredients[2, col]) + (i4 * ingredients[3, col]);
                                        if (colTot < 0)
                                        {
                                            colTot = 0;
                                        }

                                        score = score * colTot;
                                    }

                                    if (score > answer)
                                    {
                                        answer = score;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            TimeSpan elapsedTime = Stopwatch.GetElapsedTime(startTime);
            Console.WriteLine("Part 2 runtime: {0}ms. The answer is: {1}", elapsedTime.TotalMilliseconds, answer);
        }

        private static int[,] CleanInput()
        {
            int[,] ingredients = new int[lines.Length, 5];

            for (int row = 0; row < lines.Length; row++)
            {
                string[] s = lines[row].Split(':')[1].Split(",");

                for (int col = 0; col < s.Length; col++)
                {
                    string a = s[col].Trim();
                    ingredients[row, col] = int.Parse(a.Split(" ")[1]);
                }
            }

            return ingredients;

        }

        
    }
}
