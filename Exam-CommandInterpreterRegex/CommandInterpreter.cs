using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string[] strings =Regex.Split(Console.ReadLine(), @"\s+");
        string inputLine;
        while ((inputLine = Console.ReadLine()) != "end")
        {
            string[] commands = inputLine.Split(' ');
            if (commands[0] == "reverse" || commands[0] == "sort")
            {
                int start = int.Parse(commands[2]);
                int count = int.Parse(commands[4]);
                int end = start + count - 1;
                if (start < 0 || start >= strings.Length || count < 0 || end >= strings.Length)
                {
                    Console.WriteLine("Invalid input parameters.");
                }
                else
                {
                    string[] part = new string[count];
                    for (int i = start; i < end; i++)
                    {
                        part[i - start] = strings[i];
                    }
                    if (commands[0] == "reverse")
                    {
                        Array.Reverse(part);
                    }
                    else if (commands[0] == "sort")
                    {
                        Array.Sort(part);
                    }
                    for (int i = start; i <= end; i++)
                    {
                        strings[i] = part[i - start];
                    } 
                }
                
            }
            else if (commands[0] == "rollLeft")
            {
                int rolls =(int)(long.Parse(commands[1]))%strings.Length;
                if (rolls>=0)
                {
                    for (int j = 1; j <= rolls; j++)
                    {
                        string first = strings[0];
                        Array.Copy(strings, 1, strings, 0, strings.Length - 1);
                        strings[strings.Length - 1] = first;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input parameters.");
                }
            }
            else if (commands[0] == "rollRight")
            {
                int rolls = (int)(long.Parse(commands[1]))%strings.Length;
                if (rolls>=0)
                {
                    for (int j = 1; j <= rolls; j++)
                    {
                        string last = strings[strings.Length - 1];
                        Array.Copy(strings, 0, strings, 1, strings.Length - 1);
                        strings[0] = last;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input parameters.");
                }
            }
        }
        Console.WriteLine("[{0}]", string.Join(", ", strings));
    }
}
