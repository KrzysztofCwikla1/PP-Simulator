﻿namespace Simulator.Maps
{
    public class SmallSquareMap : SmallMap
    {
        public readonly int Size;

        public SmallSquareMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }


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