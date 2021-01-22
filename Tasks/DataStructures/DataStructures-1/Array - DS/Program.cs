using System;
using System.IO;

class Solution
{

    // Complete the reverseArray function below.
    static int[] reverseArray(int[] a)
    {

        var reversedArr = new int[a.Length];
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

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int[] res = reverseArray(arr);

        textWriter.WriteLine(string.Join(" ", res));

        textWriter.Flush();
        textWriter.Close();
    }
}
