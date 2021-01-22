using System;
using System.Linq;
using System.Collections.Generic;

class Result
{

    /*
     * Complete the 'dynamicArray' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. 2D_INTEGER_ARRAY queries
     */

    public static List<int> dynamicArray(int n, List<List<int>> queries)
    {
        List<int> outputArr = new List<int>(2);
        int lastAnswer = 0;

        List<List<int>> arr = new List<List<int>>(n);
        for (int i = 0; i < arr.Capacity; i++)
        {
            arr.Add(new List<int>());
        }

        for (int i = 0; i < queries.Count; i++)
        {
            int type = queries[i][0];
            int x = queries[i][1];
            int y = queries[i][2];

            int idx = (x ^ lastAnswer) % n;

            if (type == 1)
            {
                arr[0].Add(y);

            }
            else
            {
                int idxAtArr = y % arr[idx].Count;
                int element = arr[idx][idxAtArr];

                lastAnswer = element;
                outputArr.Add(lastAnswer);
            }
        }
        return outputArr;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int q = Convert.ToInt32(firstMultipleInput[1]);

        List<List<int>> queries = new List<List<int>>();

        for (int i = 0; i < q; i++)
        {
            queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
        }

        List<int> result = Result.dynamicArray(n, queries);
        Console.WriteLine(string.Join(" ", result));
        //textWriter.WriteLine(String.Join("\n", result));

        //textWriter.Flush();
        //textWriter.Close();
    }
}
