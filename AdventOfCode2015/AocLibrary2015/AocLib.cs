using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015.AocLibrary2015
{
    public class AocLib
    {
        public static void Print2dIntArray(int[,] array)
        {
            for (int row = 0; row < array.GetLength(0); row++)
            {
                StringBuilder sb = new StringBuilder();

                for (int col = 0; col < array.GetLength(1); col++)
                {
                    sb.Append(array[row, col].ToString() + " ");
                }

                Console.WriteLine(sb.ToString());
            }
        }
    }
}
