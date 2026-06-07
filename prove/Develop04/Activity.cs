using System;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("In seconds, how long would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
    }

    public void DisplayEndingMeassage()
    {
        Console.WriteLine();
        Console.WriteLine("Good job!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You've completed another {_duration} seconds of the {_name}.");
        ShowSpinner(5);
    }

    public void ShowSpinner(int numSeconds)
    {
        List<string> animationStrings = new List<string> { "|", "/", "-", "\\"};

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(numSeconds);

        int i = 0;
        while (DateTime.Now < futureTime)
        {
            string s = animationStrings[i % animationStrings.Count];
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;
        }
    }

    public void ShowCountDown(int numSeconds)
    {
        for (int i = numSeconds; i > i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);

            if (i >= 10)
            {
                Console.Write("\b\b  \b\b");
            }
            else
            {
                Console.Write("\b \b");
            }
        }
    }
}