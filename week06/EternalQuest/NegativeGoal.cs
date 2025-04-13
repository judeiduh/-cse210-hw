namespace EternalQuest
{
    public class NegativeGoal : Goal
    {
        public NegativeGoal(string name, string description, int points) 
            : base(name, description, points) { }

        public override int RecordEvent()
        {
            return -_points; // Deduct points for negative goals
        }

        public override bool IsComplete() => false; // Never complete

        public override string GetDetailsString()
        {
            return $"[ ] Avoid {_name} ({_description}) - Lose {_points} points if done";
        }

        public override string GetStringRepresentation()
        {
            return $"NegativeGoal:{_name},{_description},{_points}";
        }
    }
}