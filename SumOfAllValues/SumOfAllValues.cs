using System;
using System.Text.RegularExpressions;

class SumOfAllValues
{
    static void Main(string[] args)
    {
        //Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
        string keyString = Console.ReadLine();
        string patternKey = @"^([a-zA-Z_]*)(?=\d)(.*)(?<=\d)([a-zA-Z_]*)$";
        Match keys = Regex.Match(keyString, patternKey);
        string startKey = keys.Groups[1].Value;
        string endKey = keys.Groups[3].Value;
        if (startKey.Length == 0 || endKey.Length ==0)
        {
            Console.WriteLine("<p>A key is missing</p>");
            return;
        }
        string pattern = string.Format("{0}(.*?){1}", startKey, endKey);
        string text = Console.ReadLine();
        MatchCollection matches = Regex.Matches(text, pattern);
        double sum = 0;
        foreach (Match match in matches)
        {
            double number;
            double.TryParse(match.Groups[1].Value, out number);
            sum += number;
        }
        if (sum == 0)
        {
            Console.WriteLine("<p>The total value is: <em>nothing</em></p>");
        }
        else
        {
            Console.WriteLine("<p>The total value is: <em>{0}</em></p>", sum);
        }
    }
}