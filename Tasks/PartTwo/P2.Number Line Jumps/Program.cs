using System;

class Solution
{

    // Complete the kangaroo function below.
    static string kangaroo(int x1, int v1, int x2, int v2)
    {
        //x1 + y * v1 = x2 + y * v2 where "y" is number of jumps...
        string result = string.Empty;
        if (v1 > v2 && (x2 - x1) % (v2 - v1) == 0)
        {
            result = "YES";
        }
        else
        {
            result = "NO";
        }
        //while (result == string.Empty)
        //{
        //    x1 += v1;
        //    x2 += v2;
        //    if (x1 == x2)
        //    {
        //        result = "YES";
        //    }
        //    else if (x1 + v1 < x2 || x2 + v2 < x1)
        //    {
        //        result = "NO";
        //    }
        //}
        return result;
    }

    static void Main(string[] args)
    {

        string[] x1V1X2V2 = Console.ReadLine().Split(' ');

        int x1 = Convert.ToInt32(x1V1X2V2[0]);

        int v1 = Convert.ToInt32(x1V1X2V2[1]);

        int x2 = Convert.ToInt32(x1V1X2V2[2]);

        int v2 = Convert.ToInt32(x1V1X2V2[3]);

        string result = kangaroo(x1, v1, x2, v2);

        Console.WriteLine(result);
    }
}
