using System;

class Solution
{

    // Complete the arrayManipulation function below.
    static long ArrayManipulation(int n, int[][] queries)
    {
        //n = array Size
        long[] arr = new long[n + 2];

        for (int i = 0; i < queries.Length; i++)
        {
            int a = queries[i][0];
            int b = queries[i][1];
            int k = queries[i][2];

            arr[a] += k;
            arr[b + 1] -= k;
        }

        long result = 0;
        for (int i = 1; i <= n; i++)
        {
            arr[i] += arr[i - 1];
            result = Math.Max(arr[i], result);
        }
        return result;
    }

    static void Main(string[] args)
    {

        string[] nm = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nm[0]);

        int m = Convert.ToInt32(nm[1]);

        int[][] queries = new int[m][];

        for (int i = 0; i < m; i++)
        {
            queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
        }

        long result = ArrayManipulation(n, queries);

        Console.WriteLine(result);
    }
}
