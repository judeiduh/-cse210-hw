namespace ExerciseTracking
{
    public class Swimming : Activity
    {
        private int _laps;
        private const double LapLengthInMeters = 50;
        private const double MetersToMiles = 0.000621371;

        public Swimming(DateTime date, int minutes, int laps)
            : base(date, minutes)
        {
            _laps = laps;
        }

        public override double GetDistance() => (_laps * LapLengthInMeters) * MetersToMiles;
        public override double GetSpeed() => (GetDistance() / Minutes) * 60;
        public override double GetPace() => Minutes / GetDistance();

        // Optionally override GetSummary to show laps
        public override string GetSummary()
        {
            return $"{Date.ToString("dd MMM yyyy")} {GetType().Name} ({Minutes} min) - " +
                   $"Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, " +
                   $"Pace: {GetPace():F1} min per mile, Laps: {_laps}";
        }
    }
}