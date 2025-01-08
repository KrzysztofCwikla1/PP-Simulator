using Simulator;

namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        public readonly int Size;

        public SmallTorusMap(int size)
        {
            if (size < 5 || size > 20)
                throw new ArgumentOutOfRangeException("Map size must be between 5 and 20.");
            Size = size;
        }

        public override bool Exist(Point p) => p.X >= 0 && p.X < Size && p.Y >= 0 && p.Y < Size;

        public override Point Next(Point p, Direction d)
        {
           
            var next = p.Next(d);
            return WrapPoint(next);
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            
            var next = p.NextDiagonal(d);
            return WrapPoint(next);
        }

        private Point WrapPoint(Point p)
        {
            int wrappedX = (p.X + Size) % Size;
            int wrappedY = (p.Y + Size) % Size;

            return new Point(wrappedX, wrappedY);
        }
    }
}
