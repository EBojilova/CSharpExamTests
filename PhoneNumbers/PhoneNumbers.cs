using System;
using System.Text;
using System.Text.RegularExpressions;

class PhoneNumbers
{
    static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        string pattern = @"([A-Z][a-zA-Z]*)[^a-zA-Z+0-9]*(\+?\d[0-9-()\/. ]*\d)";
        string phoneNum;
        MatchCollection matches;
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            sb.AppendLine(input);
        }
        matches = Regex.Matches(sb.ToString(), pattern);
        if (matches.Count == 0)
        {
            Console.WriteLine("<p>No matches!</p>");
            return;
        }
        Console.Write("<ol>");
        foreach (Match match in matches)
        {
            phoneNum = Regex.Replace(match.Groups[2].Value, @"[^+0-9]+", "");
            Console.Write(@"<li><b>{0}:</b> {1}</li>",match.Groups[1], phoneNum);// ne e nujno da pishem .Value sled match.Groups[1]
        }
        Console.Write("</ol>");
    }
}