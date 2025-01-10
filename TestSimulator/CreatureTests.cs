using Simulator.Maps;
using TestSimulator;

namespace Simulator.Tests;

public class CreatureTests
{
    

    [Fact]
    public void TestCreatureGoWithinMap()
    {
        
        var map = new SmallMap(5, 5);
        var creature = new TestCreature("Test");
        creature.AssignMap(map, new Point(2, 2));

        
        var result = creature.Go(Direction.Up);

        Assert.Equal("Moved up to (2, 3).", result);
        Assert.Equal(new Point(2, 3), creature.CurrentPosition);
    }

    [Fact]
    public void TestCreatureGoOutsideMap()
    {
        
        var map = new SmallMap(5, 5);
        var creature = new TestCreature("Test");
        creature.AssignMap(map, new Point(0, 0));


        var result = creature.Go(Direction.Left);

       
        Assert.Equal("Cannot move outside the map boundaries.", result);
        Assert.Equal(new Point(0, 0), creature.CurrentPosition);
    }
}

