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
        StringBuilder sentenceBlack=new StringBuilder();
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                if ((row % 2 == 0 && col % 2 == 0) ||(row % 2 != 0 && col % 2 != 0))
                {
                    sentenceWhite.Append(matrix[row, col]);
                }
                else if ((row % 2 == 0 && col % 2 != 0) ||  (row % 2 != 0 && col % 2 == 0))
                {
                    sentenceBlack.Append(matrix[row, col]);
                }
            }
        }
        return sentenceWhite+sentenceBlack.ToString();
    }

    private static void FillMatrix(string text, int size, char[,] matrix)
    {
        int currentIndex = 0;
        int currentRow = 0;
        int currentCol = 0;
        while (currentIndex < text.Length)
        {
            while (currentCol < size && matrix[currentRow, currentCol] == '\0')
            {
                matrix[currentRow, currentCol] = text[currentIndex];
                currentCol++;
                currentIndex++;
            }
            currentCol--;
            currentRow++;
            while (currentRow < size && matrix[currentRow, currentCol] == '\0')
            {
                matrix[currentRow, currentCol] = text[currentIndex];
                currentRow++;
                currentIndex++;
            }
            currentRow--;
            currentCol--;
            while (currentCol >= 0 && matrix[currentRow, currentCol] == '\0')
            {
                matrix[currentRow, currentCol] = text[currentIndex];
                currentCol--;
                currentIndex++;
            }
            currentCol++;
            currentRow--;
            while (currentRow >= 0 && matrix[currentRow, currentCol] == '\0')
            {
                matrix[currentRow, currentCol] = text[currentIndex];
                currentRow--;
                currentIndex++;
            }
            currentRow++;
            currentCol++;
        }
    }
}