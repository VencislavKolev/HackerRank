using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the hourglassSum function below.
    static int hourglassSum(int[][] arr)
    {
        List<List<int>> allSums = new List<List<int>>();

        for (int row = 0; row < arr.Length - 2; row++)
        {
            for (int col = 0; col < arr[row].Length - 2; col++)
            {
                int topBottomCol = col;
                int middleCol = topBottomCol + 1;
                List<int> currHourGlass = new List<int>()
                {
                    arr[row][topBottomCol],
                    arr[row][topBottomCol + 1],
                    arr[row][topBottomCol + 2],

                    arr[row+1][middleCol],

                    arr[row+2][topBottomCol],
                    arr[row+2][topBottomCol + 1],
                    arr[row+2][topBottomCol + 2],
                };
                allSums.Add(currHourGlass);
            }
        }

        return allSums.Max(x => x.Sum());
    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int[][] arr = new int[6][];

        for (int i = 0; i < 6; i++)
        {
            arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        }

        int result = hourglassSum(arr);
        Console.WriteLine(result);
        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
