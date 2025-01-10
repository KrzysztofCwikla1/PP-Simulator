namespace Simulator.Maps
{
    public class SmallTorusMap : SmallMap
    {
        public readonly int Size;

        public SmallTorusMap(int size) : base(size, size) { }

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
            int wrappedX = (p.X + SizeX) % SizeX;
            int wrappedY = (p.Y + SizeY) % SizeY;

            
            if (wrappedX == 0 && p.X != 0) wrappedX = SizeX - 1;
            if (wrappedY == 0 && p.Y != 0) wrappedY = SizeY - 1;

            return new Point(wrappedX, wrappedY);
        }
    }
}
