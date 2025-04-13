using System;

namespace EternalQuest
{
    // Base abstract class for all goal types
    public abstract class Goal
    {
        protected string _name;
        protected string _description;
        protected int _points;
        protected bool _isComplete;

        public Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
            _isComplete = false;
        }

        public abstract int RecordEvent();
        public abstract bool IsComplete();
        public abstract string GetDetailsString();
        public abstract string GetStringRepresentation();

        public string GetName() => _name;
        public string GetDescription() => _description;
        public int GetPoints() => _points;
    }
}