using System;
using System.Collections.Generic;
using System.Linq;

// Zero tests in the "Homework:C#AdvancedTopics.doc-Problem 4" file are not correct (some of them).

class LongestNonDecreasingSubsequence
{
    static int numLoops;
    static int[] loops;
    static int[] nums;
    static int[] longestPositiveSequence = new int[0];

    static void Main()
    {
        nums = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
        numLoops = nums.Length;
        while (numLoops > 0)
        {
            loops = new int[numLoops];
            FindSubsets(0, 0);
            numLoops--;
        }
        Console.Write(string.Join(" ", longestPositiveSequence));
        Console.WriteLine();
    }

    static void FindSubsets(int loopI, int startNum)
    {
        if (loopI == numLoops)
        {
            Console.WriteLine(string.Join(" ", loops));
            //CheckSequence();
            return;
        }
        for (int i = startNum; i < nums.Length; i++)
        {
            loops[loopI] = nums[i];
            FindSubsets(loopI + 1, i + 1);
        }
    }

    private static void CheckSequence()
    {
        bool positiveSequence = true;
        for (int index = 0; index < loops.Length - 1; index++)
        {
            if (loops[index] > loops[index + 1])
            {
                positiveSequence = false;
                break;
            }
        }
        if (positiveSequence)
        {
            if (loops.Length > longestPositiveSequence.Length)
            {
                longestPositiveSequence = new int[loops.Length];
                loops.CopyTo(longestPositiveSequence, 0);
            }
        }
    }
}