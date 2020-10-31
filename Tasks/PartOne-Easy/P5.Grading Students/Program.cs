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

class Result
{

    /*
     * Complete the 'gradingStudents' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY grades as parameter.
     */

    public static List<int> gradingStudents(List<int> grades)
    {
        List<int> roundedGrades = new List<int>();
        for (int i = 0; i < grades.Count; i++)
        {
            if (grades[i] >= 38)
            {
                int increaseValue = 0;
                int lastDigit = grades[i] % 10;
                if (lastDigit <= 5)
                {
                    increaseValue = 5 - lastDigit;
                    if (increaseValue <= 2)
                    {
                        grades[i] += increaseValue;
                    }
                }
                else if (lastDigit >= 8)
                {
                    increaseValue = 10 - lastDigit;
                    grades[i] += increaseValue;
                }
            }
            roundedGrades.Add(grades[i]);
        }
        return roundedGrades;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int gradesCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> grades = new List<int>();

        for (int i = 0; i < gradesCount; i++)
        {
            int gradesItem = Convert.ToInt32(Console.ReadLine().Trim());
            grades.Add(gradesItem);
        }

        List<int> result = Result.gradingStudents(grades);

        Console.WriteLine(String.Join("\n", result));
    }
}
