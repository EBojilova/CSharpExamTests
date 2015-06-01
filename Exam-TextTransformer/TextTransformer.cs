using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TextTransformer
{
    class TextTransformer
    {
        static void Main(string[] args)
        {
            string specials = "$%&'";
            int[] weights = {1, 2, 3, 4};
            StringBuilder sb=new StringBuilder();
            string text;
            while ((text=Console.ReadLine()) !="burp")
            {
                sb.Append(text);
            }
            text = sb.ToString();
            text = Regex.Replace(text, @"\s{2,}", " ");
            MatchCollection matches = Regex.Matches(text, @"([$%&'])([^$%&']+)\1");
            sb= new StringBuilder();
            foreach (Match match in matches)
            {
                char symbol = char.Parse(match.Groups[1].Value);
                int weigth = weights[specials.IndexOf(symbol)];
                char[] input = match.Groups[2].Value.ToCharArray();
                for (int i = 0; i < input.Length; i++)
                {
                    if (i%2 == 0)
                    {
                        input[i] = (char)(input[i] + weigth);
                    }
                    else if (i%2==1)
                    {
                        input[i] = (char)(input[i] - weigth);
                    }
                }
                sb.Append(input);
                sb.Append(" ");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
