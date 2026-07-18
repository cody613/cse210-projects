using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("658 Jackson Lane", "Portland", "OR", "USA");
        Lecture lecture = new Lecture("Become a Master of Beginner Piano Chords", "A session on basic chord structures.", "20 Jul 2026", "5:00 PM", address1, "Dr. Mark Keys", 50);

        Address address2 = new Address("391 Glen Creek Road", "Salem", "OR", "USA");
        Reception reception = new Reception("Recital Meet & Greet", "Beginner arrangement showcase and mingling with performers,", "5 Aug 2026", "8:00 PM", address2, "rsvp@pianoclub.com");

        Address address3 = new Address("942 Oakvale Park", "Seattle", "WA", "USA");
        OutdoorGathering outdoor = new OutdoorGathering("Summer Concert Series", "Live performance by our top students.", "26 Aug 2026", "7:00 PM", address3, "Clear skies and 75 degrees");

        Console.WriteLine("----------------------------------");
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(lecture.GetShortDescription("Lecture"));

        Console.WriteLine("\n----------------------------------");
        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(reception.GetShortDescription("Reception"));

        Console.WriteLine("\n----------------------------------");
        Console.WriteLine(outdoor.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine(outdoor.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(outdoor.GetShortDescription("Outdoor Gathering"));
    }
}