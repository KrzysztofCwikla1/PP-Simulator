using Simulator.Maps;
using Simulator;

namespace Tests
{
    public class SmallSquareMapTests
    {
        [Fact]
        public void TestSmallSquareMapCreation()
        {
            int sizeX = 10;
            int sizeY = 10;

            // Act
            var map = new SmallSquareMap(sizeX, sizeY);

            // Assert
            Assert.Equal(sizeX, map.SizeX);
            Assert.Equal(sizeY, map.SizeY);
        }

        [Fact]
        public void TestSmallSquareMapExist()
        {
            var map = new SmallSquareMap(10,10);
            var pointInside = new Point(5, 5);
            var pointOutside = new Point(10, 10);

            Assert.True(map.Exist(pointInside));
            Assert.False(map.Exist(pointOutside));
        }

        [Fact]
        public void TestSmallSquareMapNext()
        {
            var map = new SmallSquareMap(10, 10);
            var point = new Point(5, 5);

            var up = map.Next(point, Direction.Up);
            Assert.Equal(new Point(5, 6), up);
            var down = map.Next(point, Direction.Down);
            Assert.Equal(new Point(5, 4), down);
            var left = map.Next(point, Direction.Left);
            Assert.Equal(new Point(4, 5), left);
            var right = map.Next(point, Direction.Right);
            Assert.Equal(new Point(6, 5), right);
        }

        [Fact]
        public void TestSmallSquareMapNextDiagonal()
        {
            var map = new SmallSquareMap(10, 10);
            var point = new Point(5, 5);

            var upRight = map.NextDiagonal(point, Direction.Up);
            Assert.Equal(new Point(6, 6), upRight);
            var downLeft = map.NextDiagonal(point, Direction.Down);
            Assert.Equal(new Point(4, 4), downLeft);
            var upLeft = map.NextDiagonal(point, Direction.Left);
            Assert.Equal(new Point(4, 6), upLeft);
            var downRight = map.NextDiagonal(point, Direction.Right);
            Assert.Equal(new Point(6, 4), downRight);
        }

        [Fact]
        public void TestSmallSquareMapExistEdge()
        {
            var map = new SmallSquareMap(10,10);
            var edgePoint = new Point(9, 9);
            Assert.True(map.Exist(edgePoint));
            var outsidePoint = new Point(10, 10);
            Assert.False(map.Exist(outsidePoint));
        }

        [Fact]
        public void TestSmallSquareMapNextAtEdge()
        {
            var map = new SmallSquareMap(10, 10);
            var edgePoint = new Point(9, 9);
            var up = map.Next(edgePoint, Direction.Up);
            Assert.Equal(new Point(9, 9), up);
            var right = map.Next(edgePoint, Direction.Right);
            Assert.Equal(new Point(9, 9), right);
            var left = map.Next(edgePoint, Direction.Left);
            Assert.Equal(new Point(8, 9), left);
            var down = map.Next(edgePoint, Direction.Down);
            Assert.Equal(new Point(9, 8), down);
        }

        [Fact]
        public void TestSmallSquareMapNextDiagonalAtEdge()
        {
            var map = new SmallSquareMap(10, 10);
            var edgePoint = new Point(9, 9);

            var upRight = map.NextDiagonal(edgePoint, Direction.Up);
            Assert.Equal(new Point(9, 9), upRight);

            var downLeft = map.NextDiagonal(edgePoint, Direction.Down);
            Assert.Equal(new Point(8, 8), downLeft);

            var upLeft = map.NextDiagonal(edgePoint, Direction.Left);
            Assert.Equal(new Point(9,9), upLeft);

            var downRight = map.NextDiagonal(edgePoint, Direction.Right);
            Assert.Equal(new Point(9, 9), downRight);
        }
        [Fact]
        public void TestSmallSquareMapCreationWithInvalidSize()
        {
            
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(3, 3));
            Assert.Contains("Map can't be smaller than 5x5.", ex.Message);

           
             ex = Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(21, 21));
            Assert.Contains("SmallMap size can't exceed 20x20.", ex.Message);
        }

    }
}
