using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted = 0) 
            : base(name, description, points)
        {
            _target = target;
            _bonus = bonus;
            _amountCompleted = amountCompleted;
        }

        public override int RecordEvent()
        {
            if (_amountCompleted < _target)
            {
                _amountCompleted++;
                if (_amountCompleted == _target)
                {
                    return GetPoints() + _bonus; 
                }
                return GetPoints();
            }
            return 0;
        }

        public override bool IsComplete()
        {
            return _amountCompleted >= _target;
        }

        public override string GetDetailsString()
        {
            string statusSign = IsComplete() ? "[X]" : "[ ]";
            return $"{statusSign} {GetShortName()} ({GetDescription()}) — Currently completed: {_amountCompleted}/{_target}";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{GetShortName()},{GetDescription()},{GetPoints()},{_amountCompleted},{_target},{_bonus}";
        }
    }
}