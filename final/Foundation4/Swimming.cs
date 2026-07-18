namespace ExerciseTracking
{
    public class Swimming : Activity
    {
        private int _laps;

        public Swimming(string date, double minutes, int laps) 
            : base(date, minutes, "Swimming")
        {
            _laps = laps;
        }

        public override double GetDistance()
        {
            return _laps * 50.0 / 1000.0 * 0.62;
        }
    }
}