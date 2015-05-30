using System;
using System.Collections.Generic;
using System.Linq;

class SortedSubsetSums //Recursion from KatyaMarincheva
{
    static int[] numbers;
    static int n;
    static bool solution = false;

    static void Main()
    {
        n = int.Parse(Console.ReadLine());
        numbers = Console.ReadLine().Split(' ').Select(int.Parse).Distinct().ToArray();
        //numbers = new int[] { 1, 2, 3, 4 };
        Console.WriteLine("\nOutput:");
        List<int> subset = new List<int>();
        MakeSubset(0, subset);
        if (!solution)
            Console.WriteLine("No matching subsets.");
    }

    static void MakeSubset(int index, List<int> subset)
    {
        if (subset.Sum() == n && subset.Count > 0)
        {
            Console.WriteLine(" {0} = {1}", string.Join(" + ", subset), n);
            solution = true; 
        }
        //Console.WriteLine(string.Join(" ", subset));
        for (int i = index; i < numbers.Length; i++)
        {
            subset.Add(numbers[i]);
            MakeSubset(i + 1, subset); // call MakeSubset recursively
            subset.RemoveAt(subset.Count - 1); // remove last element
        }
    }
}
