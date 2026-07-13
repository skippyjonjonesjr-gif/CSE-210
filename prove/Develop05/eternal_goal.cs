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
                Console.WriteLine($" Streak Bonus! You've completed this {_streakCount} times in a row! (+20 Bonus XP)");
                return GetPoints() + 20;
            }
            return GetPoints();
        }

        public override bool IsComplete()
        {
            return false;
        }

        public override string GetDetailsString()
        {
            return $"[ ] {GetShortName()} ({GetDescription()}) — Current Streak:  {_streakCount}";
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{GetShortName()},{GetDescription()},{GetPoints()},{_streakCount}";
        }
    }
}