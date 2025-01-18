using Simulator.Maps;

namespace Simulator;
public class SimulationTurnLog
{
    /// <summary>
    /// Text representastion of moving object in this turn.
    /// CurrentMappable.ToString()
    /// </summary>
    
    public required string Mappable { get; init; }
    /// <summary>
    /// Text representation of move in this turn.
    /// CurrentMoveName.ToString();
    /// </summary>
    public required string Move { get; init; }
    /// <summary>
    /// Dictionary of IMappable.Symbol on the map in this turn.
    /// </summary>
    public required Dictionary<Point, string> Icons { get; init; }
    public required Dictionary<Point, char> Symbols { get; init; }
    public object? CurrentMappable { get; set; }
}