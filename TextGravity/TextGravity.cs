using System;
using System.Security;

class TextBombardment
{
    static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        int height = text.Length / width;
        height += text.Length % width != 0 ? 1 : 0;
        char[,] matrix = new char[height, width];
        int n = 0;
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                if (n < text.Length)
                {
                    matrix[row, col] = text[n];
                    n++;
                }
                else
                {
                    matrix[row, col] = ' ';
                }
            }
        }
        for (int col = 0; col < width; col++)
        {
            for (int row = height-1; row > 0; row--)
            {
                if (matrix[row,col]==' ')
                {
                    for (int j = row-1; j >= 0; j--)
                    {
                        if (matrix[j, col] != ' ')
                        {
                            matrix[row, col] = matrix[j, col];
                            matrix[j, col] = ' ';
                            break;
                        }
                    }
                }
            }
        }
        Console.Write("<table>");
        for (int row = 0; row < height; row++)
        {
            Console.Write("<tr>");
            for (int col = 0; col < width; col++)
            {
                Console.Write("<td>{0}</td>", SecurityElement.Escape(matrix[row, col].ToString()));
            }
            Console.Write("</tr>");
        }
        Console.WriteLine("</table>");
    }
}
