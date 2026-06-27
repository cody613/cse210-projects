using System;

// CREATIVITY REQUIREMENT MET:
// I decided to implement a gamification feature that
// tracks the user's "level" based on their total score.
// As their points increase they move up the ranks of a
// piano-themed ranking system (starting with Scale
// Practicer and ending at Grand Maestro). The user's
// rank is calculated and displayed on the main menu.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}