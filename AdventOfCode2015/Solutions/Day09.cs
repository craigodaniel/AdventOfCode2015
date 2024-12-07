using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015.Solutions
{
    public class Day09
    {
        // --- Day 9: All in a Single Night ---
        // https://adventofcode.com/2015/day/9

        
        //private static string[] cities = { "London", "Dublin", "Belfast" };
        private static string[] cities = { "Faerun", "Tristam", "Tambi", "Norrath", "Snowdin", "Straylight", "AlphaCentauri", "Arbre" };
        
        
        private static Dictionary<string, int> GetCityDict(string cityName)
        {
            switch(cityName)
            {
                case "Faerun":
                    return new Dictionary<string, int>
                    {
                        { "Tristam", 65 },
                        {"Tambi", 129 },
                        {"Norrath",144 },
                        {"Snowdin", 71 },
                        {"Straylight", 137},
                        {"AlphaCentauri", 3 },
                        {"Arbre", 149 }
                    };

                case "Tristam":
                    return new Dictionary<string, int>
                    {
                        { "Faerun", 65 },
                        {"Tambi", 63 },
                        {"Norrath", 4 },
                        {"Snowdin", 105 },
                        {"Straylight", 125},
                        {"AlphaCentauri", 55 },
                        {"Arbre", 14 }
                    };

                case "Tambi":
                    return new Dictionary<string, int>
                    {
                        { "Faerun", 129 },
                        {"Tristam", 63 },
                        {"Norrath", 68 },
                        {"Snowdin", 52 },
                        {"Straylight", 65},
                        {"AlphaCentauri", 22 },
                        {"Arbre", 143 }
                    };

                case "Norrath":
                    return new Dictionary<string, int>
                    {
                        { "Faerun", 144 },
                        {"Tristam", 4 },
                        {"Tambi", 68 },
                        {"Snowdin", 8 },
                        {"Straylight", 23},
                        {"AlphaCentauri", 136 },
                        {"Arbre", 115 }
                    };

                case "Snowdin":
                    return new Dictionary<string, int>
                    {
                        { "Faerun", 71 },
                        {"Tristam", 105 },
                        {"Tambi", 52 },
                        {"Norrath", 8 },
                        {"Straylight", 101},
                        {"AlphaCentauri", 84 },
                        {"Arbre", 96 }
                    };

                case "Straylight":
                    return new Dictionary<string, int>
                    {
                        { "Faerun", 137 },
                        {"Tristam", 125 },
                        {"Tambi", 65 },
                        {"Norrath", 23 },
                        {"Snowdin", 101},
                        {"AlphaCentauri", 107 },
                        {"Arbre", 14 }
                    };

                case "AlphaCentauri":
                    return new Dictionary<string, int>
                    {
                        { "Faerun", 3 },
                        {"Tristam", 55 },
                        {"Tambi", 22 },
                        {"Norrath", 136 },
                        {"Snowdin", 84},
                        {"Straylight", 107 },
                        {"Arbre", 46 }
                    };

                case "Arbre":
                    return new Dictionary<string, int>
                    {
                        { "Faerun", 149 },
                        {"Tristam", 14 },
                        {"Tambi", 143 },
                        {"Norrath", 115 },
                        {"Snowdin", 96},
                        {"Straylight", 14 },
                        {"AlphaCentauri", 46 }
                    };


            }
            return new Dictionary<string, int>();
        }

        public static void Part1()
        {
            List<string> tripList = new List<string>();
            int minDistance = 999999999;
            
            foreach(string city in cities) //first pass
            {
                
                tripList.Add($"{city}");
                
            }


            int tripListCnt = tripList.Count;
            for (int i = 0; i < tripList.Count; i++) 
            {
                bool isChanged = false;
                foreach (string city in cities)
                {
                    if (!tripList[i].Contains(city))
                    {
                        tripList.Add($"{tripList[i]} -> {city}");
                        isChanged = true;
                    }
                }
                if (isChanged)
                {
                    tripList.RemoveAt(i);
                    i--;    
                }
                    
            }

            

            foreach (string trip in tripList)
            {
                string[] temp = trip.Split(" -> ");
                if (temp.Length == 8)
                {
                    int distance = 0;
                    for (int i = 0; i < 7; i++)
                    {
                        distance += GetCityDict(temp[i])[temp[i + 1]];
                    }

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        Console.WriteLine($"{trip} -> {distance}");
                    }
                    //Console.WriteLine($"{trip} -> {distance}");
                }
                
            }
            Console.WriteLine($"Total Trips Analyzed: {tripList.Count}");
            Console.WriteLine($"Minimum distance: {minDistance}");

        }

        public static void Part2() 
        {
            List<string> tripList = new List<string>();
            int maxDistance = 0;

            foreach (string city in cities) //first pass
            {

                tripList.Add($"{city}");

            }


            int tripListCnt = tripList.Count;
            for (int i = 0; i < tripList.Count; i++)
            {
                bool isChanged = false;
                foreach (string city in cities)
                {
                    if (!tripList[i].Contains(city))
                    {
                        tripList.Add($"{tripList[i]} -> {city}");
                        isChanged = true;
                    }
                }
                if (isChanged)
                {
                    tripList.RemoveAt(i);
                    i--;
                }

            }



            foreach (string trip in tripList)
            {
                string[] temp = trip.Split(" -> ");
                if (temp.Length == 8)
                {
                    int distance = 0;
                    for (int i = 0;i < 7;i++)
                    {
                        distance += GetCityDict(temp[i])[temp[i + 1]];
                    }

                    if (distance > maxDistance)
                    {
                        maxDistance = distance;
                        Console.WriteLine($"{trip} -> {distance}");
                    }
                    //Console.WriteLine($"{trip} -> {distance}");
                }

            }

            Console.WriteLine($"Total Trips Analyzed: {tripList.Count}");
            Console.WriteLine($"Maximum distance: {maxDistance}");
        }
    }
}
