using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{

    // Complete the matchingStrings function below.
    static int[] MatchingStrings(string[] strings, string[] queries)
    {

        Dictionary<string, int> stringsDict = new Dictionary<string, int>();

        foreach (var s in strings)
        {
            if (!stringsDict.ContainsKey(s))
            {
                stringsDict[s] = 0;
            }

            stringsDict[s]++;
        }

        int[] result = new int[queries.Length];
        int counter = 0;
        foreach (var q in queries)
        {
            //if (stringsDict.ContainsKey(q))
            //{
            //    result[counter++] = stringsDict[q];
            //}
            //else
            //{
            //    result[counter++] = 0;
            //}

            result[counter++] = stringsDict.ContainsKey(q) ? stringsDict[q] : 0;
        }

        return result;
    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int stringsCount = Convert.ToInt32(Console.ReadLine());

        string[] strings = new string[stringsCount];

        for (int i = 0; i < stringsCount; i++)
        {
            string stringsItem = Console.ReadLine();
            strings[i] = stringsItem;
        }

        int queriesCount = Convert.ToInt32(Console.ReadLine());

        string[] queries = new string[queriesCount];

        for (int i = 0; i < queriesCount; i++)
        {
            string queriesItem = Console.ReadLine();
            queries[i] = queriesItem;
        }

        int[] res = MatchingStrings(strings, queries);

        //textWriter.WriteLine(string.Join("\n", res));

        //textWriter.Flush();
        //textWriter.Close();
    }
}