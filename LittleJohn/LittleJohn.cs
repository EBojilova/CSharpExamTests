using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class LittleJohn
{
    static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < 4; i++)
        {
            sb.AppendLine(Console.ReadLine());
        }
        string text = sb.ToString();
        string pattern = @"(>>>----->>)|(>>----->)|(>----->)";
        MatchCollection matches = Regex.Matches(text, pattern);
        int large = 0;
        int medium = 0;
        int small = 0;
        foreach (Match match in matches)
        {
            if (!string.IsNullOrEmpty(match.Groups[1].Value))
            {
                large++;
            }
            else if (!string.IsNullOrEmpty(match.Groups[2].Value))
            {
                medium++;
            }
            else
            {
                small++;
            }
        }
        int num = large + medium*10 + small*100;
        string binNum = Convert.ToString(num, 2);
        string reversed = string.Join("", binNum.Reverse());
        uint result = Convert.ToUInt32(string.Format("{0}{1}", binNum, reversed), 2);
        Console.WriteLine(result);
    }
}
