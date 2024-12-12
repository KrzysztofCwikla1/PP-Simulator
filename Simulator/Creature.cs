using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Creature
{
    private string name;
    public string Name
    {
        get { return name; }
        init { name = value; }
    }
    private int level;
    public int Level
    {
        get { return level; }
        set { level = value > 0 ? value : 1; }
    }
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }
    public Creature(){}
    public string Info
    {
        get { return $"{Name} [{Level}]"; }
    }
    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }
}
