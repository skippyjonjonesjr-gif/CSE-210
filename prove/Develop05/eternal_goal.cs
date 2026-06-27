using System;

namespace EternalQuest
{

    public class EternalGoal : Goal
    {
        private int _streakCount; 

        public EternalGoal(string name, string description, int points, int streakCount = 0) 
            : base(name, description, points)
        {
            _streakCount = streakCount;
        }

        public override int RecordEvent()
        {
            _streakCount++;
            if (_streakCount % 5 == 0)
            {
                Console.WriteLine($"🔥 Streak Bonus! You've completed this {_streakCount} times in a row! (+20 Bonus XP)");
                return Points + 20;
            }
            return Points;
        }

        public override bool IsComplete() => false; 

        public override string GetDetailsString()
        {
            return $"[ ] {ShortName} ({Description}) — Current Streak: 🔥 {_streakCount}";
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{ShortName},{Description},{Points},{_streakCount}";
        }
    }
}