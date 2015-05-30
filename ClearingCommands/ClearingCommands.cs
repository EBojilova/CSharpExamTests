using System;
using System.Collections.Generic;
using System.Security;

internal class LabyrinthDash
{
    public static string commands = "><^v";
    public static List<char[]> matrix = new List<char[]>();

    private static void Main(string[] args)
    {
        string inputLine;
        while (!((inputLine = Console.ReadLine()) == "END"))
        {
            matrix.Add(inputLine.ToCharArray());
        }
        for (int row = 0; row < matrix.Count; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                if (matrix[row][col] == 'v')
                {
                    ClearingMatrix(row, col, 1, 0);
                }
                else if (matrix[row][col] == '^')
                {
                    ClearingMatrix(row, col, -1, 0);
                }
                else if (matrix[row][col] == '<')
                {
                    ClearingMatrix(row, col, 0, -1);
                }
                else if (matrix[row][col] == '>')
                {
                    ClearingMatrix(row, col, 0, 1);
                }
            }
        }
        PrintMatrix(matrix);
    }

    private static void ClearingMatrix(int row, int col, int rowChange, int colChange)
    {
        row = row + rowChange;
        col = col + colChange;
        while ((row >= 0 && row < matrix.Count) && (col >= 0 && col < matrix[row].Length) &&
               (commands.IndexOf(matrix[row][col]) < 0))
        {
            matrix[row][col] = ' ';
            row = row + rowChange;
            col = col + colChange;
        }
    }

    private static void PrintMatrix(List<char[]> matrix)
    {
        for (int row = 0; row < matrix.Count; row++)
        {
            Console.Write("<p>");
            for (int col = 0; col < matrix[row].Length; col++)
            {
                Console.Write(SecurityElement.Escape(matrix[row][col].ToString()));
            }
            Console.WriteLine("</p>");
        }
    }
}



