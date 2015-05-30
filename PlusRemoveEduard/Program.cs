using System;
using System.Collections.Generic;

class PlusRemove
{
    static void Main()
    {
        var inputArray = new List<string>();
        var mask = new List<bool[]>();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            inputArray.Add(input);
            mask.Add(new bool[input.Length]);
        }
        for (var row = 1; row < inputArray.Count - 1; row++)
        {
            for (var col = 1; col < inputArray[row].Length - 1; col++)
            {
                if (col < inputArray[row - 1].Length && col < inputArray[row + 1].Length && IsPlusShape(row, col, inputArray))
                {
                    mask[row][col] = true;
                    mask[row][col - 1] = true;
                    mask[row][col + 1] = true;
                    mask[row - 1][col] = true;
                    mask[row + 1][col] = true;
                }
            }
        }

        for (var row = 0; row < inputArray.Count; row++)
        {
            for (var col = 0; col < inputArray[row].Length; col++)
            {
                if (mask[row][col]) continue;
                Console.Write(inputArray[row][col]);
            }
            Console.WriteLine();
        }
    }

    static bool IsPlusShape(int row, int col, List<string> arr)
    {
        var center = char.ToLower(arr[row][col]);
        var left = char.ToLower(arr[row][col - 1]);
        var right = char.ToLower(arr[row][col + 1]);
        var upper = char.ToLower(arr[row - 1][col]);
        var lower = char.ToLower(arr[row + 1][col]);
        var horizontalCheck = center == left && center == right;
        var verticalCheck = center == upper && center == lower;
        return horizontalCheck && verticalCheck;
    }
}