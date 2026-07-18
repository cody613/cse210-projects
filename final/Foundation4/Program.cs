using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running running = new Running("14 Jul 2026", 30, 3.2);
        Cycling cycling = new Cycling("16 Jul 2026", 45, 10.5);
        Swimming swimming = new Swimming("17 Jul 2026", 20, 15);

        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}