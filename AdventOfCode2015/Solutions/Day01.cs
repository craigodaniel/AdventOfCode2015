namespace AdventOfCode2015.Solutions
{
    public class Day01
    {
        //--- Day 1: Not Quite Lisp ---
        //https://adventofcode.com/2015/day/1

        private static string fileDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Inputs";
        private static string fileName = "y_2015_day_1_part_1_input.txt";
        private static string[] input = File.ReadAllLines(fileDir + "\\" + fileName);
        public static void Part1()
        {
            int sum = 0;
            
            foreach (string line in input)
            {
                foreach (char c in line)
                {
                    if (c.ToString() == "(") { sum++; }
                    else if (c.ToString() == ")") { sum--; }
                }
            }

            Console.WriteLine("Result: " + sum.ToString());
        }
        public static void Part2()
        {

            int sum = 0;

            foreach (string line in input)
            {
                bool isUpstairs = true; //Santa always starts at 0 (first floor)
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i].ToString() == "(")
                    {
                        sum++;
                    }
                    else if (line[i].ToString() == ")")
                    {
                        sum--;
                    }

                    int pos = i + 1;

                    if (isUpstairs && sum == -1)
                    {
                        Console.WriteLine("Santa enters basement at position: " + pos.ToString());

                    }
                    else if (!isUpstairs && sum == 0)
                    {
                        Console.WriteLine("Santa exits basement at position: " + pos.ToString());
                    }

                    if (sum >= 0)
                    {
                        isUpstairs = true;
                    }
                    else
                    {
                        isUpstairs = false;
                    }

                }
            }

        }
    }
}
