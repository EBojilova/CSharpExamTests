using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class ActivityTracker
{
    static void Main(string[] args)
    {
        DateTimeFormatInfo format =CultureInfo.InvariantCulture.DateTimeFormat;
        var activity = new SortedDictionary<int, SortedDictionary<string, int>>();
        int n = int.Parse(Console.ReadLine());
        string[] input;
        DateTime dt;
        for (int i = 0; i < n; i++)
        {
            input = Console.ReadLine().Split(' ');
            dt = DateTime.ParseExact(input[0], "dd/MM/yyyy", format);
            int month = dt.Month;
            if (!activity.Keys.Contains(month))
            {
                activity[month] = new SortedDictionary<string, int>();

            }
            if (!activity[month].Keys.Contains(input[1]))
            {
                activity[month][input[1]] = new int();
            }
            activity[month][input[1]]+=int.Parse(input[2]);
        }
        var activityStr = new SortedDictionary<int, SortedSet<string>>();
        foreach (var month in activity.Keys)
        {
            if (!activityStr.Keys.Contains(month))
            {
                activityStr[month] = new SortedSet<string>();
            }
            foreach (var name in activity[month])
            {
                string nameDist = string.Format("{0}({1})", name.Key, name.Value);
                activityStr[month].Add(nameDist);
            }
        }
        foreach (var month in activityStr)
        {
            Console.WriteLine("{0}: {1}", month.Key, string.Join(", ", month.Value));
        }
    }
}
