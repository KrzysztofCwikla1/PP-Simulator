using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Orc : Creature
{
    private int rage;
    public int Rage
    { 
        get { return rage; }
        set
        {
            if (value < 1)
                value = 1;
            else if (value > 10)
                value = 10;
            rage = value;
        }
    }
    public override void SayHi()
    {
        Console.WriteLine
        ($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");
    }
    private int huntCounter;
    public void Hunt()
    {
        huntCounter++;

        if (huntCounter%2==0) 
        {
            Rage++;
            if (Rage > 10)
                Rage = 10;
        }

        Console.WriteLine($"{Name} is hunting.");
    }
    public override int Power
    {
        get
        {
            return (7 * Level) + (3 * Rage);
        }
    }
    public Orc(string name, int level = 1, int rage=1)
    {
        Name = name;
        Level = level;
        Rage = rage;
    }
    public Orc() { }
}
