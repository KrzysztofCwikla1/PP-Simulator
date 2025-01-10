using Simulator;

namespace TestSimulator;

public class DirectionParserTests
{
    [Fact]
    public void Parse_ShouldParseDirectionsCorrectly()
    {
        // Arrange
        string input = "URDL";
        var expected = new List<Direction>
        {
            Direction.Up,
            Direction.Right,
            Direction.Down,
            Direction.Left
        };

        // Act
        var result = DirectionParser.Parse(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parse_ShouldHandleLowercaseLetters()
    {
        // Arrange
        string input = "urdl";
        var expected = new List<Direction>
        {
            Direction.Up,
            Direction.Right,
            Direction.Down,
            Direction.Left
        };

        // Act
        var result = DirectionParser.Parse(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parse_ShouldReturnEmptyListForEmptyString()
    {
        // Arrange
        string input = "";
        var expected = new List<Direction>(); // Oczekiwana pusta lista

        // Act
        var result = DirectionParser.Parse(input);

        // Assert
        Assert.Empty(result); // Mo¿na równie¿ porównaæ do oczekiwanej pustej listy
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("urdlx", new[] { Direction.Up, Direction.Right, Direction.Down, Direction.Left })]
    [InlineData("xxxdR lyyLTyu", new[] { Direction.Down, Direction.Right, Direction.Left, Direction.Left, Direction.Up })]
    public void Parse_ShouldIgnoreInvalidCharacters(string input, Direction[] expectedArray)
    {
        // Arrange
        var expected = new List<Direction>(expectedArray); // Konwersja tablicy na listê

        // Act
        var result = DirectionParser.Parse(input);

        // Assert
        Assert.Equal(expected, result);
    }
}
