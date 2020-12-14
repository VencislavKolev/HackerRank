using System;
using System.Linq;
using System.Collections.Generic;

namespace Solution
{
    public class Solution
    {
        public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
        {
            Dictionary<string, int> companyAverageAgeDict = new Dictionary<string, int>();
            foreach (var employee in employees)
            {
                string companyName = employee.Company;
                if (!companyAverageAgeDict.ContainsKey(companyName))
                {
                    companyAverageAgeDict[companyName] = 0;
                }
                double averAge = employees
                       .Where(x => x.Company == companyName)
                       .Select(x => x.Age)
                       .Average();

                int finalAge = (int)Math.Round(averAge);
                companyAverageAgeDict[companyName] = finalAge;
            }
            companyAverageAgeDict = companyAverageAgeDict
                .OrderBy(x => x.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            return companyAverageAgeDict;
        }

        public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
        {
            var employeesInCompany = new Dictionary<string, int>();
            foreach (var employee in employees)
            {
                string companyName = employee.Company;
                if (!employeesInCompany.ContainsKey(companyName))
                {
                    employeesInCompany[companyName] = default;
                }

                int count = employees
                    .Where(x => x.Company == companyName)
                    .Count();
                employeesInCompany[companyName] = count;
            }

            employeesInCompany = employeesInCompany
                .OrderBy(x => x.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            return employeesInCompany;
        }

        public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
        {
            var tempDict = new Dictionary<string, List<int>>();
            foreach (var employee in employees)
            {
                string companyName = employee.Company;
                if (!tempDict.ContainsKey(companyName))
                {
                    tempDict[companyName] = new List<int>();
                }
                tempDict[companyName].Add(employee.Age);
            }

            var finalDict = new Dictionary<string, Employee>();
            foreach (var kvp in tempDict)
            {
                string name = kvp.Key;
                int maxAge = tempDict[name].Max();
                Employee employee = employees.FirstOrDefault(x => x.Age == maxAge);
                finalDict[name] = employee;
            }

            finalDict = finalDict.OrderBy(a => a.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            return finalDict;
        }

        public static void Main()
        {
            int countOfEmployees = int.Parse(Console.ReadLine());

            var employees = new List<Employee>();

            for (int i = 0; i < countOfEmployees; i++)
            {
                string str = Console.ReadLine();
                string[] strArr = str.Split(' ');
                employees.Add(new Employee
                {
                    FirstName = strArr[0],
                    LastName = strArr[1],
                    Company = strArr[2],
                    Age = int.Parse(strArr[3])
                });
            }

            foreach (var emp in AverageAgeForEachCompany(employees))
            {
                Console.WriteLine($"The average age for company {emp.Key} is {emp.Value}");
            }

            foreach (var emp in CountOfEmployeesForEachCompany(employees))
            {
                Console.WriteLine($"The count of employees for company {emp.Key} is {emp.Value}");
            }

            foreach (var emp in OldestAgeForEachCompany(employees))
            {
                Console.WriteLine($"The oldest employee of company {emp.Key} is {emp.Value.FirstName} {emp.Value.LastName} having age {emp.Value.Age}");
            }
        }
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
    }
}
//Sample inputs:

//            12
//Sybila Fulle Kimberly 24
//Scarface Stork Tesla 22
//Ashli Crosseland Kimberly 36
//Allene Stebbings Galaxy 19
//Valentin Harbert Amazon 28
//Gracie Pappin Tesla 44
//Sadye Orcott Rockwell 30
//Timoteo Pook Amazon 35
//Marris Apdell Rockwell 43
//Pen Ghilardini Rockwell 38
//Bern Aizikov Rockwell 20
//Sela Farrier Amazon 47


//            12
//Ainslee Ginsie Galaxy 28
//Libbey Apdell Starbucks 44
//Illa Stebbings Berkshire 49
//Laina Sycamore Berkshire 20
//Abbe Parnell Amazon 20
//Ludovika Reveley Berkshire 30
//Rene Antos Galaxy 44
//Vinson Beckenham Berkshire 45
//Reed Lynock Amazon 41
//Wyndham Bamfield Berkshire 34
//Loraine Sappson Amazon 49
//Abbe Antonutti Starbucks 47