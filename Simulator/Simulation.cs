using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Objects (e.g., creatures, animals) moving on the map.
    /// </summary>
    public List<IMappable> Mappables { get; }

    /// <summary>
    /// Starting positions of objects.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of objects' moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first object, second for second and so on.
    /// When all objects make moves, 
    /// next move is again for first object and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Object which will be moving this turn.
    /// </summary>
    public IMappable CurrentMappable { get { return Mappables[moveIndex % Mappables.Count]; } }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName { get { return Moves[moveIndex % Moves.Length].ToString().ToLower(); } }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if mappables' list is empty,
    /// if number of mappables differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> mappables,
        List<Point> positions, string moves)
    {
        if (mappables.Count == 0)
        {
            throw new ArgumentException("Objects list can't be empty.");
        }

        if (mappables.Count != positions.Count)
        {
            throw new ArgumentException("The number of objects must match the number of positions.");
        }

        Map = map;
        Mappables = mappables;
        Positions = positions;
        Moves = moves;

        // Assign the map and initial positions to each mappable object
        for (int i = 0; i < mappables.Count; i++)
        {
            mappables[i].AssignMap(map, positions[i]);
        }
    }

    private int moveIndex = 0;

    /// <summary>
    /// Makes one move of the current object in the current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("Simulation has already finished.");
        }

        // Get the direction from the moves list
        var direction = DirectionParser.Parse(CurrentMoveName)[0];

        // Move the current object
        CurrentMappable.Go(direction);

        // If all moves have been performed, finish the simulation
        moveIndex++;
        if (moveIndex >= Moves.Length)
        {
            Finished = true;
        }
    }
}
