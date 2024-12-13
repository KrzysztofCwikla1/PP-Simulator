using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public abstract class Creature
{
    private string name="Unknown";
    public string Name
    {
        get { return name; }
        init {

            value = value.Trim();

            if (value.Length > 25)
                value = value.Substring(0, 25).TrimEnd();
            if (value.Length < 3)
                value = value.PadRight(3, '#');
            if (char.IsLower(value[0]))
                value = char.ToUpper(value[0]) + value.Substring(1);
            name = value;
        }
    }
    private int level=1;
    public int Level
    {
        get { return level; }
        set 
        {
            if (value < 1)
                value = 1;
            else if (value > 10)
                value = 10;
            level = value;
        }
    }
    public void Upgrade()
    {
        if (Level < 10)
            Level++;
    }
    public Creature(string name, int level=1)
    {
        Name = name;
        Level = level;
    }
    public Creature(){}
    public string Info
    {
        get { return $"{Name} [{Level}]"; }
    }
    public abstract void SayHi();
    public abstract int Power{ get; }
    public void Go(Direction direction)
    {
        Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}.");
    }

    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
            Go(direction);
    }

    public void Go(string input)
    {
        var directions = DirectionParser.Parse(input);
        Go(directions);
    }
}
