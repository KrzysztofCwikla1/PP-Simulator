namespace Simulator;

public static class DirectionParser
{
    public static List<Direction> Parse(string input)
    {
        var directions = new List<Direction>();

        foreach (var chr in input.ToUpper())
        {
            if (chr == 'U')
            {
                directions.Add(Direction.Up);
            }
            else if (chr == 'R')
            {
                directions.Add(Direction.Right);
            }
            else if (chr == 'D')
            {
                directions.Add(Direction.Down);
            }
            else if (chr == 'L')
            {
                directions.Add(Direction.Left);
            }
        }
        return directions; // Zwracamy List<Direction>
    }
}

