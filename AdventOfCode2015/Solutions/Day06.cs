namespace AdventOfCode2015.Solutions
{
    public class Day06
    {
        // --- Day 6: Probably a Fire Hazard ---
        // https://adventofcode.com/2015/day/6

        private static string fileDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Inputs";
        private static string fileName = "2015_6_input.txt";
        private static string[] inputs = File.ReadAllLines(fileDir + "\\" + fileName);
        public static void Part1()
        {
            
            //string[] inputs = { "turn on 0,0 through 999,999", "toggle 0,0 through 999,0", "turn off 499,499 through 500,500" };

            int[,] lights = new int[1000, 1000];
            int litCnt = 0;

            foreach (string input in inputs)
            {
                string instruction = "";
                int x1 = -1;
                int x2 = -1;
                int y1 = -1;
                int y2 = -1;
                bool isNumeric = false;

                string cleanInput = input.Trim();
                string[] parts = cleanInput.Split(" ");

                if (parts[0] == "turn")
                {
                    instruction = parts[1];

                    isNumeric = int.TryParse(parts[2].Split(",")[0],out x1);
                    if (!isNumeric ) { Console.WriteLine("Could not determine x1 from: " + input); }

                    isNumeric = int.TryParse(parts[2].Split(",")[1], out y1);
                    if (!isNumeric ) { Console.WriteLine("Could not determine y1 from: " + input); }

                    isNumeric = int.TryParse(parts[4].Split(",")[0], out x2);
                    if (!isNumeric) { Console.WriteLine("Could not determine x2 from: " + input); }

                    isNumeric = int.TryParse(parts[4].Split(",")[1], out y2);
                    if (!isNumeric) { Console.WriteLine("Could not determine y2 from: " + input); }

                }
                else if (parts[0] == "toggle")
                {
                    instruction = parts[0];

                    isNumeric = int.TryParse(parts[1].Split(",")[0], out x1);
                    if (!isNumeric) { Console.WriteLine("Could not determine x1 from: " + input); }

                    isNumeric = int.TryParse(parts[1].Split(",")[1], out y1);
                    if (!isNumeric) { Console.WriteLine("Could not determine y1 from: " + input); }

                    isNumeric = int.TryParse(parts[3].Split(",")[0], out x2);
                    if (!isNumeric) { Console.WriteLine("Could not determine x2 from: " + input); }

                    isNumeric = int.TryParse(parts[3].Split(",")[1], out y2);
                    if (!isNumeric) { Console.WriteLine("Could not determine y2 from: " + input); }
                }

                for (int x = x1;  x <= x2; x++)
                {
                    for (int y = y1; y <= y2; y++)
                    {
                        switch(instruction)
                        {
                            case "on":
                                lights[x, y] = 1;
                                break;

                            case "off":
                                lights[x,y] = 0;
                                break;

                            case "toggle":
                                if (lights[x, y] == 0) 
                                {
                                    lights[x, y] = 1;
                                }
                                else
                                {
                                    lights[x, y] = 0;
                                }
                                break;
                        }
                    }
                }
            }

            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                    litCnt += lights[x, y];
                }
            }

            Console.WriteLine(litCnt.ToString() + " lights are on!");
        }
        public static void Part2()
        {
            
            //string[] inputs = { "turn on 0,0 through 999,999", "toggle 0,0 through 999,0", "turn off 499,499 through 500,500" };

            int[,] lights = new int[1000, 1000];
            int totBrightness = 0;

            foreach (string input in inputs)
            {
                string instruction = "";
                int x1 = -1;
                int x2 = -1;
                int y1 = -1;
                int y2 = -1;
                bool isNumeric = false;

                string cleanInput = input.Trim();
                string[] parts = cleanInput.Split(" ");

                if (parts[0] == "turn")
                {
                    instruction = parts[1];

                    isNumeric = int.TryParse(parts[2].Split(",")[0], out x1);
                    if (!isNumeric) { Console.WriteLine("Could not determine x1 from: " + input); }

                    isNumeric = int.TryParse(parts[2].Split(",")[1], out y1);
                    if (!isNumeric) { Console.WriteLine("Could not determine y1 from: " + input); }

                    isNumeric = int.TryParse(parts[4].Split(",")[0], out x2);
                    if (!isNumeric) { Console.WriteLine("Could not determine x2 from: " + input); }

                    isNumeric = int.TryParse(parts[4].Split(",")[1], out y2);
                    if (!isNumeric) { Console.WriteLine("Could not determine y2 from: " + input); }

                }
                else if (parts[0] == "toggle")
                {
                    instruction = parts[0];

                    isNumeric = int.TryParse(parts[1].Split(",")[0], out x1);
                    if (!isNumeric) { Console.WriteLine("Could not determine x1 from: " + input); }

                    isNumeric = int.TryParse(parts[1].Split(",")[1], out y1);
                    if (!isNumeric) { Console.WriteLine("Could not determine y1 from: " + input); }

                    isNumeric = int.TryParse(parts[3].Split(",")[0], out x2);
                    if (!isNumeric) { Console.WriteLine("Could not determine x2 from: " + input); }

                    isNumeric = int.TryParse(parts[3].Split(",")[1], out y2);
                    if (!isNumeric) { Console.WriteLine("Could not determine y2 from: " + input); }
                }

                for (int x = x1; x <= x2; x++)
                {
                    for (int y = y1; y <= y2; y++)
                    {
                        switch (instruction)
                        {
                            case "on":
                                lights[x, y] = lights[x, y] + 1;
                                break;

                            case "off":
                                lights[x, y] = lights[x, y] - 1;
                                if (lights[x,y] < 0) { lights[x, y] = 0; }
                                break;

                            case "toggle":
                                lights[x, y] = lights[x, y] + 2;
                                break;
                        }
                    }
                }
            }

            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                    totBrightness += lights[x, y];
                }
            }

            Console.WriteLine("Total Brightness: " + totBrightness.ToString());
        }
    }
}
