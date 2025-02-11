﻿using Simulator.Maps;

namespace Simulator
{
    public abstract class Creature : IMappable
    {
        private string name = "Unknown";
        public string Name
        {
            get { return name; }
            init
            {
                name = Validator.Shortener(value, 3, 25, '#');
            }
        }

        private int level = 1;
        public int Level
        {
            get { return level; }
            set
            {
                level = Validator.Limiter(value, 1, 10);
            }
        }

        public void Upgrade()
        {
            if (Level < 10)
                Level++;
        }

        public Creature(string name, int level = 1)
        {
            Name = name;
            Level = level;
        }

        public Creature() { }
        public abstract string Icon { get; }
        public abstract string Info { get; }
        public abstract string Greeting();
        public abstract int Power { get; }
        public abstract char Symbol { get; }
        public Map? CurrentMap { get; set; }
        public Point CurrentPosition { get; set; }
        public string GetIcon()
        {
            throw new NotImplementedException();
        }
        public string Go(Direction direction)
        {
            if (CurrentMap == null)
                throw new InvalidOperationException("Creature is not assigned to a map.");

            var newPosition = CurrentPosition.Next(direction);

            if (CurrentMap.Exist(newPosition))
            {
                CurrentMap.Move(this, CurrentPosition, newPosition);
                CurrentPosition = newPosition;
                return $"Moved {direction.ToString().ToLower()} to {newPosition}.";
            }

            return "Cannot move outside the map boundaries.";
        }

        public void AssignMap(Map map, Point startPosition)
        {
            CurrentMap = map;
            CurrentPosition = startPosition;
            map.Add(this, startPosition);
        }

        public override string ToString() => $"{GetType().Name.ToUpper()}: {CurrentPosition}";
    }
}
