using System;
using System.Collections.Generic;
using System.Linq;

class StuckNumbers
{
    static void Main(string[] args)
    {
        // with foreach the time is 30% increased compared with the iteration
        int n = int.Parse(Console.ReadLine());
        string[] numbers = Console.ReadLine().Split(new char[] { ',', ';', ' ' },
            StringSplitOptions.RemoveEmptyEntries);
        bool stuckNums = false;
        foreach (string p1 in numbers)
        {
            foreach (string p2 in numbers)
            {
                foreach (string p3 in numbers)
                {
                    foreach (string p4 in numbers)
                    {
                        if (p1 != p2 && p1 != p3 && p1 != p4 && p2 != p3 && p2 != p4 && p3 != p4)
                        {
                            string left = p1 + p2;
                            string right = p3 + p4;
                            if (left == right)
                            {
                                Console.WriteLine("{0}|{1}=={2}|{3}", p1, p2, p3, p4);
                                stuckNums = true;
                            }
                        }
                    }
                }
            }
        }
        if (!stuckNums)
        {
            Console.WriteLine("No");
        }
    }
}
