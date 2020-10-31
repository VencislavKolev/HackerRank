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

    // Complete the plusMinus function below.
    static void plusMinus(int[] arr)
    {
        int posNumbers = 0;
        int negNumbers = 0;
        int zero = 0;
        foreach (var number in arr)
        {
            if (number == 0)
            {
                zero++;
            }
            else if (number > 0)
            {
                posNumbers++;
            }
            else
            {
                negNumbers++;
            }
        }
        var posRatio = posNumbers * 1.0 / arr.Length;
        var negRatio = negNumbers * 1.0 / arr.Length;
        var zeroRatio = zero * 1.0 / arr.Length;
        Console.WriteLine($"{posRatio:f6}");
        Console.WriteLine($"{negRatio:f6}");
        Console.WriteLine($"{zeroRatio:f6}");
    }

    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        plusMinus(arr);
    }
}
