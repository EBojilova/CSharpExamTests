using System;
using System.Collections.Generic;
using System.Linq;

class NightLife
{
    static void Main(string[] args)
    {
        var nightClubs = new Dictionary<string, SortedDictionary<string, SortedSet<string>>>();
        string input;
        string[] info;
        while (!((input = Console.ReadLine()) == "END"))
        {
            info = input.Split(';');
            if (!nightClubs.Keys.Contains(info[0]))
            {
                nightClubs[info[0]] = new SortedDictionary<string, SortedSet<string>>();
               
            }
            if (!nightClubs[info[0]].Keys.Contains(info[1]))
            {
                nightClubs[info[0]][info[1]] = new SortedSet<string>();
            }
            nightClubs[info[0]][info[1]].Add(info[2]);
        }
        foreach (var town in nightClubs.Keys)
        {
            Console.WriteLine(town);
            foreach (var vanue in nightClubs[town].Keys)
            {
                Console.WriteLine("->{0}: {1}", vanue, string.Join(", ", nightClubs[town][vanue]));
            }
        }
    }
}
