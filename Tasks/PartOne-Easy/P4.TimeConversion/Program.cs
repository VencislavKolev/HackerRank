using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

class Solution
{

    /*
     * Complete the timeConversion function below.
     */
    static string timeConversion(string s)
    {
        string[] timeArgs = s.Split(':');
        string dayPart = timeArgs[timeArgs.Length - 1].Substring(2);

        int hours = int.Parse(timeArgs[0]);
        string minutes = timeArgs[1];
        string seconds = timeArgs[2].Substring(0, 2);

        if (dayPart == "AM")
        {
            if (hours == 12)
            {
                hours -= 12;
            }
        }
        else if (dayPart == "PM")
        {
            if (hours < 12)
            {
                hours += 12;
            }
        }
        return $"{hours:d2}:{minutes}:{seconds}";
    }

    static void Main(string[] args)
    {
        string s = Console.ReadLine();

        string result = timeConversion(s);
        Console.WriteLine(result);
    }
}
