
namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; set; } = true;

    

    public override string Info
    {
        get => $"{Description} (fly{(CanFly ? "+" : "-")}) <{Size}>";
    }
    public override char Symbol => CanFly ? 'B' : 'b';
    public override string Icon => CanFly ? "🦅" : "🐦";
    public override string Go(Direction direction)
    {
        if (CurrentMap == null)
            throw new InvalidOperationException("Bird is not assigned to a map.");

        Point newPosition;

        if (CanFly)
        {
            newPosition = CurrentMap.Next(CurrentPosition, direction);
            newPosition = CurrentMap.Next(newPosition, direction);
        }
        else
        {
            newPosition = CurrentMap.NextDiagonal(CurrentPosition, direction);
        }

        if (CurrentMap.Exist(newPosition))
        {
            CurrentMap.Move(this, CurrentPosition, newPosition);
            CurrentPosition = newPosition;
            return $"Bird moved {(CanFly ? "two steps" : "diagonally")} to {newPosition}.";
        }

        return "Bird cannot move outside the map boundaries.";
    }

}
