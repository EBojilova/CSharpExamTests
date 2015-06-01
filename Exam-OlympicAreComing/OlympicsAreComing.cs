using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class SchoolSystem
{
    private static void Main()
    {
        var contries = new Dictionary<string, Dictionary<string, int>>();
        string inputLine;
        while ((inputLine = Console.ReadLine()) != "report")
        {
            var info = inputLine.Split('|');
            string name = Regex.Replace(info[0], @"\s{2,}", " ").Trim();
            string contry = Regex.Replace(info[1], @"\s{2,}", " ").Trim();
            if (!contries.Keys.Contains(contry))
            {
                contries[contry] = new Dictionary<string, int>();

            }
            if (!contries[contry].Keys.Contains(name))
            {
                contries[contry][name] = new int();
            }
            contries[contry][name]++;
        }
        var sorted =
            contries.OrderByDescending(x => x.Value.Values.Sum());
        foreach (var contry in sorted)
        {
            Console.WriteLine("{0} ({1} participants): {2} wins", contry.Key, contry.Value.Keys.Count,
                contry.Value.Values.Sum());
        }
    }
}


