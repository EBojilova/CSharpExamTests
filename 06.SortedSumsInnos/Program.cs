using System;
using System.Linq;

class SubsetSums
{
    static void Main(string[] args)
    {
        bool solutionFound = false;
        int targetSum = int.Parse(Console.ReadLine());
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).Distinct().ToArray();
        var subsets = from m in Enumerable.Range(0, 1 << numbers.Length)
                      select
                            from i in Enumerable.Range(0, numbers.Length)
                            where (m & (1 << i)) != 0
                            select numbers[i];
        //LINQ Query syntaxis "from x in y" works like a foreach cycle, "where" is the same as LINQ .Where extension method,
        // select specifies the shape of the returned element,if multiple values are given they are placed in a group, 
        //the result of this is actually an IEnumerable<IGrouping<int>>, think of it as an unindexed List of Lists  
        //(that doesn't have an already defined Count,but Count() method can still be called on it)
        foreach (var item in subsets)
        {
            if (item.Sum() == targetSum)
            {
                Console.WriteLine("{0} = {1}", String.Join(" + ", item), targetSum);
                solutionFound = true;
            }

        }
        if (solutionFound == false)
        {
            Console.WriteLine("No matching subsets.");
        }

    }
}
