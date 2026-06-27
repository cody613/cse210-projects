using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool quit = false;
        while (!quit)
        {
            DisplayScore();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine(" 1. Create New Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Event");
            Console.WriteLine(" 6. Quit");
            Console.Write("Choose a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid. Please Try Again.");
                    break;
            }
            
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"\nYou have {_score} points.");
        Console.WriteLine($"Current Rank: {DetermineRank()}");
    }

    public string DetermineRank()
    {
        if (_score >= 10000)
        {
            return "Grand Maestro";
        }
        else if (_score >= 5000)
        {
            return "Lead Soloist";
        }
        else if (_score >= 2500)
        {
            return "First Chair Pianist";
        }
        else if (_score >= 1000)
        {
            return "Sheet Music Reader";
        }
        else
        {
            return "Scale Practicer";
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");
        Console.Write("Which type of goal do you want to create? ");
        string type = Console.ReadLine();

        Console.Write("What name would you like for your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description for it? ");
        string description = Console.ReadLine();

        Console.Write("How many points are associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if(type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goals need to be completed for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What's the bonus for completing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    public void RecordEvent()
    {
        ListGoalDetails();
        Console.Write("Which goal did you complete? ");

        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _goals.Count)
        {
            string oldRank = DetermineRank();

            int earnedPoints = _goals[index - 1].RecordEvent();
            _score += earnedPoints;

            string newRank = DetermineRank();

            Console.WriteLine($"Congrats! You've earned {earnedPoints} points!");

            if (oldRank != newRank)
            {
                Console.WriteLine($"LEVEL UP! You're now a {newRank}!\n");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal choice.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Provide a filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("What's the filename of the goal file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);

            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string type = parts[0];
                string[] details = parts[1].Split(',');

                string name = details [0];
                string desc = details[1];
                int points = int.Parse(details[2]);

                if (type == "SimpleGoal")
                {
                    bool isComplete = bool.Parse(details[3]);
                    _goals.Add(new SimpleGoal(name,desc, points, isComplete));
                }
                else if (type == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(name, desc, points));
                }
                else if (type == "ChecklistGoal")
                {
                    int bonus = int.Parse(details[3]);
                    int target = int.Parse(details[4]);
                    int amountCompleted = int.Parse(details[5]);
                    _goals.Add(new ChecklistGoal(name, desc, points, target, bonus, amountCompleted));
                }
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}