using System;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

internal class UppercaseWords
{
    private static void Main(string[] args)
    {
        string input;
        var sb = new StringBuilder();
        var sbResult = new StringBuilder();
        MatchCollection matches;
        while ((input = Console.ReadLine()) != "END")
        {
            matches = Regex.Matches(input, @"(?<![a-zA-Z])[A-Z]+(?![a-zA-Z])");
            foreach (Match match in matches)
            {
                string word = match.ToString();
                char[] reversed = word.ToCharArray();
                Array.Reverse(reversed);
                string newWord = new string(reversed);
                if (word == newWord)
                {
                    sb = new StringBuilder();
                    for (int j = 0; j < word.Length; j++)
                    {
                        sb.Append(word[j]);
                        sb.Append(word[j]);
                    }
                    newWord = sb.ToString();
                }
                input = Regex.Replace(input, string.Format(@"(?<![a-zA-Z]){0}(?![a-zA-Z])", word), newWord);
            }
            sbResult.AppendLine(input);
        }
        Console.WriteLine(SecurityElement.Escape(sbResult.ToString()));
    }
}
