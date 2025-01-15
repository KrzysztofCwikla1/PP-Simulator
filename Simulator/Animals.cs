using Simulator.Maps;

namespace Simulator;

public class Animals : IMappable
{
    private string description = "Unknown";
    public required string Description
    {
        get => description;
        init
        {
            description = Validator.Shortener(value, 3, 15, '#');
        }
    }

    public uint Size { get; set; } = 3;
    public virtual string Info => $"{Description} <{Size}>";
    public char Symbol => 'A';
    public Map? CurrentMap { get; protected set; }
    public Point CurrentPosition { get; protected set; }

    public virtual string Name => Description;

    public int Level => throw new NotImplementedException();

    Point IMappable.CurrentPosition
    {
        get => CurrentPosition;
        set => CurrentPosition = value;
    }

    Map? IMappable.CurrentMap
    {
        get => CurrentMap;
        set => CurrentMap = value;
    }
    protected void UpdatePosition(Point newPosition)
    {
        CurrentPosition = newPosition;
    }

    public void AssignMap(Map map, Point startPosition)
    {
        if (!map.Exist(startPosition))
            throw new ArgumentOutOfRangeException("Start position is outside map boundaries.");

        CurrentMap = map;
        CurrentPosition = startPosition;
        map.Add(this, startPosition);
    }

    public virtual string Go(Direction direction)
    {
        if (CurrentMap == null)
            throw new InvalidOperationException("Animal is not assigned to a map.");

        var newPosition = CurrentMap.Next(CurrentPosition, direction);

        if (CurrentMap.Exist(newPosition))
        {
            CurrentMap.Move(this, CurrentPosition, newPosition);
            CurrentPosition = newPosition;
            return $"Animal moved to {newPosition}.";
        }

        return "Animal cannot move outside the map boundaries.";
    }

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
}
