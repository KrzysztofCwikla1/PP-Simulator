using Simulator.Maps;
using TestSimulator;

namespace Simulator.Tests;

public class CreatureTests
{
    

    [Fact]
    public void TestCreatureGoWithinMap()
    {
        // Arrange
        var map = new SmallMap(5, 5);
        var creature = new TestCreature("Test");
        creature.AssignMap(map, new Point(2, 2));

        // Act
        var result = creature.Go(Direction.Up);

        // Assert
        Assert.Equal("Moved up to (2, 3).", result);
        Assert.Equal(new Point(2, 3), creature.CurrentPosition);
    }

    [Fact]
    public void TestCreatureGoOutsideMap()
    {
        // Arrange
        var map = new SmallMap(5, 5);
        var creature = new TestCreature("Test");
        creature.AssignMap(map, new Point(0, 0));

        // Act
        var result = creature.Go(Direction.Left);

        // Assert
        Assert.Equal("Cannot move outside the map boundaries.", result);
        Assert.Equal(new Point(0, 0), creature.CurrentPosition);
    }
}

