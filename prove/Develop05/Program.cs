using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
   
    class Program
    {
        private static List<Goal> _goals = new List<Goal>();
        private static int _score = 0;

        private static int GetPlayerLevel() => (_score / 1000) + 1;

        static void Main(string[] args)
        {

            bool running = true;
            while (running)
            {
                Console.WriteLine();
                Console.WriteLine($"--- 🏆 Score: {_score} Points | 🛡️ Level: {GetPlayerLevel()} ---");
                Console.WriteLine();
                Console.WriteLine("Menu Options:");
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
                    case "1": CreateGoalMenu(); break;
                    case "2": ListGoals(); break;
                    case "3": SaveGoals(); break;
                    case "4": LoadGoals(); break;
                    case "5": RecordGoalEvent(); break;
                    case "6": running = false; break;
                    default: Console.WriteLine("Invalid selection. Try again."); break;
                }
            }
        }

        static void CreateGoalMenu()
        {
            Console.WriteLine("\nThe types of Goals are:");
            Console.WriteLine("  1. Simple Goal");
            Console.WriteLine("  2. Eternal Goal");
            Console.WriteLine("  3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            string type = Console.ReadLine();

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            if (type == "1")
            {
                _goals.Add(new SimpleGoal(name, description, points));
            }
            else if (type == "2")
            {
                _goals.Add(new EternalGoal(name, description, points));
            }
            else if (type == "3")
            {
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
            }
        }

        static void ListGoals()
        {
            Console.WriteLine("\nThe goals are:");
            if (_goals.Count == 0) Console.WriteLine("(No goals created yet)");
            
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        static void SaveGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string filename = Console.ReadLine();

            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score); 
                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals successfully saved!");
        }

        static void LoadGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string filename = Console.ReadLine();

            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            _goals.Clear();
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]); 

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] mainParts = line.Split(':');
                string goalType = mainParts[0];
                string[] dataParts = mainParts[1].Split(',');

                if (goalType == "SimpleGoal")
                {
                    _goals.Add(new SimpleGoal(dataParts[0], dataParts[1], int.Parse(dataParts[2]), bool.Parse(dataParts[3])));
                }
                else if (goalType == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(dataParts[0], dataParts[1], int.Parse(dataParts[2]), int.Parse(dataParts[3])));
                }
                else if (goalType == "ChecklistGoal")
                {
                    _goals.Add(new ChecklistGoal(dataParts[0], dataParts[1], int.Parse(dataParts[2]), int.Parse(dataParts[4]), int.Parse(dataParts[5]), int.Parse(dataParts[3])));
                }
            }
            Console.WriteLine("Goals successfully loaded!");
        }

        static void RecordGoalEvent()
        {
            ListGoals();
            if (_goals.Count == 0) return;

            Console.Write("Which goal did you accomplish? ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < _goals.Count)
            {
                int pointsEarned = _goals[index].RecordEvent();
                _score += pointsEarned;
                Console.WriteLine($"🎉 Congratulations! You have earned {pointsEarned} points!");
                Console.WriteLine($"You now have {_score} points.");
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }
    }
}