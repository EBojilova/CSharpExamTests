using System;
using System.Collections.Generic;
using System.Linq;

class OfficeStuff
{
    static void Main(string[] args)
    {
        var orders = new SortedDictionary<string, Dictionary<string, int>>();
        int n=int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] info = Console.ReadLine().Split(new char[] { '|', '-' },
            StringSplitOptions.RemoveEmptyEntries);
            {
                string company = info[0].Trim();
                int quantity =int.Parse( info[1].Trim());
                string item = info[2].Trim();
                if (!orders.ContainsKey(company))
                    if (!orders.Keys.Contains(company))
                    {
                        orders[company] = new Dictionary<string, int>();

                    }
                if (!orders[company].Keys.Contains(item))
                {
                    orders[company][item] = new int();
                }
                orders[company][item]+=quantity;
            }
        }
        foreach (var company in orders)
        {
            var printInfo = company.Value.Select(x => String.Format("{0}-{1}", x.Key, x.Value));
            Console.WriteLine("{0}: {1}", company.Key, string.Join(", ", printInfo));
        }
    }
}
