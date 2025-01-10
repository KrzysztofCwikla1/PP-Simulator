using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature { get { return Creatures[moveIndex % Creatures.Count]; } }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName { get { return Moves[moveIndex % Moves.Length].ToString().ToLower(); } }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        if (creatures.Count == 0)
        {
            throw new ArgumentException("Creatures list can't be empty.");
        }

        if (creatures.Count != positions.Count)
        {
            throw new ArgumentException("The number of creatures must match the number of positions.");
        }

        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves;
    }

    private int moveIndex = 0;

    /// <summary>
    /// Makes one move of current creature in current direction.
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

        // Move the current creature
        CurrentCreature.Go(direction);

        // If all moves have been performed, finish the simulation
        moveIndex++;
        if (moveIndex >= Moves.Length)
        {
            Finished = true;
        }
    }
}
