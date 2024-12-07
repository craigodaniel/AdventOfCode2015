using System.Diagnostics;

namespace AdventOfCode2015.Solutions
{
    public class Day10
    {
        // --- Day 10: Elves Look, Elves Say ---
        // https://adventofcode.com/2015/day/10


        public static void Part1()
        {
            Stopwatch sw = Stopwatch.StartNew();

            List<int> inputs = [1, 3, 2, 1, 1, 3, 1, 1, 1, 2];
            int currentNum = 0;
            int numCnt = 0;

            List<int> temp = new List<int>();

            for (int j = 0; j < 40; j++)
            {
                for (int i = 0; i < inputs.Count; i++)
                {
                    if ( i == 0) 
                    { 
                        currentNum = inputs[i];
                        numCnt = 1;
                        continue;
                    }

                    if (inputs[i] != currentNum)
                    {
                        temp.Add(numCnt);
                        if (currentNum / 10 != 0)
                        {
                            Console.WriteLine($"Error! currentNum: {currentNum} is more than one digit!");
                        }
                        temp.Add(currentNum);
                        currentNum = inputs[i];
                        numCnt = 1;
                    }
                    else
                    {
                        numCnt++;
                    }
                }

                temp.Add(numCnt);
                if (currentNum / 10 != 0)
                {
                    Console.WriteLine($"Error! currentNum: {currentNum} is more than one digit!");
                }
                temp.Add(currentNum);

                inputs.Clear();
                for (int i = 0; i < temp.Count; i++)
                {
                    inputs.Add(temp[i]);
                }
                temp.Clear();

                /*
                string result = "";
                for (int i = 0; i < inputs.Count ; i++)
                {
                    result += $"-{inputs[i]}";
                }
                Console.WriteLine(result);
                */

                //Console.WriteLine(inputs.Count.ToString());
            }



            sw.Stop();
            Console.WriteLine($"Runtime: {sw.ElapsedMilliseconds}ms");

            Console.WriteLine($"Result legnth: {inputs.Count}");
        }

        public static void Part2()
        {
            Stopwatch sw = Stopwatch.StartNew();

            List<int> inputs = [1, 3, 2, 1, 1, 3, 1, 1, 1, 2];
            int currentNum = 0;
            int numCnt = 0;

            List<int> temp = new List<int>();

            for (int j = 0; j < 50; j++)
            {
                for (int i = 0; i < inputs.Count; i++)
                {
                    if (i == 0)
                    {
                        currentNum = inputs[i];
                        numCnt = 1;
                        continue;
                    }

                    if (inputs[i] != currentNum)
                    {
                        temp.Add(numCnt);
                        if (currentNum / 10 != 0)
                        {
                            Console.WriteLine($"Error! currentNum: {currentNum} is more than one digit!");
                        }
                        temp.Add(currentNum);
                        currentNum = inputs[i];
                        numCnt = 1;
                    }
                    else
                    {
                        numCnt++;
                    }
                }

                temp.Add(numCnt);
                if (currentNum / 10 != 0)
                {
                    Console.WriteLine($"Error! currentNum: {currentNum} is more than one digit!");
                }
                temp.Add(currentNum);

                inputs.Clear();
                for (int i = 0; i < temp.Count; i++)
                {
                    inputs.Add(temp[i]);
                }
                temp.Clear();

                /*
                string result = "";
                
                for (int i = 0; i < inputs.Count ; i++)
                {
                    result += $"-{inputs[i]}";
                }
                Console.WriteLine(result);
                */

                //Console.WriteLine(inputs.Count.ToString());
            }



            sw.Stop();
            Console.WriteLine($"Runtime: {sw.ElapsedMilliseconds}ms");

            Console.WriteLine($"Result legnth: {inputs.Count}");
        }

    }
}
