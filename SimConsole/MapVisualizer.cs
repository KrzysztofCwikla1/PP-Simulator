using Simulator.Maps;
using Simulator;

namespace SimConsole;

public class MapVisualizer
{
    private readonly Map _map;
    private int _turnCounter;

    public MapVisualizer(Map map)
    {
        _map = map;
        _turnCounter = 1;
    }

    public void Draw(Simulation simulation)
    {
        Console.WriteLine("\n");
        Console.WriteLine($"Turn: {_turnCounter}");
        Console.WriteLine($"{FormatMoveInfo(simulation)}");

        int width = _map.SizeX;
        int height = _map.SizeY;

        Console.Write(Box.TopLeft);
        for (int i = 0; i < width; i++)
        {
            Console.Write(Box.Horizontal);
            if (i < width - 1) Console.Write(Box.TopMid);
        }
        Console.WriteLine(Box.TopRight);

        for (int y = 0; y < height; y++)
        {
            Console.Write(Box.Vertical);
            for (int x = 0; x < width; x++)
            {
                var mappablesAtPosition = _map.At(new Point(x, y));
                char symbol = mappablesAtPosition.Count switch
                {
                    0 => ' ',
                    1 => mappablesAtPosition[0] switch
                    {
                        Orc _ => 'O',
                        Elf _ => 'E',
                        _ => '?' 
                    },
                    _ => 'X'
                };
                Console.Write(symbol);
                Console.Write(Box.Vertical);
            }
            Console.WriteLine();

            if (y < height - 1)
            {
                Console.Write(Box.MidLeft);
                for (int i = 0; i < width; i++)
                {
                    Console.Write(Box.Horizontal);
                    if (i < width - 1) Console.Write(Box.Cross);
                }
                Console.WriteLine(Box.MidRight);
            }
        }

        Console.Write(Box.BottomLeft);
        for (int i = 0; i < width; i++)
        {
            Console.Write(Box.Horizontal);
            if (i < width - 1) Console.Write(Box.BottomMid);
        }
        Console.WriteLine(Box.BottomRight);

        _turnCounter++;
    }

    private string FormatMoveInfo(Simulation simulation)
    {
        var current = simulation.CurrentMappable; 
        var position = current.CurrentPosition;


        var direction = DirectionParser.FullDirectionName(DirectionParser.Parse(simulation.CurrentMoveName)[0]);

        return $"{current.GetType().Name}: {current.Info} ({position.X},{position.Y}) goes {direction}";
    }
}
