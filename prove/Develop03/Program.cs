using System;

// For the stretch challenge, I chose to modify the HideRandomWords method in Scripture.cs to only select words that weren't already hidden.

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Moroni", 10, 4, 5);

        string text = "And when ye shall recieve these things, I would exhort you that ye would ask God, the Eternal Father, in the name Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost. And by the power of the Holy Ghost ye may know the truth of all things.";

        Scripture scripture = new Scripture(reference, text);

        string input = "";

        while (input != "quit")
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
        
            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine("Press enter to countiue or type 'quit' to finish:");
            input = Console.ReadLine();

            if (input == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }
}