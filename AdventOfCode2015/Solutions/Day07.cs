
namespace AdventOfCode2015.Solutions
{
    public class Day07
    {
        // --- Day 7: Some Assembly Required ---
        // https://adventofcode.com/2015/day/7

        private static string fileDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
        private static string fileName = "2015_7_input.txt";
        private static string[] lines = File.ReadAllLines(fileDir + "\\" + fileName);
        public static void Part1()
        {
            
            //string[] lines = ["123 -> x", "456 -> y", "x AND y -> d","x OR y -> e","x LSHIFT 2 -> f", "y RSHIFT 2 -> g","NOT x -> h","NOT y -> i"];

            //Assemble Circuit

            Console.WriteLine("Building Circuit...");
            List<string> circuit = BuildCircuit(lines);
            Console.WriteLine("Circuit Built!");

            Dictionary<string,UInt16> wires = new Dictionary<string,UInt16>();
            wires["1"] = 1;

            foreach ( string line in circuit )
            {
                string input = line.Split(" -> ")[0];
                string output = line.Split(" -> ")[1];
                string[] args = input.Split(" ");

                if (input.Contains("AND"))
                {
                    //if (!wires.ContainsKey(args[0])){ wires[args[0]] = 0; }
                    //if (!wires.ContainsKey(args[2])) { wires[args[2]] = 0; }
                    wires[output] = (UInt16)(wires[args[0]] & wires[args[2]]);
                }
                else if (input.Contains("OR"))
                {
                    //if (!wires.ContainsKey(args[0])) { wires[args[0]] = 0; }
                    //if (!wires.ContainsKey(args[2])) { wires[args[2]] = 0; }
                    wires[output] = (UInt16)(wires[args[0]] | wires[args[2]]);
                }
                else if (input.Contains("NOT"))
                {
                    //if (!wires.ContainsKey(args[1])) { wires[args[1]] = 0; }
                    wires[output] = (UInt16)(~wires[args[1]]);
                }
                else if (input.Contains("LSHIFT"))
                {
                    //if (!wires.ContainsKey(args[0])) { wires[args[0]] = 0; }
                    wires[output] = (UInt16)(wires[args[0]] << UInt16.Parse(args[2])) ;
                }
                else if (input.Contains("RSHIFT"))
                {
                    //if (!wires.ContainsKey(args[0])) { wires[args[0]] = 0; }
                    wires[output] = (UInt16)(wires[args[0]] >> UInt16.Parse(args[2]));
                }
                else
                {
                    UInt16 num = 0;
                    bool isNumeric = UInt16.TryParse(args[0], out num);
                    if (isNumeric)
                    {
                        wires[output] = num;
                    }
                    else
                    {
                        //if (!wires.ContainsKey(args[0])) { wires[args[0]] = 0; }
                        wires[output] = (UInt16)(wires[args[0]]);
                    }
                    
                }


                Console.WriteLine(line);

                

            }

            wires.Order();

            foreach (KeyValuePair<string, UInt16> pair in wires)
            {
                Console.WriteLine(pair.Key + ": " + pair.Value.ToString());
            }

            Console.WriteLine("FINISHED!");
            Console.WriteLine("Wire 'a' has value: " + wires["a"].ToString());

        }

        public static void Part2()
        {
            
            //string[] lines = ["123 -> x", "456 -> y", "x AND y -> d","x OR y -> e","x LSHIFT 2 -> f", "y RSHIFT 2 -> g","NOT x -> h","NOT y -> i"];

            //Assemble Circuit

            Console.WriteLine("Building Circuit...");
            List<string> circuit = BuildCircuit(lines);
            Console.WriteLine("Circuit Built!");

            Dictionary<string, UInt16> wires = new Dictionary<string, UInt16>();
            wires["1"] = 1;

            foreach (string line in circuit)
            {
                string input = line.Split(" -> ")[0];
                string output = line.Split(" -> ")[1];
                string[] args = input.Split(" ");

                if (input.Contains("AND"))
                {
                    //if (!wires.ContainsKey(args[0])){ wires[args[0]] = 0; }
                    //if (!wires.ContainsKey(args[2])) { wires[args[2]] = 0; }
                    wires[output] = (UInt16)(wires[args[0]] & wires[args[2]]);
                }
                else if (input.Contains("OR"))
                {
                    //if (!wires.ContainsKey(args[0])) { wires[args[0]] = 0; }
                    //if (!wires.ContainsKey(args[2])) { wires[args[2]] = 0; }
                    wires[output] = (UInt16)(wires[args[0]] | wires[args[2]]);
                }
                else if (input.Contains("NOT"))
                {
                    //if (!wires.ContainsKey(args[1])) { wires[args[1]] = 0; }
                    wires[output] = (UInt16)(~wires[args[1]]);
                }
                else if (input.Contains("LSHIFT"))
                {
                    //if (!wires.ContainsKey(args[0])) { wires[args[0]] = 0; }
                    wires[output] = (UInt16)(wires[args[0]] << UInt16.Parse(args[2]));
                }
                else if (input.Contains("RSHIFT"))
                {
                    //if (!wires.ContainsKey(args[0])) { wires[args[0]] = 0; }
                    wires[output] = (UInt16)(wires[args[0]] >> UInt16.Parse(args[2]));
                }
                else
                {
                    UInt16 num = 0;
                    bool isNumeric = UInt16.TryParse(args[0], out num);
                    if (isNumeric)
                    {
                        wires[output] = num;
                    }
                    else
                    {
                        //if (!wires.ContainsKey(args[0])) { wires[args[0]] = 0; }
                        wires[output] = (UInt16)(wires[args[0]]);
                    }

                }


                Console.WriteLine(line);



            }

            wires.Order();

            foreach (KeyValuePair<string, UInt16> pair in wires)
            {
                Console.WriteLine(pair.Key + ": " + pair.Value.ToString());
            }

            Console.WriteLine("FINISHED!");
            Console.WriteLine("Wire 'a' has value: " + wires["a"].ToString());
        }

        private static List<string> BuildCircuit(string[] lines)
        {
            var circuit = new List<string>();

            foreach (string line in lines)
            {
                circuit.Add(line);
            }

            //loop through circuit lines
            //check if inputs are on outputList
            //if yes, add output to outputList
            //if no, find line where input is output, move it to top of circuit
            //loop to start until no changes are made

            List<string> outputList = new List<string>();

        START_SORT:
            outputList.Clear();
            bool isChanged = false;

            for (int i = 0; i < circuit.Count; i ++)
            {
                string input = circuit[i].Split(" -> ")[0];
                string output = circuit[i].Split(" -> ")[1];
                string[] args = input.Split(" ");
                string arg1 = "!";
                string arg2 = "!";

                if (input.Contains("AND")) //args[0] wire or 1, args[2] wire
                {
                    if (args[0] == "1") 
                    { 
                        arg1 = args[2];
                        arg2 = "!";
                    }    
                    else
                    {
                        arg1 = args[0];
                        arg2 = args[2];
                    }
                    
                }
                else if (input.Contains("OR")) //args[0] wire, args[2] wire
                {
                    arg1 = args[0];
                    arg2 = args[2];
                }
                else if (input.Contains("NOT")) //args[1] wire
                {
                    arg1 = args[1];
                    arg2 = "!";
                }
                else if (input.Contains("LSHIFT")) //args[0] wire, args[2] num
                {
                    arg1 = args[0];
                    arg2 = "!";
                }
                else if (input.Contains("RSHIFT")) //args[0] wire, args[2] num
                {
                    arg1 = args[0];
                    arg2 = "!";
                }
                else //args[0] wire or num
                {
                    UInt16 num = 0;
                    bool isNumeric = UInt16.TryParse(args[0], out num);
                    if (isNumeric)
                    {
                        arg1 = "!";
                        arg2 = "!";
                    }
                    else //args[0] is wire
                    {
                        arg1 = args[0];
                        arg2 = "!";
                    }
                }

                if(arg1 != "!")
                {
                    if (!outputList.Contains(arg1))
                    {
                        int outputIndex = GetIndexOfOutput(circuit, arg1);
                        if (outputIndex == -1)
                        {
                            Console.WriteLine("Could not find -> " + arg1 + " in list!");
                        }
                        else
                        {
                            string moveLine = circuit[outputIndex];
                            circuit.RemoveAt(outputIndex);
                            circuit.Insert(0, moveLine);
                            //goto START_SORT;
                            isChanged = true;
                        }
                    }
                }
                if (arg2 != "!")
                {
                    if (!outputList.Contains(arg2))
                    {
                        int outputIndex = GetIndexOfOutput(circuit, arg2);
                        if (outputIndex == -1)
                        {
                            Console.WriteLine("Could not find -> " + arg2 + " in list!");
                        }
                        else
                        {
                            string moveLine = circuit[outputIndex];
                            circuit.RemoveAt(outputIndex);
                            circuit.Insert(0, moveLine);
                            //goto START_SORT;
                            isChanged = true;
                        }
                    }
                }

                // both args are good
                outputList.Add(output);
                
            }
            
            if (isChanged)
            {
                goto START_SORT;
            }

            return circuit;
        }

        private static int GetIndexOfOutput(List<string> circuit, string input)
        {
            for (int i = 0; i < circuit.Count; i++)
            {
                string output = circuit[i].Split(" -> ")[1];
                if (input == output)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
