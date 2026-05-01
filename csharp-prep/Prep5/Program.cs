using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);

        int yearOfBirth;
        PromptUserYearOfBirth(out yearOfBirth);

        DisplayResult(userName, squaredNumber, yearOfBirth);
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome!");
    }

    static string PromptUserName()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    static void PromptUserYearOfBirth(out int yearOfBirth)
    {
        Console.Write($"Enter the year you were born in: ");
        yearOfBirth = int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void DisplayResult(string name, int square, int yearOfBirth)
    {
        int currentYear = DateTime.Now.Year;
        Console.WriteLine($"{name}, your number squared is {square}.");
        Console.WriteLine($"{name}, you will be turning {currentYear - yearOfBirth} years old this year.");
    }
}