using System;
using System.Collections.Generic;
using System.IO;

public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine();
    }
}

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayJournal()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (var line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                Entry entry = new Entry(parts[1], parts[2], parts[0]);
                _entries.Add(entry);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        string[] prompts = new string[]
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        while (true)
        {
            Console.WriteLine("Please choose one of the following options:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Random random = new Random();
                string prompt = prompts[random.Next(prompts.Length)];
                Console.WriteLine(prompt);
                string response = Console.ReadLine();
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                Entry newEntry = new Entry(prompt, response, date);
                myJournal.AddEntry(newEntry);
            }
            else if (choice == "2")
            {
                myJournal.DisplayJournal();
            }
            else if (choice == "3")
            {
                Console.Write("Enter the filename to save the journal: ");
                string filename = Console.ReadLine();
                myJournal.SaveToFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("Enter the filename to load the journal: ");
                string filename = Console.ReadLine();
                myJournal.LoadFromFile(filename);
            }
            else if (choice == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid option, please try again.");
            }
        }
    }
}
