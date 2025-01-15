namespace Simulator.Maps
{
    public abstract class Map
    {
        public int SizeX { get; }
        public int SizeY { get; }

        private readonly Dictionary<Point, List<IMappable>> _mappablesAtPosition;

        protected Map(int sizeX, int sizeY)
        {
            if (sizeX < 5 || sizeY < 5)
                throw new ArgumentOutOfRangeException("Map can't be smaller than 5x5.");

            SizeX = sizeX;
            SizeY = sizeY;
            _mappablesAtPosition = new Dictionary<Point, List<IMappable>>();
        }

        /// <summary>
        /// Check if given point belongs to the map.
        /// </summary>
        public bool Exist(Point p)
        {
            var mapBounds = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
            return mapBounds.Contains(p);
        }

        /// <summary>
        /// Next position to the point in a given direction.
        /// </summary>
        public abstract Point Next(Point p, Direction d);

        /// <summary>
        /// Next diagonal position to the point in a given direction 
        /// rotated 45 degrees clockwise.
        /// </summary>
        public abstract Point NextDiagonal(Point p, Direction d);

        /// <summary>
        /// Add an IMappable object to the map at a specified position.
        /// </summary>
        public virtual void Add(IMappable mappable, Point position)
        {
            if (!Exist(position))
                throw new ArgumentOutOfRangeException("Position is outside the map bounds.");

            if (!_mappablesAtPosition.ContainsKey(position))
                _mappablesAtPosition[position] = new List<IMappable>();

            _mappablesAtPosition[position].Add(mappable);
        }

        /// <summary>
        /// Remove an IMappable object from the map at a specified position.
        /// </summary>
        public virtual void Remove(IMappable mappable, Point position)
        {
            if (_mappablesAtPosition.ContainsKey(position))
            {
                _mappablesAtPosition[position].Remove(mappable);

                // Clean up empty lists to conserve memory
                if (_mappablesAtPosition[position].Count == 0)
                    _mappablesAtPosition.Remove(position);
            }
        }

        /// <summary>
        /// Move an IMappable object from one position to another on the map.
        /// </summary>
        public virtual void Move(IMappable mappable, Point oldPosition, Point newPosition)
        {
            Remove(mappable, oldPosition);
            Add(mappable, newPosition);
        }

        /// <summary>
        /// Retrieve a list of IMappable objects at a specified position.
        /// </summary>
        public virtual List<IMappable> At(Point position)
        {
            return _mappablesAtPosition.ContainsKey(position)
                ? _mappablesAtPosition[position]
                : new List<IMappable>();
        }
    }
}