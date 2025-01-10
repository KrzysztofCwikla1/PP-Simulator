namespace Simulator.Maps
{
    public class SmallTorusMap : SmallMap
    {
        public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

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

            return new Point(wrappedX, wrappedY);
        }
    }
}
