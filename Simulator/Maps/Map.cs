namespace Simulator.Maps;

/// <summary>
/// Base class for rectangular maps.
/// </summary>
public abstract class Map
{
    public int SizeX { get; }
    public int SizeY { get; }

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeY < 5)
            throw new ArgumentOutOfRangeException("Map can't be smaller than 5x5.");

        SizeX = sizeX;
        SizeY = sizeY;
    }

    /// <summary>
    /// Check if given point belongs to the map.
    /// </summary>
    public bool Exist(Point p)
    {
        var mapBounds = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
        if (mapBounds.Contains(p))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    public abstract Point NextDiagonal(Point p, Direction d);
    
    public abstract void Add(Creature creature, Point position);

   
    public abstract void Remove(Creature creature, Point position);

    
    public abstract void Move(Creature creature, Point oldPosition, Point newPosition);

    
   

    public abstract List<Creature> At(Point position);
}

