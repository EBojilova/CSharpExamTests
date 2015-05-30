using System;

class Disc
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int r = int.Parse(Console.ReadLine());
        int rowC = n / 2 + 1;
        int colC = n / 2 + 1;
        int rCheck = r * r;
        for (int row = 1; row <= n; row++)
        {
            for (int col = 1; col <= n; col++)
            {
                bool inCircle = ((row - rowC) * (row - rowC) + (col - colC) * (col - colC) <= rCheck);
                if (inCircle)
                {
                    Console.Write('*');
                }
                else
                {
                    Console.Write('.');
                }
            }
            Console.WriteLine();
        }
    }
}
