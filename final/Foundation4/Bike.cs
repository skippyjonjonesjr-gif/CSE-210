namespace ExerciseTracking
{
    public class StationaryBike : Activity
    {
        private double _speed;

        public StationaryBike(string date, double minutes, double speed) 
            : base(date, minutes, "Stationary Bicycle")
        {
            _speed = speed;
        }

        public override double GetDistance()
        {
            return (_speed * GetMinutes()) / 60;
        }

        public override double GetSpeed()
        {
            return _speed;
        }
    }
}