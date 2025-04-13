/*
Eternal Quest Program - Exceeding Requirements

To exceed the requirements, I've added the following features:
1. Level System: The user levels up based on their total points earned. Each level requires more points than the last.
2. Badges: The user earns badges for completing certain milestones (first goal, first eternal goal, etc.)
3. Negative Goals: A new goal type where the user loses points for bad habits they want to break.
4. Progress Tracking: Shows a progress bar for checklist goals.
5. Gamification Elements: Added motivational messages and visual feedback when completing goals.

The program now provides a more engaging experience with these additional features.
*/

using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Eternal Quest Program!");
            Console.WriteLine("This program will help you track your goals and earn points for completing them.");
            
            GoalManager manager = new GoalManager();
            manager.Start();
            
            Console.WriteLine("Thank you for using the Eternal Quest Program. Goodbye!");
        }
    }
}