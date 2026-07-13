using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string name, string description, int points, bool isComplete = false) 
            : base(name, description, points)
        {
            _isComplete = isComplete;
        }

        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                return GetPoints();
            }
            return 0;
        }

        public override bool IsComplete()
        {
            return _isComplete;
        }

        public override string GetDetailsString()
        {
            string statusSign = _isComplete ? "[X]" : "[ ]";
            return $"{statusSign} {GetShortName()} ({GetDescription()})";
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{GetShortName()},{GetDescription()},{GetPoints()},{_isComplete}";
        }
    }
}