namespace AdventOfCode2015.Solutions
{
    public class Day02
    {
        //---Day 2: I Was Told There Would Be No Math ---
        //https://adventofcode.com/2015/day/2

        private static string fileDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Inputs";
        private static string fileName = "2015_2_input.txt";
        private static string[] inputs = File.ReadAllLines(fileDir + "\\" + fileName);

        public static void Part1()
        {
            //---Day 2: I Was Told There Would Be No Math ---
            //https://adventofcode.com/2015/day/2

            int totalPaperToBuy = 0;

            foreach (string line in inputs)
            {
                string[] dims = line.Split('x');
                int l = int.Parse(dims[0]);
                int w = int.Parse(dims[1]);
                int h = int.Parse(dims[2]);

                int[] surfaceAreas = { l * w, w * h, h * l };
                int totSA = 0;
                foreach (int sa in surfaceAreas)
                {
                    totSA += 2 * sa;
                }
                int smallest = surfaceAreas.Min();

                totalPaperToBuy += smallest + totSA;

                Console.WriteLine("Line: " + line);
                Console.WriteLine("totSA: " + totSA.ToString());
                Console.WriteLine("smallest: " + smallest.ToString());
                Console.WriteLine("Running Total: " + totalPaperToBuy.ToString());

            }
        }
        public static void Part2()
        {
            //---Day 2: I Was Told There Would Be No Math ---
            //https://adventofcode.com/2015/day/2#part2


            int totalRibbonToBuy = 0;

            foreach (string line in inputs)
            {
                string[] dims = line.Split('x');
                int l = int.Parse(dims[0]);
                int w = int.Parse(dims[1]);
                int h = int.Parse(dims[2]);

                int[] perimeters = { 2 * (l + h), 2 * (l + w), 2 * (w + h) };
                int smallest = perimeters.Min();
                int vol = l * w * h;
                int ribbon = smallest + vol;

                totalRibbonToBuy += ribbon;

                Console.WriteLine("Line: " + line);
                Console.WriteLine("vol: " + vol.ToString());
                Console.WriteLine("smallest: " + smallest.ToString());
                Console.WriteLine("ribbon: " + ribbon.ToString());
                Console.WriteLine("Running Total: " + totalRibbonToBuy.ToString());

            }
        }

    }
}
