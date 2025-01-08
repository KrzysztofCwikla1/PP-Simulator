using System;

namespace Simulator.Maps
{
    public class SmallSquareMap : Map
    {
        public readonly int Size;

        public SmallSquareMap(int size)
        {
            if (size < 5 || size > 20)
                throw new ArgumentOutOfRangeException("Map size must be between 5 and 20.");
            Size = size;
        }

        public override bool Exist(Point p)
        {
            var mapBounds = new Rectangle(0, 0, Size - 1, Size - 1);
            if (mapBounds.Contains(p))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override Point Next(Point p, Direction d)
        {
            var next = p.Next(d);
            if (Exist(next))
            {
                return next;
            }
            else
            {
                return p;
            }
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            var next = p.NextDiagonal(d);
            if (Exist(next))
            {
                return next;
            }
            else
            {
                return p;
            }
        }
    }
}