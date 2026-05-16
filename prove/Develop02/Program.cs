using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.IO;

public class Entry
{
    public string date;
    public string question;
    public string entryText;
    public string mood;

    public void Display()
    {
        Console.WriteLine($"Date: {date} - Prompt: {question}");
        Console.WriteLine($"Mood: {mood}/10");
        Console.WriteLine($"{entryText}\n");
    }
}

public class PromptGenerator
{
    public List<string> prompts = new List<string>
    {
        "If I could have a redo for anything today, what would it be?",
        "What's the reason for the last time you cried?",
        "Where do you hope to be in five years?",
        "Did you have a childhood pet? What was their name? What did you love the most about them?",
        "If you could meet anyone from history who would it be? Why?",
        "What is something that makes you happy whenever you think about it?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}

public class Journal
{
    public List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        for (int i = 0; i < entries.Count; i++)
        {
            entries[i].Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            for (int i = 0; i < entries.Count; i++)
            {
                Entry entry = entries[i];
                outputFile.WriteLine($"{entry.date}|{entry.question}|{entry.entryText}|{entry.mood}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        entries.Clear();
        string[] lines = File.ReadAllLines(file);

        for (int i = 0; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");

            if (parts.Length >= 4)
            {
                Entry newEntry = new Entry();
                newEntry.date = parts[0];
                newEntry.question = parts[1];
                newEntry.entryText = parts[2];
                newEntry.mood = parts[3];
                entries.Add(newEntry);
            }
        }
    }
}

class Program
{
    static void Main(String[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do today? ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                Console.Write("What's your general mood today on a scale of 1-10? ");
                string userMood = Console.ReadLine();

                Entry newEntry = new Entry();
                newEntry.date = DateTime.Now.ToShortDateString();
                newEntry.question = prompt;
                newEntry.entryText = response;
                newEntry.mood = userMood;

                theJournal.AddEntry(newEntry);
            }
            else if (choice == "2")
            {
                theJournal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What's the filename? ");
                string fileName = Console.ReadLine();

                if (File.Exists(fileName))
                {
                    theJournal.LoadFromFile(fileName);
                }
                else
                {
                    Console.WriteLine("File not found. ");
                }
            }
            else if (choice == "4")
            {
                Console.Write("What's the filename? ");
                theJournal.SaveToFile(Console.ReadLine());
            }
        }
    }
}
