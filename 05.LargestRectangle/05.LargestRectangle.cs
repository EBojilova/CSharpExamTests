using System;
using System.Collections.Generic;
using System.Linq;

class LargestRectangle
{
    static void Main(string[] args)
    {

        string input;
        List<string[]> matrix = new List<string[]>();
        while (!((input = Console.ReadLine()) == "END"))
        {
            matrix.Add(input.Split(new char[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }
        int area = 0, finalArea = 0;
        int finalRow = 0, finalCol = 0;
        int height = 0, width = 0;
        int rows = matrix.Count;
        string pattern = null;
        int cols = matrix.OrderBy(x => x.Length).First().Length;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                for (int h = 1; h <= rows - row; h++)
                {
                    for (int w = 1; w <= cols - col; w++)
                    {
                        if (IsRect(matrix, row, col, h, w))
                        {
                            if (h * w > area)
                            {
                                area = h * w;
                                finalRow = row;
                                height = h;
                                finalCol = col;
                                width = w;
                                pattern = matrix[row][col];
                            }
                        }
                    }
                }
            }
        }
        for (int row = finalRow; row < finalRow + height; row++)
        {
            matrix[row][finalCol] = string.Format("[{0}]", pattern);
            matrix[row][finalCol + width - 1] = string.Format("[{0}]", pattern);
        }
        for (int col = finalCol + 1; col < finalCol + width; col++)
        {
            matrix[finalRow][col] = string.Format("[{0}]", pattern);
            matrix[finalRow + height - 1][col] = string.Format("[{0}]", pattern);
        }
        string encoded;
        foreach (var stringArray in matrix)
        {
            foreach (var piece in stringArray)
            {
                //string xml = "<node>it's my \"node\" & i like it<node>";
                //string encodedXml = System.Security.SecurityElement.Escape(xml);
                //// RESULT: &lt;node&gt;it&apos;s my &quot;node&quot; &amp; i like it&lt;node&gt;
                encoded = System.Security.SecurityElement.Escape(piece);
                Console.Write("{0,5}", encoded);
            }
            Console.WriteLine();
        }
    }

    private static bool IsRect(List<string[]> matrix, int startRow, int startCol, int height, int width)
    {
        string pattern = matrix[startRow][startCol];
        for (int row = startRow+1 ; row < startRow + height && row<matrix.Count; row++)
        {
            if (matrix[row][startCol] != pattern || matrix[row][startCol + width - 1] != pattern)
            {
                return false;
            }
        }
        for (int col = startCol+1; col < startCol + width &&col<matrix[0].Length; col++)
        {
            if (matrix[startRow][col] != pattern || matrix[startRow + height - 1][col] != pattern)
            {
                return false;
            }
        }
        return true;
    }
}
