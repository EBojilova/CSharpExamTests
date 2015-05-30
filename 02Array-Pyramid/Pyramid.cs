    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pyramid
    {
        public static void Main()
        {
            int countOfRows = int.Parse(Console.ReadLine());
            List<int> results = new List<int>();
            int min = int.Parse(Console.ReadLine().Trim());
            results.Add(min);
            for (int row = 1; row < countOfRows; row++)
            {
                var numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
                try
                {
                    min = numbers.Where(num => num > min).Min();
                    results.Add(min);
                }
                catch (InvalidOperationException)
                {
                    min++;
                }
            }
            Console.WriteLine(string.Join(", ", results));
        }
    }
