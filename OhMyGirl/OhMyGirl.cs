using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class OMyGirl
{
    public static void Main()
    {
        string escapes = "()[]*+?\\{}\".$^<>|";
        string key = Console.ReadLine();
        StringBuilder sb = new StringBuilder();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            sb.Append(input);
        }
        string text = sb.ToString();
        sb = new StringBuilder();
        if (escapes.Contains(key[0]))
        {
            sb.AppendFormat("\\{0}", key[0]);
        }
        else
        {
            sb.Append(key[0]);
        }
        for (int i = 1; i < key.Length - 1; i++)
        {
            if (char.IsDigit(key[i]))
            {
                sb.Append(@"[0-9]*");
            }
            else if (char.IsLower(key[i]))
            {
                sb.Append(@"[a-z]*");
            }
            else if (char.IsUpper(key[i]))
            {
                sb.Append(@"[A-Z]*");
            }
            else if (escapes.Contains(key[i]))
            {
                sb.AppendFormat("\\{0}", key[i]);
            }
            else
            {
                sb.Append(key[i]);
            }
        }
        if (escapes.Contains(key[key.Length - 1]))
        {
            sb.AppendFormat("\\{0}", key[key.Length - 1]);
        }
        else
        {
            sb.Append(key[key.Length - 1]);
        }
        string pattern = string.Format("{0}(.{{2,6}}?){0}", sb);
        var matches = Regex.Matches(text,pattern).Cast<Match>().Select(match => match.Groups[1].Value);
        Console.WriteLine(string.Join(string.Empty, matches));
    }
}