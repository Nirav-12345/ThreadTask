﻿using System;

namespace EmployeePayrollOpr;

class Program
{
    public static void Main(string[] args)
    {
        //List<EmployeeDeatails> employeeDeatails = new List<EmployeeDeatails>();

        // employeeDeatails.Add(new EmployeeDeatails(1, "nirav", "676868", "Asansol", "Hr", 'M', 5768.00, 776.00, 546.00, 577.00, "asansol", "India"));
        //employeeDeatails.Add(new EmployeeDeatails(2, "Roger", "676868", "Viena", "Hr", 'M', 5768.00, 776.00, 546.00, 577.00, "asansol", "Vietnanm"));
        // employeeDeatails.Add(new EmployeeDeatails(3, "Alpha", "676868", "Canda", "Hr", 'M', 5768.00, 776.00, 546.00, 577.00, "asansol", "Malaysia"));
        // employeeDeatails.Add(new EmployeeDeatails(4, "Bayek", "676868", "Egypt", "Hr", 'M', 5768.00, 776.00, 546.00, 577.00, "asansol", "Canada"));
        // employeeDeatails.Add(new EmployeeDeatails(5, "Gg", "676868", "Fb.GG", "Hr", 'M', 5768.00, 776.00, 546.00, 577.00, "asansol", "USA"));

        // EmployeePayrollOpreation employeePayrollOpreation = new EmployeePayrollOpreation();
        //employeePayrollOpreation.EmployeePalyRoll(employeeDeatails);

        // employeePayrollOpreation.EmployeePalyRoll(employeeDeatails);

        //Parallel Threading

        string[] words = CreateWordArray(@"http://www.gutenberg.org/files/54700/54700-0.txt");

        Parallel.Invoke(() =>
        {
            Console.WriteLine("Begin first task.....");
            GetLongestWord(words);
        },

        () =>
        {
            Console.WriteLine("Begin second task....");
            GetMostCommonWords(words);
        },
        () =>
        {
            Console.WriteLine("Begin third task....");
            GetCountForWords(words, "sleep");
        }
    );

        static string[] CreateWordArray(string uri)
        {
            Console.WriteLine($"Retrieving from {uri}");
            string s = new System.Net.WebClient().DownloadString(uri);

            return s.Split(
                new char[] { ' ', '\u000A', ',', '.', ';', ':', '-', '_', '/' },
                StringSplitOptions.RemoveEmptyEntries);
        }
    }

    private static string GetLongestWord(string[] words)
    {
        var longestWord = (from w in words
                           orderby w.Length descending
                           select w).First();
        Console.WriteLine($"Task 1 -- The LONGEST WORD is {longestWord}");
        return longestWord;
    }

    private static void GetCountForWords(string[] words, string term)
    {
        var findwords = from word in words
                        where word.ToUpper().Contains(term.ToUpper())
                        select word;
        Console.WriteLine($@"Task 3 ---- the word ""{term}"" occurs {findwords.Count()} times.");

    }

    private static void GetMostCommonWords(string[] words)
    {
        var frequencyorder = from word in words
                             where word.Length > 6
                             group word by word into g
                             orderby g.Count() descending
                             select g.Key;

        var commanwords = frequencyorder.Take(10);
        System.Text.StringBuilder sb = new StringBuilder();
        sb.AppendLine("Task 2 -- the most common words are :");
        foreach (var v in commanwords)
        {
            sb.AppendLine(" " + v);
        }
        Console.WriteLine(sb.ToString());
    }


}
