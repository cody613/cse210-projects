using System;

// COMPLETED STRETCH GOALS:
// 1. The Reflection Activity doesn't repeat any questions until all have already been asked.
// 2. This program keeps a log of how many times each activity was performed and displays it when quitting.

class Program
{
    static void Main(string[] args)
    {
        int breathingLog = 0;
        int reflectionLog = 0;
        int listingLog = 0;

        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Start breathing activity");
            Console.WriteLine(" 2. Start reflection activity");
            Console.WriteLine(" 3. Start listing activity");
            Console.WriteLine(" 4. Quit");
            Console.Write("Choose a choice from the menu: ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.Run();
                breathingLog++;
            }
            else if (choice == "2")
            {
                ReflectionActivity reflectionActivity = new ReflectionActivity();
                reflectionActivity.Run();
                reflectionLog++;
            }
            else if (choice == "3")
            {
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.Run();
                listingLog++;                
            }
        }

        Console.Clear();
        Console.WriteLine("Thanks for using this Mindfullness Program!");
        Console.WriteLine("Summary of your session:");
        Console.WriteLine($"- Breathing Activities Completed: {breathingLog}");
        Console.WriteLine($"- Reflection Activities Completed: {reflectionLog}");
        Console.WriteLine($"- Listing Activities Completed: {listingLog}");
        Console.WriteLine();
    }
}