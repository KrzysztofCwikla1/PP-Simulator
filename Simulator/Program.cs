namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab5a();
        //Lab5b();
        Console.ReadKey();
    }
    static void Lab4a()
    {
        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        o.SayHi();
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            o.SayHi();
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        e.SayHi();
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            e.SayHi();
        }

        Console.WriteLine("\nPOWER TEST\n");
        Creature[] creatures = {
        o,
        e,
        new Orc("Morgash", 3, 8),
        new Elf("Elandor", 5, 3)
    };
        foreach (Creature creature in creatures)
        {
            Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
        }

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
        try { 
            var rect3 = new Rectangle(5, 5, 5, 5); 
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Exception caught: {ex.Message}");
        }
    }

}
