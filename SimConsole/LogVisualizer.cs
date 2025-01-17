using Simulator;

namespace SimConsole;

public class LogVisualizer
{
    private SimulationHistory Log { get; }


    public LogVisualizer(SimulationHistory log)
    {
        Log = log ?? throw new ArgumentNullException(nameof(log));
    }

    public void Draw(int turnIndex)
    {
        if (turnIndex < 0 || turnIndex >= Log.TurnLogs.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(turnIndex), "Invalid turn index.");
        }

        var turnLog = Log.TurnLogs[turnIndex];
        int width = Log.SizeX;
        int height = Log.SizeY;

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
                Point position = new Point(x, y);
                char symbol = turnLog.Symbols.ContainsKey(position) ? turnLog.Symbols[position] : ' ';
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

    }

}
