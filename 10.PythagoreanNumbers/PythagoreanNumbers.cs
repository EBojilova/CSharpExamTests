using System;

class PythagoreanNumbers
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] nums=new int[n];
        bool pitagoreanEquation = false;
        for (int i = 0; i < n; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }
        for (int p1 = 0; p1 < n; p1++)
        {
            for (int p2 = 0; p2 < n; p2++)
            {
                for (int p3 = 0; p3 < n; p3++)
                {
                    if ((nums[p1]*nums[p1] +nums[p2]*nums[p2])==nums[p3]*nums[p3] && nums[p1]<=nums[p2])
                    {
                        Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", nums[p1], nums[p2], nums[p3]);
                        pitagoreanEquation = true;
                    } 
                }
            }
        }
        if (!pitagoreanEquation)
        {
            Console.WriteLine("No");
        }
    }
}

