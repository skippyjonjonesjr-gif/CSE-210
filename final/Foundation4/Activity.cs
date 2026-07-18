using System;

namespace ExerciseTracking
{
    public abstract class Activity
    {
        private string _date;
        private double _minutes;
        private string _activityType;

        public Activity(string date, double minutes, string activityType)
        {
            _date = date;
            _minutes = minutes;
            _activityType = activityType;
        }

        public double GetMinutes()
        {
            return _minutes;
        }

        public abstract double GetDistance();
        
        public virtual double GetSpeed()
        {
            return (GetDistance() / _minutes) * 60;
        }

        public virtual double GetPace()
        {
            return _minutes / GetDistance();
        }

        public string GetSummary()
        {
            return _date + " " + _activityType + " (" + _minutes + " min) - Distance: " + 
                   string.Format("{0:F1}", GetDistance()) + " miles, Speed: " + 
                   string.Format("{0:F1}", GetSpeed()) + " mph, Pace: " + 
                   string.Format("{0:F2}", GetPace()) + " min per mile";
        }
    }
}