using System;

class Solution
{

    // Complete the countApplesAndOranges function below.
    static void countApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges)
    {
        int appleTreePos = a;
        int orangeTreePos = b;
        int validApples = 0;
        int validOranges = 0;

        foreach (var position in apples)
        {
            int currLocation = appleTreePos + position;
            if (currLocation >= s && currLocation <= t)
            {
                validApples++;
            }
        }
        foreach (var position in oranges)
        {
            int currLocation = orangeTreePos + position;
            if (currLocation >= s && currLocation <= t)
            {
                validOranges++;
            }
        }
        Console.WriteLine(validApples);
        Console.WriteLine(validOranges);
    }

    static void Main(string[] args)
    {
        string[] st = Console.ReadLine().Split(' ');

        int s = Convert.ToInt32(st[0]);

        int t = Convert.ToInt32(st[1]);

        string[] ab = Console.ReadLine().Split(' ');

        int a = Convert.ToInt32(ab[0]);

        int b = Convert.ToInt32(ab[1]);

        string[] mn = Console.ReadLine().Split(' ');

        int m = Convert.ToInt32(mn[0]);

        int n = Convert.ToInt32(mn[1]);

        int[] apples = Array.ConvertAll(Console.ReadLine().Split(' '), applesTemp => Convert.ToInt32(applesTemp))
        ;

        int[] oranges = Array.ConvertAll(Console.ReadLine().Split(' '), orangesTemp => Convert.ToInt32(orangesTemp))
        ;
        countApplesAndOranges(s, t, a, b, apples, oranges);
    }
}
