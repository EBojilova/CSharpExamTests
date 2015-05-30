using System;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    public int age;
    public string name;
    public List<string> oponents;
    public int win;
    public int loss;
}

class VladkosNotebook
{
    static void Main(string[] args)
    {
        var players = new SortedDictionary<string, Player>();
        string inputLine;
        while (!((inputLine = Console.ReadLine()) == "END"))
        {
            string[] input = inputLine.Split('|');
            {
                string color = input[0];
                string query = input[1];
                string value = input[2];
                if (!players.ContainsKey(color))
                {
                    players.Add(color, new Player());
                    players[color].oponents = new List<string>();
                }
                if (query == "name")
                {
                    players[color].name = value;
                }
                else if (query == "age")
                {
                    players[color].age = int.Parse(value);
                }
                else if (query == "win")
                {
                    players[color].win++;
                    players[color].oponents.Add(value);
                }
                else if (query == "loss")
                {
                    players[color].loss++;
                    players[color].oponents.Add(value);
                }
            }
        }
        bool hasData = false;
        foreach (var color in players.Keys)
        {
            if (players[color].name != null && players[color].age != 0)
            {
                Console.WriteLine("Color: {0}", color);
                Console.WriteLine("-age: {0}", players[color].age);
                Console.WriteLine("-name: {0}", players[color].name);
                players[color].oponents.Sort(StringComparer.Ordinal);
                Console.WriteLine("-opponents: {0}", players[color].oponents.Count() > 0 ? string.Join(", ", players[color].oponents) : "(empty)");
                Console.WriteLine("-rank: {0:F2}", (players[color].win + 1.0) / (players[color].loss + 1));
                hasData = true;
            }
        }
        if (!hasData)
        {
            Console.WriteLine("No data recovered.");
        }
    }
}
