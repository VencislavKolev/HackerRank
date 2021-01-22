using System;
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
using System.Runtime.Serialization.Formatters;

class Solution
{

	// Complete the reverseArray function below.
	static int[] reverseArray(int[] a)
	{
		int[] reversedArr = new int[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
			reversedArr[i] = a[a.Length - i - 1];
        }
		return reversedArr;
	}

	static void Main(string[] args)
	{
		TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		int arrCount = Convert.ToInt32(Console.ReadLine());

		int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
		int[] res = reverseArray(arr);

		textWriter.WriteLine(string.Join(" ", res));

		textWriter.Flush();
		textWriter.Close();
	}
}
