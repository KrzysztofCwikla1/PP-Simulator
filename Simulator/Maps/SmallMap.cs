using System.Drawing;

namespace Simulator.Maps
{
    public class SmallMap : Map
    {
        private Dictionary<Point, List<IMappable>> _mappablesAtPosition;

        public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            _mappablesAtPosition = new Dictionary<Point, List<IMappable>>();
            if (sizeX > 20 || sizeY > 20)
                throw new ArgumentOutOfRangeException("SmallMap size can't exceed 20x20.");
        }

        public override void Add(IMappable mappable, Point position)
        {
            if (!Exist(position))
                throw new ArgumentOutOfRangeException("Position is outside the map bounds.");

            if (!_mappablesAtPosition.ContainsKey(position))
                _mappablesAtPosition[position] = new List<IMappable>();

            _mappablesAtPosition[position].Add(mappable);
        }

        public override void Remove(IMappable mappable, Point position)
        {
            if (_mappablesAtPosition.ContainsKey(position))
            {
                _mappablesAtPosition[position].Remove(mappable);
            }
        }

        public override void Move(IMappable mappable, Point oldPosition, Point newPosition)
        {
            Remove(mappable, oldPosition);
            Add(mappable, newPosition);
        }

        public override List<IMappable> At(Point position)
        {
            return _mappablesAtPosition.ContainsKey(position) ? _mappablesAtPosition[position] : new List<IMappable>();
        }

        public override Point Next(Point p, Direction d)
        {
            return p.Next(d);
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            return p.NextDiagonal(d);
        }
    }
}
