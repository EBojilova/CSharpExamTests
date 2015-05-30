using System;

class StuckNumbers
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string[] numbers = Console.ReadLine().Split(new char[] { ',', ';', ' ' },
            StringSplitOptions.RemoveEmptyEntries);
        bool stuckNums = false;
        for (int p1 = 0; p1 < n; p1++)
        {
            for (int p2 = 0; p2 < n; p2++)
            {
                for (int p3 = 0; p3 < n; p3++)
                {
                    for (int p4 = 0; p4 < n; p4++)
                    {
                        if (p1 != p2 && p1 != p3 && p1 != p4 && p2 != p3 && p2 != p4 && p3 != p4)
                        {
                            string left = numbers[p1] + numbers[p2];
                            string right = numbers[p3] + numbers[p4];
                            if (left == right)
                            {
                                Console.WriteLine("{0}|{1}=={2}|{3}", numbers[p1], numbers[p2], numbers[p3], numbers[p4]);
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
