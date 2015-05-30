using System;

class TerroristsWin
{
    static void Main(string[] args)
    {
        char[] chars = Console.ReadLine().ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            int bombLength = 0;
            int bombPower = 0;
            if (chars[i] == '|')
            {
                do
                {
                    if (chars[i] != '|')
                    {
                        bombPower += chars[i];
                    }
                    bombLength++;
                    ++i;
                } while (chars[i] != '|');
                bombPower = bombPower % 10;
                int end = (i + bombPower < chars.Length) ? (i + bombPower) : (chars.Length - 1);
                i += bombPower;
                int start = (i - bombPower*2 - bombLength) >= 0 ? (i - bombPower*2 - bombLength) : 0;
                for (int j = start; j <= end; j++)
                {
                    chars[j] = '.';
                }
            }
        }
        Console.WriteLine(new string(chars));
    }
}
