using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a moment when you did something completely selfless.",
        "Think of a moment when you overcame a great obstacle.",
        "Think of a moment when you sacraficed something for someone else.",
        "Think of a moment when you felt pure joy."
    };

    private List<string> _questions = new List<string>
    {
        "What value do you find in pondering this moment?",
        "How did it feel once this moment was over?",
        "What was your favorite part of this moment?",
        "What did you learn from this moment?",
        "What did this moment teach you about yourself?",
        "Have you ever been in a situation like this before?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This will help you reflect on impactful times in your life.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        Random random = new Random();
        int promptIndex = random.Next(_prompts.Count);

        Console.WriteLine();
        Console.WriteLine("Consider these prompts:");
        Console.WriteLine();
        Console.WriteLine($" {_prompts[promptIndex]} ");
        Console.WriteLine();
        Console.WriteLine("Once ready, press enter to continue.");
        Console.WriteLine();

        Console.WriteLine("Ponder each of the following questions.");
        Console.Write("You can begin in: ");
        ShowCountDown(5);
        Console.Clear();

        List<string> unaskedQuestions = new List<string>(_questions);

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < futureTime)
        {
            if (unaskedQuestions.Count == 0)
            {
                unaskedQuestions = new List<string>(_questions);
            }

            int questionIndex = random.Next(unaskedQuestions.Count);
            Console.Write($"> {unaskedQuestions[questionIndex]} ");

            unaskedQuestions.RemoveAt(questionIndex);

            ShowSpinner(8);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}