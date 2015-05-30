using System;
using System.Linq;
using System.Text.RegularExpressions;

class BiggestTableRow
{
    static void Main(string[] args)
    {
        string text;
        // string pattern = @"<td>([0-9\.-]+)<\/td>"; Kateto
        string pattern = @"<td>(-?\d+(?:.\d+)*)<\/td>";
        MatchCollection matches;
        double max = double.MinValue;
        double sum = 0;
        string maxSum = "";
        while ((text = Console.ReadLine()) != "</table>")
        {
            matches = Regex.Matches(text, pattern);
            if (matches.Count>0)
            {
                sum = 0;
                foreach (Match match in matches)
                {
                    sum += double.Parse(match.Groups[1].ToString());
                }
                if (sum>max)
                {
                    max = sum;
                    var arr = matches.Cast<Match>().Select(m => m.Groups[1].Value).ToArray();
                    maxSum = string.Format("{0} = {1}", sum, String.Join(" + ", arr));
                }
            }
        }
        if (maxSum.Length>0)
        {
            Console.WriteLine(maxSum);
        }
        else
        {
            Console.WriteLine("no data");
        }
    }
}
