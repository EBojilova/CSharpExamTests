using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class MatrixShuffle
{
    public static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        char[,] matrix = new char[size, size];
        FillMatrix(text, size, matrix);
        string sentence = GetSentence(size, matrix);
        Console.WriteLine(
            "<div style='background-color:{0}'>{1}</div>",
            IsPalidrome(sentence) ? "#4FE000" : "#E0000F",
            sentence);
    }

    private static bool IsPalidrome(string sentence)
    {
        string original = Regex.Replace(sentence, @"[^a-zA-Z]+", string.Empty).ToLower();
        string reversed = new string(original.Reverse().ToArray());
        return original == reversed;
    }

    private static string GetSentence(int size, char[,] matrix)
    {
        StringBuilder sentenceWhite = new StringBuilder();
        StringBuilder sentenceBlack = new StringBuilder();
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                if ((row % 2 == 0 && col % 2 == 0) || (row % 2 != 0 && col % 2 != 0))
                {
                    sentenceWhite.Append(matrix[row, col]);
                }
                else if ((row % 2 == 0 && col % 2 != 0) || (row % 2 != 0 && col % 2 == 0))
                {
                    sentenceBlack.Append(matrix[row, col]);
                }
            }
        }
        return sentenceWhite + sentenceBlack.ToString();
    }

    private static void FillMatrix(string text, int size, char[,] matrix)
    {
        int leftColumn = 0;
        int rightColumn = size - 1;
        int upperRow = 0;
        int bottomRow = size - 1;
        int currentIndex = 0;
        while (currentIndex < text.Length)
        {
            for (int i = leftColumn; i <= rightColumn; i++) // filling the upper row
            {
                matrix[upperRow, i] = text[currentIndex];
                currentIndex++;
            }
            upperRow++; // we go one row down
            for (int i = upperRow; i <= bottomRow; i++) // filling the right column
            {
                matrix[i, rightColumn] = text[currentIndex];
                currentIndex++;
            }
            rightColumn--; // we go to the next column
            for (int i = rightColumn; i >= leftColumn; i--) // filling bottom row
            {
                matrix[bottomRow, i] = text[currentIndex];
                currentIndex++;
            }
            bottomRow--; // one row up 
            for (int i = bottomRow; i >= upperRow; i--) // filling the leftmost column
            {
                matrix[i, leftColumn] = text[currentIndex];
                currentIndex++;
            }
            leftColumn++;// we go one column to the right
        }
    }
}