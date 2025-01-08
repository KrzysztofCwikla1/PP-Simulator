using Simulator;

namespace Tests
{
    public class PointTests
    {
        [Fact]
        public void TestPointToString()
        {
            var point = new Point(3, 4);
            Assert.Equal("(3, 4)", point.ToString());
        }

        [Fact]
        public void TestPointNext()
        {
            var point = new Point(2, 2);

            // Sprawdzamy ruchy w różnych kierunkach
            var up = point.Next(Direction.Up);
            Assert.Equal(new Point(2, 3), up);

            var down = point.Next(Direction.Down);
            Assert.Equal(new Point(2, 1), down);

            var left = point.Next(Direction.Left);
            Assert.Equal(new Point(1, 2), left);

            var right = point.Next(Direction.Right);
            Assert.Equal(new Point(3, 2), right);
        }

        [Fact]
        public void TestPointNextDiagonal()
        {
            var point = new Point(2, 2);

            // Sprawdzamy ruchy po przekątnej
            var upRight = point.NextDiagonal(Direction.Up);
            Assert.Equal(new Point(3, 3), upRight);

            var downLeft = point.NextDiagonal(Direction.Down);
            Assert.Equal(new Point(1, 1), downLeft);

            var upLeft = point.NextDiagonal(Direction.Left);
            Assert.Equal(new Point(1, 3), upLeft);

            var downRight = point.NextDiagonal(Direction.Right);
            Assert.Equal(new Point(3, 1), downRight);
        }

        [Fact]
        public void TestPointNextWithLargeCoordinates()
        {
            // Test z ekstremalnymi wartościami
            var point = new Point(int.MaxValue, int.MinValue);
            var nextPoint = point.Next(Direction.Up);
            Assert.Equal(new Point(int.MaxValue, int.MinValue + 1), nextPoint);
        }

        [Fact]
        public void TestPointNextWithNegativeCoordinates()
        {
            var point = new Point(-5, -5);
            var nextPoint = point.Next(Direction.Up);
            Assert.Equal(new Point(-5, -4), nextPoint);
        }

        [Fact]
        public void TestPointNextDiagonalWithNegativeCoordinates()
        {
            var point = new Point(-5, -5);
            var nextPoint = point.NextDiagonal(Direction.Right);
            Assert.Equal(new Point(-4, -6), nextPoint);
        }

        [Fact]
        public void TestPointNextAtEdge()
        {
            var point = new Point(0, 0);

            // Edge case at (0,0) with directions
            var up = point.Next(Direction.Up);
            Assert.Equal(new Point(0, 1), up);

            var right = point.Next(Direction.Right);
            Assert.Equal(new Point(1, 0), right);
        }
    }
}
