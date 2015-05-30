using System;
using System.Collections.Generic;
using System.Linq;

class CouplesFrequency
{
    static void Main(string[] args)
    {
        //dava 100 tochni pro poveche vreme i po-malko pamet v sravnenie s LINQ, no kato cialo sa indentichni
        string[] nums = Console.ReadLine().Split(' ');
        var couples = new Dictionary<string, int>();
        for (int i = 1; i < nums.Length; i++)
        {
            string key = string.Format("{0} {1}", nums[i - 1], nums[i]);
            if (!couples.Keys.Contains(key))
            {
                couples[key] = new int();
            }
            couples[key]++;
        }
        foreach (var couple in couples)
        {
            double persentage = couple.Value * 100.0 / couples.Values.Sum();
            Console.WriteLine("{0} -> {1:F2}% ", couple.Key, persentage);
        }
        Console.WriteLine();
    }
}
