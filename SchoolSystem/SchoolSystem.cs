using System;
using System.Collections.Generic;
using System.Linq;

class SchoolSystem
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var students = new SortedDictionary<string, SortedDictionary<string, List<double>>>();
        for (int i = 0; i < n; i++)
        {
            var info = Console.ReadLine().Split(' ');
            var fullName = string.Format("{0} {1}", info[0], info[1]);
            var subject = info[2];
            var mark = double.Parse(info[3]);
            if (!students.Keys.Contains(fullName))
            {
                students[fullName] = new SortedDictionary<string, List<double>>();

            }
            if (!students[fullName].Keys.Contains(subject))
            {
                students[fullName][subject] = new List<double>();
            }
            students[fullName][subject].Add(mark);
        }
        foreach (var student in students)
        {
            //var sub = student.Value.Select(x => x.Key + " - " + x.Value.Average().ToString("0.00")).Aggregate((x, y) => x + ", " + y);, kato v tozi sluchai mahame string.Join v razpechatvaneto
            var sub = student.Value.Select(x => string.Format("{0} - {1}", x.Key,  string.Format("{0:F2}",x.Value.Average())));
            Console.WriteLine("{0}: [{1}]", student.Key, string.Join(", ", sub));
        }
    }
}
