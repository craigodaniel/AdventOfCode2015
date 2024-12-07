namespace AdventOfCode2015.Solutions
{
    public class Day14
    {
        // --- Day 14: Reindeer Olympics ---
        // https://adventofcode.com/2015/day/14
        //
        // Part 1:
        // Donner wins! Distance: 2655
        //
        // Part 2:
        // Vixen won! Score: 1059


        private static string fileDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Inputs";
        private static string fileName = "2015_14_input.txt";
        //private static string fileName = "2015_14_test_input.txt";
        private static string[] inputs = File.ReadAllLines(fileDir + "\\" + fileName);


        public static void Part1()
        {
            int raceLegnth = 2503;
            int winnerDistance = 0;
            string winnerName = "";


            foreach (string input in inputs)
            {
                string name = input.Split(" ")[0];
                int speed = int.Parse(input.Split(" ")[3]);
                int fly = int.Parse(input.Split(" ")[6]);
                int rest = int.Parse(input.Split(" ")[13]);
                int period = fly + rest;
                int distance = 0;

                int remainder = raceLegnth % (period);
                if (remainder < fly)
                {
                    distance = (raceLegnth / period) * (speed * fly);
                    if (remainder != 0)
                    {
                        distance += remainder * speed;
                    }
                    Console.WriteLine($"{name} flew {distance} km and is flying.");
                }
                else
                {  
                    distance = (raceLegnth / period) * (speed * fly);
                    distance += (speed * fly);

                    Console.WriteLine($"{name} flew {distance} km and is resting.");
                }


                if (distance > winnerDistance) 
                {
                    winnerDistance = distance;
                    winnerName = name;
                }
            }

            Console.WriteLine($"{winnerName} wins! Distance: {winnerDistance}");
        }


        public static void Part2()
        {
            int raceLength = 2503;
            string[] names = new string[9];
            int[] speeds = new int[9];
            int[] flyTime = new int[9];
            int[] restTime = new int[9];
            int[] distances = new int[9];
            int[] scores = new int[9];
            bool[] isResting = new bool[9];
            int[] timeInStage = new int[9];
            int winnerDistance = 0;


            // Load inputs into arrays
            for (int i = 0; i < inputs.Length; i++)
            {
                names[i] = inputs[i].Split(" ")[0];
                speeds[i] = int.Parse(inputs[i].Split(" ")[3]);
                flyTime[i] = int.Parse(inputs[i].Split(" ")[6]);
                restTime[i] = int.Parse(inputs[i].Split(" ")[13]);
                distances[i] = 0;
                scores[i] = 0;
                isResting[i] = false;
                timeInStage[i] = 0;
            }


            // Run Race
            for (int time = 1; time <= raceLength; time++)
            {
                // Process next second
                for (int i = 0; i < names.Length; i++)
                {
                    timeInStage[i]++;
                    if (isResting[i])
                    {
                        if (timeInStage[i] > restTime[i])
                        {
                            // switch to Flying state
                            isResting[i] = false;
                            timeInStage[i] = 0;
                            i--;
                            continue;
                        }
                    }
                    else
                    {
                        if (timeInStage[i] > flyTime[i])
                        {
                            // switch to Resting stage
                            isResting[i] = true;
                            timeInStage[i] = 0;
                            i--;
                            continue;
                        }
                        else
                        {
                            // fly for 1 sec
                            distances[i] += speeds[i];
                            if (distances[i] > winnerDistance)
                            {
                                winnerDistance = distances[i];
                            }
                        }
                    }
                }

                // Award points to leader(s)
                for (int i =0; i<scores.Length; i++)
                {
                    if (distances[i] == winnerDistance)
                    {
                        scores[i]++;
                    }
                }
                
            }


            // Calculate Winner(s) and Output 
            int highScore = scores.Max();
            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] == highScore)
                {
                    Console.WriteLine($"{names[i]} won! Score: {scores[i]}");
                }
            }


        }
    }
}
