namespace Simulator;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = new();

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ?? throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;

        Run();
    }
    private void Run()
    {
        // Save the initial state
        TurnLogs.Add(CaptureTurnLog());

        // Simulate all turns and capture each state
        while (!_simulation.Finished)
        {
            _simulation.Turn();
            TurnLogs.Add(CaptureTurnLog());
        }
    }

    private SimulationTurnLog CaptureTurnLog()
    {
        // Create a dictionary representing the current map state
        var symbols = new Dictionary<Point, char>();

        for (int y = 0; y < SizeY; y++)
        {
            for (int x = 0; x < SizeX; x++)
            {
                var point = new Point(x, y);
                var mappablesAtPosition = _simulation.Map.At(point);

                char symbol = mappablesAtPosition.Count switch
                {
                    0 => ' ',
                    1 => mappablesAtPosition[0].Symbol,

                    _ => 'X'
                };

                if (symbol != ' ')
                    symbols[point] = symbol;
            }
        }

        // Create and return the turn log
        return new SimulationTurnLog
        {
            Mappable = _simulation.CurrentMappable.ToString(),
            Move = _simulation.CurrentMoveName,
            Symbols = symbols
        };
    }
}
