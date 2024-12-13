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
        init 
        {
            name = Validator.Shortener(value, 3, 25, '#');
              
        }
    }
    private int level=1;
    public int Level
    {
        get { return level; }
        set 
        {
            level = Validator.Limiter(value, 1, 10);
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
    public abstract string Info { get; }
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
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}
