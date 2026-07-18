namespace ExerciseTracking
{
    public class Running : Activity
    {
        private double _distance;

        public Running(string date, double minutes, double distance) 
            : base(date, minutes, "Running")
        {
            _distance = distance;
        }

        public override double GetDistance()
        {
            return _distance;
        }
    }
}