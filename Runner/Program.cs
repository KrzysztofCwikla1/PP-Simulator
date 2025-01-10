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

        MapVisualizer mapVisualizer = new(simulation.Map);

        while (!simulation.Finished)
        {
            mapVisualizer.Draw(simulation);

            Console.WriteLine("\nPress any key to proceed to the next step...");
            Console.ReadKey();

            try
            {
                simulation.Turn();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during simulation: {ex.Message}");
                break;
            }
        }

        mapVisualizer.Draw(simulation);
        Console.WriteLine("\nSimulation finished. Press any key to exit.");
        Console.ReadKey();
    }
}
