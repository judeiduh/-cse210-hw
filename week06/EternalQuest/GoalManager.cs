using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;
        private bool _hasFirstGoalBadge = false;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        public void Start()
        {
            while (true)
            {
                DisplayPlayerInfo();
                Console.WriteLine("\nMenu Options:");
                Console.WriteLine("  1. Create New Goal");
                Console.WriteLine("  2. List Goals");
                Console.WriteLine("  3. Save Goals");
                Console.WriteLine("  4. Load Goals");
                Console.WriteLine("  5. Record Event");
                Console.WriteLine("  6. Quit");
                Console.Write("Select a choice from the menu: ");
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
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void DisplayPlayerInfo()
        {
            Console.WriteLine($"\nYou have {_score} points.");
            CheckLevelUp();
        }

        private void ListGoalNames()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals have been created yet.");
                return;
            }

            Console.WriteLine("The goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
            }
        }

        private void ListGoalDetails()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("\nNo goals have been created yet.");
                return;
            }

            Console.WriteLine("\nThe goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        private void CreateGoal()
        {
            Console.WriteLine("\nThe types of Goals are:");
            Console.WriteLine("  1. Simple Goal");
            Console.WriteLine("  2. Eternal Goal");
            Console.WriteLine("  3. Checklist Goal");
            Console.WriteLine("  4. Negative Goal (Avoid a bad habit)");
            Console.Write("Which type of goal would you like to create? ");
            string typeChoice = Console.ReadLine();

            if (typeChoice != "1" && typeChoice != "2" && typeChoice != "3" && typeChoice != "4")
            {
                Console.WriteLine("Invalid goal type selection.");
                return;
            }

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal? ");
            if (!int.TryParse(Console.ReadLine(), out int points))
            {
                Console.WriteLine("Invalid points value. Please enter a number.");
                return;
            }

            switch (typeChoice)
            {
                case "1":
                    _goals.Add(new SimpleGoal(name, description, points));
                    break;
                case "2":
                    _goals.Add(new EternalGoal(name, description, points));
                    break;
                case "3":
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    if (!int.TryParse(Console.ReadLine(), out int target) || target <= 0)
                    {
                        Console.WriteLine("Invalid target value. Please enter a positive number.");
                        return;
                    }
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    if (!int.TryParse(Console.ReadLine(), out int bonus))
                    {
                        Console.WriteLine("Invalid bonus value. Please enter a number.");
                        return;
                    }
                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                    break;
                case "4":
                    _goals.Add(new NegativeGoal(name, description, points));
                    break;
            }

            if (!_hasFirstGoalBadge && _goals.Count > 0)
            {
                _hasFirstGoalBadge = true;
                Console.WriteLine("\n🏆 You earned the 'First Goal' badge! 🏆");
            }

            Console.WriteLine("Goal created successfully!");
        }

        private void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals available to record.");
                return;
            }

            ListGoalNames();
            Console.Write("Which goal did you accomplish? ");
            if (!int.TryParse(Console.ReadLine(), out int goalNumber) || goalNumber < 1 || goalNumber > _goals.Count)
            {
                Console.WriteLine("Invalid goal selection.");
                return;
            }

            Goal selectedGoal = _goals[goalNumber - 1];
            int pointsEarned = selectedGoal.RecordEvent();
            _score += pointsEarned;

            Console.WriteLine($"\nCongratulations! You have earned {pointsEarned} points!");
            if (selectedGoal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                Console.WriteLine("⭐ Bonus: You completed a checklist goal! ⭐");
            }

            CheckBadges();
        }

        private void SaveGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string filename = Console.ReadLine();

            try
            {
                using (StreamWriter outputFile = new StreamWriter(filename))
                {
                    outputFile.WriteLine(_score);
                    outputFile.WriteLine(_hasFirstGoalBadge);
                    foreach (Goal goal in _goals)
                    {
                        outputFile.WriteLine(goal.GetStringRepresentation());
                    }
                }
                Console.WriteLine("Goals saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving goals: {ex.Message}");
            }
        }

        private void LoadGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string filename = Console.ReadLine();

            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(filename);
                if (lines.Length < 2)
                {
                    Console.WriteLine("Invalid file format.");
                    return;
                }


                _goals = new List<Goal>();
                _score = int.Parse(lines[0]);
                _hasFirstGoalBadge = bool.Parse(lines[1]);

                for (int i = 2; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(':');
                    if (parts.Length < 2) continue;

                    string goalType = parts[0];
                    string[] goalData = parts[1].Split(',');

                    switch (goalType)
                    {
                        case "SimpleGoal":
                            if (goalData.Length >= 4)
                            {
                                var goal = new SimpleGoal(goalData[0], goalData[1], int.Parse(goalData[2]));
                               
                            }
                            break;
                        case "EternalGoal":
                            if (goalData.Length >= 3)
                                _goals.Add(new EternalGoal(goalData[0], goalData[1], int.Parse(goalData[2])));
                            break;
                        case "ChecklistGoal":
                            if (goalData.Length >= 6)
                            {
                                var goal = new ChecklistGoal(
                                    goalData[0], goalData[1],
                                    int.Parse(goalData[2]),
                                    int.Parse(goalData[4]),
                                    int.Parse(goalData[3]));
                                
                                // This is a workaround since we don't have direct access to _amountCompleted
                                // In a real application, we would add a method to set this value
                                for (int j = 0; j < int.Parse(goalData[5]); j++)
                                {
                                    goal.RecordEvent();
                                }
                                _goals.Add(goal);
                            }
                            break;
                        case "NegativeGoal":
                            if (goalData.Length >= 3)
                                _goals.Add(new NegativeGoal(goalData[0], goalData[1], int.Parse(goalData[2])));
                            break;
                    }
                }
                Console.WriteLine("Goals loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading goals: {ex.Message}");
                _goals = new List<Goal>();
                _score = 0;
                _hasFirstGoalBadge = false;
            }
        }

        private void CheckLevelUp()
        {
            int level = _score / 1000;
            if (level > 0 && _score % 1000 < 100 && _score > 0)
            {
                Console.WriteLine($"\n⭐ LEVEL UP! You reached level {level}! ⭐");
            }
        }

        private void CheckBadges()
        {
            if (_score >= 5000 && _hasFirstGoalBadge)
            {
                Console.WriteLine("\n🏆 You earned the 'Master Goal Achiever' badge! 🏆");
            }
        }
    }
}