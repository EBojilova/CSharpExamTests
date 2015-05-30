using System;
using System.Linq;

class CouplesFrequency
{
    static void Main(string[] args)
    {
        //raboti si perfekno no v Judge ne iskat formatirane s P i triabva da se sledva tehnia algoritam s iteraciata
        string[] nums = Console.ReadLine().Split(' ');
        var couples1 = nums.Select((x, i) => new { Key = i / 2, Value = x }).GroupBy(x => x.Key, x => x.Value).Where(x => x.Count() > 1).Select(x => string.Join(" ", x)).ToArray();
        var couples2 = nums.Skip(1).Select((x, i) => new { Key = i / 2, Value = x }).GroupBy(x => x.Key, x => x.Value).Where(x => x.Count() > 1).Select(x => string.Join(" ", x)).ToArray();
        var couples = new string[couples1.Count() + couples2.Count()];
        Array.Copy(couples1, couples, couples1.Length);
        Array.Copy(couples2, 0, couples, couples1.Length, couples2.Length);
        //var groups = couples.GroupBy(name => name).OrderByDescending(name=>name.Count()).ThenByDescending(name=>name.Key);
        var groups = couples.GroupBy(name => name);
        foreach (var group in groups)
        {
            double persentage = group.Count() * 100.0 / couples.Length;
            Console.WriteLine("{0} -> {1:F2}% ", group.Key, persentage);
        }
        Console.WriteLine();
    }
}