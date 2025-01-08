using Simulator;

namespace Tests
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData(3, 5, 10, 7)]
        [InlineData(12, 5, 10, 10)]
        [InlineData(2, 5, 10, 5)]
        public void TestLimiter(int value, int min, int max, int expected)
        {
            var result = Validator.Limiter(value, min, max);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("   short   ", 5, 10, '-', "Short")]
        [InlineData("longstringtest", 5, 10, '-', "Longstring")]
        [InlineData("   tooshort", 10, 15, '-', "Tooshort--")]
        public void TestShortener(string value, int min, int max, char placeholder, string expected)
        {
            var result = Validator.Shortener(value, min, max, placeholder);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("", 5, 10, '-', "-----")]
        [InlineData("12345", 3, 5, '*', "12345")]
        [InlineData("1234567890", 5, 10, '#', "1234567890")]
        [InlineData("short", 10, 20, '_', "Short_____")]
        public void TestShortenerWithEmptyAndLongValues(string value, int min, int max, char placeholder, string expected)
        {
            var result = Validator.Shortener(value, min, max, placeholder);
            Assert.Equal(expected, result);
        }
    }
}
