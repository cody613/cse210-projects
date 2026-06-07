using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "What are your greatest strengths?",
        "Who are the people that you appreciate most?",
        "When have you felt the Holy Ghost this month?",
        "Who have you helped this month?"
    };

    public ListingActivity() : base("Listing Activity", "To help you focus on the good things, you will list as many things as you can in a certain area.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random random = new Random();
        int promptIndex = random.Next(_prompts.Count);

        Console.WriteLine();
        Console.WriteLine("List as many responses as possible to the following prompt:");
        Console.WriteLine($" {_prompts[promptIndex]} ");
        Console.Write("You can begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);

        int count = 0;

        while (DateTime.Now < futureTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                count++;
            }
        }

        Console.WriteLine($"You listed {count} responses!");
        DisplayEndingMessage();
    }
}