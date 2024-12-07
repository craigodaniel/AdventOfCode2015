

namespace AdventOfCode2015.Solutions
{
    public class Day13
    {
        // --- Day 13: Knights of the Dinner Table ---
        // https://adventofcode.com/2015/day/13
        //
        // Part 1:
        // Best Order: Alice -> Bob -> Mallory -> Eric -> Carol -> Frank -> David -> George
        // Happiness: 709
        //
        // Part 2:
        // Best Order: Alice -> Bob -> Mallory -> Eric -> Carol -> Frank -> You -> David -> George
        // Happiness: 668


        private static string fileDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Inputs";
        private static string fileName = "2015_13_input.txt";
        //private static string fileName = "2015_13_test_input.txt";
        private static string[] inputs = File.ReadAllLines(fileDir + "\\" + fileName);

        public static void Part1()
        {
            List<Dictionary<string,int>> mapList = new List<Dictionary<string,int>>();
            List<string> guestList = new List<string>();
            List<string> seatingCharts = new List<string>();
            int happinesChangeMax = 0;
            string bestSeatingOrder = "";

            // Convert input into Dictionary List and Guest List
            for (int i  = 0; i < inputs.Length; i++)
            {
                string name = inputs[i].Split(" ")[0];
                string sign = inputs[i].Split(" ")[2];
                int happiness = 0;
                if (sign == "gain") { happiness = int.Parse(inputs[i].Split(" ")[3]); }
                else { happiness = 0 - int.Parse(inputs[i].Split(" ")[3]); }
                string neigbor = inputs[i].Split(" ")[10].Split(".")[0];


                if ( i / 7 > mapList.Count - 1)
                {
                    mapList.Add(new Dictionary<string, int> { });
                    guestList.Add(name);
                }

                mapList[i / 7].Add(neigbor, happiness);

            }


            // Initialize SeatingCharts
            foreach (string guest in  guestList)
            {
                seatingCharts.Add(guest);
            }


            // Create every possible Seating Chart
            int seatingChartsCnt = seatingCharts.Count;
            for (int i = 0; i < seatingCharts.Count; i++)
            {
                bool isChanged = false;
                foreach (string guest in guestList)
                {
                    if (!seatingCharts[i].Contains(guest))
                    {
                        seatingCharts.Add($"{seatingCharts[i]} -> {guest}");
                        isChanged = true;
                    }
                }
                if (isChanged)
                {
                    seatingCharts.RemoveAt(i);
                    i--;
                }

            }


            // Score every Seating Chart and find the best
            foreach (string seatingChart in seatingCharts)
            {
                string[] seatingOrder = seatingChart.Split(" -> ");

                int happinesChange = 0;

                for (int i = 0;i < seatingOrder.Length; i++)
                {
                    string guest = seatingOrder[i];
                    int guestIndex = guestList.IndexOf(guest);
                    string prevGuest = "";
                    string nextGuest = "";

                    if (i == 0) { prevGuest = seatingOrder[seatingOrder.Length - 1]; }
                    else { prevGuest = seatingOrder[i - 1]; }

                    if (i == seatingOrder.Length - 1) { nextGuest = seatingOrder[0]; }
                    else { nextGuest = seatingOrder[i + 1]; }

                    int change1 = mapList[guestIndex][prevGuest];
                    int change2 = mapList[guestIndex][nextGuest];

                    happinesChange += change1 + change2;
                }

                if (happinesChange > happinesChangeMax) { happinesChangeMax = happinesChange; bestSeatingOrder = seatingChart; }
            }


            // Output
            Console.WriteLine($"Best Order: {bestSeatingOrder}");
            Console.WriteLine($"Happiness: {happinesChangeMax}");

        }


        public static void Part2()
        {
            List<Dictionary<string, int>> mapList = new List<Dictionary<string, int>>();
            List<string> guestList = new List<string>();
            List<string> seatingCharts = new List<string>();
            int happinesChangeMax = 0;
            string bestSeatingOrder = "";

            // Convert input into Dictionary List and Guest List
            for (int i = 0; i < inputs.Length; i++)
            {
                string name = inputs[i].Split(" ")[0];
                string sign = inputs[i].Split(" ")[2];
                int happiness = 0;
                if (sign == "gain") { happiness = int.Parse(inputs[i].Split(" ")[3]); }
                else { happiness = 0 - int.Parse(inputs[i].Split(" ")[3]); }
                string neigbor = inputs[i].Split(" ")[10].Split(".")[0];


                if (i / 7 > mapList.Count - 1)
                {
                    mapList.Add(new Dictionary<string, int> { });
                    guestList.Add(name);
                }

                mapList[i / 7].Add(neigbor, happiness);
                if (!mapList[i / 7].ContainsKey("You"))
                {
                    mapList[i / 7].Add("You", 0);
                }

            }


            // Add yourself to Dictionary List and Guest List
            Dictionary<string, int> youDict = new Dictionary<string, int>
            {
                {"Alice", 0},
                {"Bob", 0},
                {"Carol", 0 },
                {"David", 0 },
                {"Eric", 0 },
                {"Frank", 0 },
                {"George", 0 },
                {"Mallory", 0 }
            };
            mapList.Add(youDict);
            guestList.Add("You");

            // Initialize SeatingCharts
            foreach (string guest in guestList)
            {
                seatingCharts.Add(guest);
            }


            // Create every possible Seating Chart
            int seatingChartsCnt = seatingCharts.Count;
            for (int i = 0; i < seatingCharts.Count; i++)
            {
                bool isChanged = false;
                foreach (string guest in guestList)
                {
                    if (!seatingCharts[i].Contains(guest))
                    {
                        seatingCharts.Add($"{seatingCharts[i]} -> {guest}");
                        isChanged = true;
                    }
                }
                if (isChanged)
                {
                    seatingCharts.RemoveAt(i);
                    i--;
                }

            }


            // Score every Seating Chart and find the best
            foreach (string seatingChart in seatingCharts)
            {
                string[] seatingOrder = seatingChart.Split(" -> ");

                int happinesChange = 0;

                for (int i = 0; i < seatingOrder.Length; i++)
                {
                    string guest = seatingOrder[i];
                    int guestIndex = guestList.IndexOf(guest);
                    string prevGuest = "";
                    string nextGuest = "";

                    if (i == 0) { prevGuest = seatingOrder[seatingOrder.Length - 1]; }
                    else { prevGuest = seatingOrder[i - 1]; }

                    if (i == seatingOrder.Length - 1) { nextGuest = seatingOrder[0]; }
                    else { nextGuest = seatingOrder[i + 1]; }

                    int change1 = mapList[guestIndex][prevGuest];
                    int change2 = mapList[guestIndex][nextGuest];

                    happinesChange += change1 + change2;
                }

                if (happinesChange > happinesChangeMax) { happinesChangeMax = happinesChange; bestSeatingOrder = seatingChart; }
            }


            // Output
            Console.WriteLine($"Best Order: {bestSeatingOrder}");
            Console.WriteLine($"Happiness: {happinesChangeMax}");
        }
    }
}
