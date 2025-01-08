using Simulator;

namespace Tests
{
    public class RectangleTests
    {
        [Fact]
        public void TestRectangleCreation()
        {
            var rect = new Rectangle(5, 5, 10, 10);
            Assert.Equal(5, rect.X1);
            Assert.Equal(5, rect.Y1);
            Assert.Equal(10, rect.X2);
            Assert.Equal(10, rect.Y2);
        }

        [Fact]
        public void TestRectangleCreationWithPoints()
        {
            var p1 = new Point(5, 5);
            var p2 = new Point(10, 10);
            var rect = new Rectangle(p1, p2);
            Assert.Equal(5, rect.X1);
            Assert.Equal(5, rect.Y1);
            Assert.Equal(10, rect.X2);
            Assert.Equal(10, rect.Y2);
        }

        [Fact]
        public void TestRectangleContains()
        {
            var rect = new Rectangle(5, 5, 10, 10);

            var pointInside = new Point(7, 7);
            var pointOutside = new Point(4, 4);

            Assert.True(rect.Contains(pointInside));
            Assert.False(rect.Contains(pointOutside));
        }

        [Fact]
        public void TestRectangleFlatCreation()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Rectangle(5, 5, 5, 5));
            Assert.Equal("Flat rectangles are not allowed.", exception.Message);
        }

        [Fact]
        public void TestRectangleNegativeCoordinates()
        {
            var rect = new Rectangle(-5, -5, -1, -1);
            Assert.Equal(-5, rect.X1);
            Assert.Equal(-5, rect.Y1);
            Assert.Equal(-1, rect.X2);
            Assert.Equal(-1, rect.Y2);
        }

        [Fact]
        public void TestRectangleLargeCoordinates()
        {
            var rect = new Rectangle(int.MinValue, int.MinValue, int.MaxValue, int.MaxValue);
            Assert.Equal(int.MinValue, rect.X1);
            Assert.Equal(int.MinValue, rect.Y1);
            Assert.Equal(int.MaxValue, rect.X2);
            Assert.Equal(int.MaxValue, rect.Y2);
        }

        [Fact]
        public void TestRectangleEdgeCoordinates()
        {
            var rect = new Rectangle(int.MaxValue - 1, int.MinValue, int.MaxValue, int.MinValue + 1);
            Assert.Equal(int.MaxValue - 1, rect.X1);
            Assert.Equal(int.MinValue,rect.Y1);
            Assert.Equal(int.MaxValue, rect.X2);
            Assert.Equal(int.MinValue + 1, rect.Y2);
        }
    }
}
