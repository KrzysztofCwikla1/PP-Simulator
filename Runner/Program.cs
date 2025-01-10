using System.Text;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallSquareMap map = new(5);
        List<Creature> creatures = new() { new Orc("Gorbag"), new Elf("Elandor") };
        List<Point> positions = new() { new(2, 2), new(3, 1) };
        string moves = "dlrludl";

        Simulation simulation = new(map, creatures, positions, moves);
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
