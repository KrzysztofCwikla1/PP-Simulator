using Simulator;
namespace Runner;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        Lab4b();
        Lab5a();
        Lab5b();
        Console.ReadKey();
    }

    static void Lab4b()
    {
        object[] myObjects = {
        new Animals() { Description = "dogs"},
        new Birds { Description = "  eagles ", Size = 10 },
        new Elf("e", 15, -3),
        new Orc("morgash", 6, 4)
    };
        Console.WriteLine("\nMy objects:");
        foreach (var o in myObjects) Console.WriteLine(o);
        /*
            My objects:
            ANIMALS: Dogs <3>
            BIRDS: Eagles (fly+) <10>
            ELF: E## [10][0]
            ORC: Morgash [6][4]
        */
    }
    public static void Lab5a()
    {
        var rect1 = new Rectangle(10, 10, 5, 5);
        var rect2 = new Rectangle(new Point(12, 3), new Point(8, 15));


        Console.WriteLine(rect1);
        Console.WriteLine(rect2);

        var point = new Point(6, 6);
        Console.WriteLine(rect1.Contains(point));
        Console.WriteLine(rect2.Contains(point));
        try
        {
            var rect3 = new Rectangle(5, 5, 5, 5);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Exception caught: {ex.Message}");
        }
    }
    public static void Lab5b()
    {
        var map = new Simulator.Maps.SmallSquareMap(10);

        var point = new Point(3, 3);
        Console.WriteLine(map.Exist(point));
        Console.WriteLine(map.Next(point, Direction.Right)); // (4, 3)
        Console.WriteLine(map.Next(point, Direction.Up)); // (3, 4)
        Console.WriteLine(map.NextDiagonal(point, Direction.Right)); // (4, 2)
        var edgePoint = new Point(9, 9);
        Console.WriteLine(map.Next(edgePoint, Direction.Up)); // (9, 9)
        try { var map2 = new Simulator.Maps.SmallSquareMap(25); }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Exception caught: {ex.Message}");
        }
    }
}
