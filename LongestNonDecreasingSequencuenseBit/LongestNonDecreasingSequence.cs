using System;
using System.Collections.Generic;
using System.Linq;

class LongestNonDecreasingSubsequence
{
    static void Main() //Kolimnared
    {
        // Zero tests in the "Homework:C#AdvancedTopics.doc-Problem 4" file are not correct (some of them).
        int[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
        //int[] numbers= {1, 2, 3, 4, 5 };
        List<int> allNonDecreasing = new List<int>();
        List<int> longest = new List<int>();
        string output = Convert.ToString(numbers[0]);
        int max = 1;
        for (int i = 0; i < numbers.Length - 1; i++) //for-loop for all elements of the input except the last element
        {
            allNonDecreasing.Add(numbers[i]); // add to allNonDecreasing all elements bigger than the element [i], placed from the right side of element [i]
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[i] <= numbers[j])
                {
                    allNonDecreasing.Add(numbers[j]);
                }
            }
            //Console.WriteLine(string.Join(" ",allNonDecreasing));
            int combinations = (int)Math.Pow(2, allNonDecreasing.Count) - 1;
            while (combinations > 0) //checking all variations where bit == 1
            {
                longest.Add(numbers[i]);
                for (int j = 1; j < allNonDecreasing.Count; j++)
                {
                    //Console.WriteLine(Convert.ToString((combinations), 2).PadLeft(20, '0'));
                    //Console.WriteLine(allNonDecreasing.Count - j);
                    if (((combinations >> allNonDecreasing.Count - j) & 1) == 1 && allNonDecreasing[j] >= longest.Last())
                    {
                        longest.Add(allNonDecreasing[j]);
                    }
                }
                //Console.WriteLine(string.Join(" ", longest));
                if (longest.Count > max)
                {
                    output = string.Join(" ", longest);
                    max = longest.Count;
                }
                combinations--;
                longest.Clear();
            }
            allNonDecreasing.Clear();
        }
        Console.WriteLine(output);
    }
}