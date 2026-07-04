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
                return Points;
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
            return $"{statusSign} {ShortName} ({Description})";
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{ShortName},{Description},{Points},{_isComplete}";
        }
    }
}
