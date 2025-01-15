using Simulator.Maps;
using Simulator;
namespace TestSimulator;
public class SmallMapTests
{
    [Fact]
    public void TestAddCreatureToMap()
    {
        // Arrange
        var map = new SmallMap(5, 5);
        var creature = new TestCreature("Test");
        var position = new Point(2, 2);

        // Act
        map.Add(creature, position);

        // Assert
        var creaturesAtPosition = map.At(position);
        Assert.Single(creaturesAtPosition);
        Assert.Contains(creature, creaturesAtPosition);
    }

    [Fact]
    public void TestRemoveCreatureFromMap()
    {
        // Arrange
        var map = new SmallMap(5, 5);
        var creature = new TestCreature("Test");
        var position = new Point(2, 2);
        map.Add(creature, position);

        // Act
        map.Remove(creature, position);

        // Assert
        var creaturesAtPosition = map.At(position);
        Assert.Empty(creaturesAtPosition);
    }

    [Fact]
    public void TestMoveCreatureOnMap()
    {
        // Arrange
        var map = new SmallMap(5, 5);
        var creature = new TestCreature("Test");
        var startPosition = new Point(2, 2);
        var newPosition = new Point(3, 2);
        map.Add(creature, startPosition);

        // Act
        map.Move(creature, startPosition, newPosition);

        // Assert
        var creaturesAtStartPosition = map.At(startPosition);
        var creaturesAtNewPosition = map.At(newPosition);

        Assert.Empty(creaturesAtStartPosition);
        Assert.Contains(creature, creaturesAtNewPosition);
    }

    [Fact]
    public void TestAtMethodWithCoordinates()
    {
        // Arrange
        var map = new SmallMap(5, 5);
        var creature1 = new TestCreature("Test1");
        var creature2 = new TestCreature("Test2");
        var position = new Point(2, 2);
        map.Add(creature1, position);
        map.Add(creature2, position);

        // Act
        var creaturesAtPosition = map.At(position);

        // Assert
        Assert.Equal(2, creaturesAtPosition.Count);
        Assert.Contains(creature1, creaturesAtPosition);
        Assert.Contains(creature2, creaturesAtPosition);
    }
}

// Testowa klasa dziedzicząca po Creature w celu zaimplementowania abstrakcyjnych metod
public class TestCreature : Creature
{
    public override char Symbol => 'T';
    public TestCreature(string name, int level = 1) : base(name, level) { }

    public override string Info => "Test Creature Info";
    public override string Greeting() => "Hello!";
    public override int Power => 10;
}
