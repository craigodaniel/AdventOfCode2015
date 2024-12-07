using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015.Solutions
{
    public class Day05
    {
        // --- Day 5: Doesn't He Have Intern-Elves For This? ---
        // https://adventofcode.com/2015/day/5

        private static string fileDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Inputs";
        private static string fileName = "2015_5_input.txt";
        private static string[] inputs = File.ReadAllLines(fileDir + "\\" + fileName);
        public static void Part1()
        {

            string[] vowels = { "a", "e", "i", "o", "u" };
            string[] badStrings = { "ab", "cd", "pq", "xy" };
            int goodStringCnt = 0;
            

            foreach (string input in inputs)
            {
                int vowelCnt = 0;
                bool hasThreeVowels = false;
                bool hasDblLetters = false;
                bool hasBadString = false;

                for (int i = 0; i < input.Length; i++)
                {
                    if (vowels.Contains(input[i].ToString()))
                    {
                        //Console.WriteLine(input + " has vowel: " + input[i].ToString());
                        vowelCnt++;
                    }

                    if(i < input.Length - 1)
                    {
                        if (badStrings.Contains(input[i].ToString() + input[i + 1].ToString()))
                        {
                            //Console.WriteLine(input + " has bad string: " + input[i] + input[i + 1]);
                            hasBadString = true;
                        }

                        if (input[i] == input[i + 1])
                        {
                            //Console.WriteLine(input + " has double letters: " + input[i] + input[i+1]);
                            hasDblLetters = true;
                        }
                    }

                    if ( vowelCnt >= 3)
                    {
                        //Console.WriteLine(input + " has at least three vowels: " + vowelCnt.ToString());
                        hasThreeVowels = true;
                    }

                }
                
                if(hasThreeVowels && hasDblLetters && !hasBadString)
                {
                    Console.WriteLine(input + " is a nice string!");
                    goodStringCnt++;
                }
                else
                {
                    Console.WriteLine(input + " is a naughty string!");
                }

            }

            Console.WriteLine("Nice String Count: " + goodStringCnt.ToString());


        }
        public static void Part2() 
        {
            // Try 1: 170 was too high...i was checking for double letter (i.e. "aa", "bb") not pairs!
            // Try 2: 58 INCORRECT...fails edge case "wwkk" after removing center wk and checking for pairs finds "wk" from outer
            // Try 3: 51 CORRECT!


            //string[] inputs = {"xyxy", "aabcdefgaa", "aaa", "xyx", "abcdefeghi", "qjhvhtzxzqqjkmpb", "xxyxx", "uurcxstgmygtbstg", "ieodomkazucvgmuy"};

            int niceStringCnt = 0;


            foreach (string input in inputs)
            {
                bool hasPairNonOverlapping = false;
                bool hasSandwich = false;

                for (int i = 0; i < input.Length -1; i++)
                {
                    string pair = input[i].ToString() + input[i + 1].ToString();
                    string check = ReplaceAt(input, i, ' ');
                    check = ReplaceAt(check, i + 1, ' ');
                    

                    if (check.Contains(pair))
                    {
                        Console.WriteLine("check: " + check + " contains pair: " +  pair);
                        hasPairNonOverlapping = true;
                    }

                    if (i < input.Length - 2)
                    {
                        if (input[i] == input[i + 2])
                        {
                            hasSandwich = true;
                        }
                    }
                }

                Console.WriteLine(input + " " + hasPairNonOverlapping.ToString() + hasSandwich.ToString());
                if (hasPairNonOverlapping && hasSandwich)
                {
                    Console.WriteLine(input + " is NICE!");
                    niceStringCnt++;
                }
                else
                {
                    Console.WriteLine(input + " is NAUGHTY!");
                }
            }

            Console.WriteLine("Nice String Count: " + niceStringCnt.ToString());
        }

        public static string ReplaceAt(string input, int index, char newChar)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            char[] chars = input.ToCharArray();
            chars[index] = newChar;
            return new string(chars);
        }
    }


}
