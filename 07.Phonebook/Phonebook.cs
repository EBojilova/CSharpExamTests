using System;
using System.Collections.Generic;
using System.Linq;

class Phonebook
{
    static void Main(string[] args)
    {
        Dictionary<string, List<string>> phonebook = new Dictionary<string, List<string>>();
        string input;
        string[] contact;
        while (!((input = Console.ReadLine()) == "search"))
        {
            contact = input.Split('-');
            if (!phonebook.Keys.Contains(contact[0]))
            {
                phonebook[contact[0]] = new List<string>();
            }
            phonebook[contact[0]].Add(contact[1]);
        }
        if (input == "search")
        {
            while (!((input = Console.ReadLine()) == "END"))
            {
                if (phonebook.Keys.Contains(input))
                {
                    foreach (var phone in phonebook[input])
                    {
                        Console.WriteLine("{0} -> {1}", input, phone);
                    }
                }
                else
                {
                    Console.WriteLine("Contact {0} does not exist.", input);
                }
            }
        }
    }
}
