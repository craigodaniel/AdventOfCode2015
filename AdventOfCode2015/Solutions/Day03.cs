namespace AdventOfCode2015.Solutions
{
    public class Day03
    {
        //--- Day 3: Perfectly Spherical Houses in a Vacuum ---
        //https://adventofcode.com/2015/day/3

        private static string fileDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Inputs";
        private static string fileName = "2015_3_input.txt";
        private static string inputs = File.ReadAllText(fileDir + "\\" + fileName);
        public static void Part1()
        {
            //--- Day 3: Perfectly Spherical Houses in a Vacuum ---
            //https://adventofcode.com/2015/day/3

            //thoughts...
            //create List of (x,y) coord's.
            //check if new coord's exits in List
            //if not add to list
            //count num of coord's in list.


            List<(int, int)> visitList = [(0, 0)];
            int x = 0;
            int y = 0;
            int houses = 1; //includes starting house

            foreach (char input in inputs)
            {
                Console.WriteLine("Input: " + input.ToString());

                switch (input.ToString())
                {
                    case ">":
                        x++;
                        break;

                    case "<":
                        x--;
                        break;

                    case "^":
                        y++;
                        break;

                    case "v":
                        y--;
                        break;
                }

                if (visitList.Contains((x, y)))
                {
                    Console.WriteLine("Santa was here!");
                }
                else
                {
                    visitList.Add((x, y));
                    Console.WriteLine("New house!");
                    houses++;
                    Console.WriteLine("House Count: " + houses.ToString());

                }

            }

            Console.WriteLine("TOTAL HOUSES VISITED: " + houses.ToString());
        }
        public static void Part2()
        {
            //--- Day 3: Perfectly Spherical Houses in a Vacuum ---
            //https://adventofcode.com/2015/day/3#part2

            //Same idea as part one except...
            //track santa and robo-santa coord's seprately
            //use for i loop
            // i mod 2 = 0 for santa inputs, i mod 2 = 1 for robo-santa inputs


            List<(int, int)> visitList = [(0, 0)];
            int santaX = 0;
            int santaY = 0;
            int roboX = 0;
            int roboY = 0;

            for (int i = 0; i < inputs.Length; i++)
            {
                if (i % 2 == 0) //santa's turn
                {
                    switch (inputs[i].ToString())
                    {
                        case ">":
                            santaX++;
                            break;

                        case "<":
                            santaX--;
                            break;

                        case "^":
                            santaY++;
                            break;

                        case "v":
                            santaY--;
                            break;
                    }

                    if (!visitList.Contains((santaX, santaY)))
                    {
                        visitList.Add((santaX, santaY));
                        Console.WriteLine("Santa visits a new house!");
                        Console.WriteLine("House Count: " + visitList.Count.ToString());
                    }
                }
                else if (i % 2 == 1) //robo's turn
                {
                    switch (inputs[i].ToString())
                    {
                        case ">":
                            roboX++;
                            break;

                        case "<":
                            roboX--;
                            break;

                        case "^":
                            roboY++;
                            break;

                        case "v":
                            roboY--;
                            break;
                    }

                    if (!visitList.Contains((roboX, roboY)))
                    {
                        visitList.Add((roboX, roboY));
                        Console.WriteLine("Robo-Santa visits a new house!");
                        Console.WriteLine("House Count: " + visitList.Count.ToString());
                    }
                }
            }

            Console.WriteLine("TOTAL HOUSES VISITED: " + visitList.Count.ToString());
        }
    }
}
