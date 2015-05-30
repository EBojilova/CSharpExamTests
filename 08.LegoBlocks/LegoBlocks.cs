using System;
using System.Linq;

class LegoBlocks
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        bool fit = true;
        int[][] left=new int[n][];
        int[][] right = new int[n][];
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            left[i] = Console.ReadLine().Split(new char[] { ',', ';', ' ' },
            StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            sum += left[i].Length;
        }
        int rowLenght;
        for (int i = 0; i < n; i++)
        {
            right[i] = Console.ReadLine().Split(new char[] { ',', ';', ' ' },
            StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            sum += right[i].Length;
            rowLenght = left[0].Length + right[0].Length;
            if (!(left[i].Length + right[i].Length == rowLenght))
            {
                fit = false;
            }
        }
        if (fit)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("[{0}, {1}]", string.Join(", ",left[i]),string.Join(", ",right[i].Reverse()));
            }
        }
        else
        {
            //var leftSum = Enumerable.Range(0, left[0].Length).Select(i => left[i].Length).Sum();
            //var rightSum = Enumerable.Range(0, right[0].Length).Select(i => right[i].Length).Sum();
            Console.WriteLine("The total number of cells is: {0}", sum);
        }
    }
}
