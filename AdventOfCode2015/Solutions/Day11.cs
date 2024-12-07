
using System.Diagnostics;

namespace AdventOfCode2015.Solutions
{
    public class Day11
    {
        // --- Day 11: Corporate Policy ---
        // https://adventofcode.com/2015/day/11
        //
        // Requirements:
        // - Santa finds his new password by incrementing his old password string repeatedly
        //   until it is valid. Incrementing is just like counting with numbers: xx, xy, xz,
        //   ya, yb, and so on. Increase the rightmost letter one step; if it was z, it wraps
        //   around to a, and repeat with the next letter to the left until one doesn't wrap around.
        //
        // - Passwords must include one increasing straight of at least three letters, like abc,
        //   bcd, cde, and so on, up to xyz. They cannot skip letters; abd doesn't count.
        //
        // - Passwords may not contain the letters i, o, or l, as these letters can be mistaken
        //   for other characters and are therefore confusing.
        //
        // - Passwords must contain at least two different, non-overlapping pairs of letters, like aa, bb, or zz.



        private static char[] globalPassword = ['v', 'z', 'b', 'x', 'k', 'g', 'h', 'b']; //Santa's starting password vzbxkghb


        public static void Part1(bool overwriteOriginalPassword)
        {
            Stopwatch sw = Stopwatch.StartNew();

            // Copy in Santa's last password
            char[] password = new char[globalPassword.Length];
            for (int i = 0; i < globalPassword.Length; i++)
            {
                password[i] = globalPassword[i];
            }


            // Generate next valid password
            bool isValid = false;
            Int64 loopCounter = 0;
            while(!isValid)
            {
                if (loopCounter > 8031810176) { throw new Exception("Every password has been tried. Possible infinite loop?"); }

                password = IncrementPassword(password);
                isValid = CheckIfValid(password);

                loopCounter++;
            }


            // Parse password into printable string
            string passwordStr = "";
            for (int i = 0;  i < password.Length; i++)
            {
                passwordStr += password[i].ToString();
            }
             
            sw.Stop();


            // Output answer
            Console.WriteLine($"Runtime: {sw.ElapsedMilliseconds}ms.");
            Console.WriteLine($"Santa's terrible password: {passwordStr}");


            // Overwrite starting password for use in Part 2
            if( overwriteOriginalPassword )
            {
                globalPassword = password;
            }
        }
        public static void Part2() 
        {
            Stopwatch sw = Stopwatch.StartNew();

            // Run Part 1 twice to generate 2nd valid password
            Part1(true);
            Part1(false);

            sw.Stop();
            Console.WriteLine("^^^ Part Two answer.");
            Console.WriteLine($"Runtime: {sw.ElapsedMilliseconds}ms.");
        }

        private static char[] IncrementPassword(char[] password)
        {
            bool increment = true;
            for (int i = password.Length - 1; i >= 0; i--)
            {
                if (increment && password[i] == 'z')    // 'z' wraps -> 'a'
                {
                    password[i] = 'a';
                    increment = true;
                }
                else if (increment)
                {
                    password[i]++;
                    increment = false;
                }
            }

            return password;
        }

        private static bool CheckIfValid(char[] password)
        {
            bool checkABC = false;
            bool checkAA = false;
            

            // Check if new password is the same as old password (edge case of wrap around)
            if (password == globalPassword) { return false; }


            // Check if password contains hard to read characters (i, o, l)
            if (password.Contains('i') || password.Contains('o') || password.Contains('l'))
            {
                return false;
            }


            // Check if password contains 3 consecutive letters in ascending order (i.e abc, def)
            for (int i = 0; i < password.Length - 2; i++)
            {
                if (password[i] == password[i + 1] - 1 && password[i] == password[i + 2] - 2)
                {
                    checkABC = true;
                }
            }
            if (!checkABC) { return false; }

            // Check if password contains at least two different, non-overlapping pairs of letters, like aa, bb, or zz.
            int dblLetterCnt = 0;
            char dblLetter = '.';
            for (int i = 0; i < password.Length - 1; i++)
            {
                if (password[i] == password[i + 1] && password[i] != dblLetter)
                {
                    dblLetterCnt++;
                    dblLetter = password[i];
                    i++;
                }

                if (dblLetterCnt >= 2)
                {
                    checkAA = true;
                }
            }
            return checkAA;

        }
    }
}
