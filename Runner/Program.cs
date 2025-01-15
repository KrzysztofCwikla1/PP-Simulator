using System.Text;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallTorusMap map = new(8, 6);

        List<IMappable> mappables = new()
        {
            new Orc("Gorbag"),
            new Elf("Elandor"),
            new Animals { Description = "Rabbits", Size = 5 },
            new Birds { Description = "Eagles", CanFly = true, Size = 5 },
            new Birds { Description = "Ostriches", CanFly = false, Size = 3 }
        };

        List<Point> positions = new()
        {
            new(2, 2),
            new(3, 1),
            new(3, 3),
            new(4, 4),
            new(5, 5)  
        };

        string moves = "dlrludllurdlurrr";

        Simulation simulation = new(map, mappables, positions, moves);
        SimulationHistory history = new(simulation);

        LogVisualizer logVisualizer = new(history);

        for (int i = 0; i < history.TurnLogs.Count; i++)
        {
            logVisualizer.Draw(i);
            Console.WriteLine("\nPress any key to proceed to the next turn...");
            Console.ReadKey();
        }

        Console.WriteLine("Visualization complete. Press any key to exit.");
        Console.ReadKey();
    }
}
