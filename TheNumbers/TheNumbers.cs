using System;
using System.Linq;
using System.Text.RegularExpressions;

class TheNumbers
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine();
        var matches = Regex.Matches(text, @"\d+").Cast<Match>().Select(match =>string.Format("0x{0:X4}", int.Parse(match.Value)));
        Console.WriteLine(string.Join("-", matches));
    }
}