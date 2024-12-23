﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Elf : Creature
{
    private int agility;

    public int Agility
    {
        get { return agility; }
        set
        {
            agility = Validator.Limiter(value, 0, 10);
        }
    }
    public override void SayHi()
    {
        Console.WriteLine
        ($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");
    }
    public override string Info
    {
        get
        {
            return $"{Name} [{Level}][{Agility}]";
        }
    }

    public int singCounter;
    public void Sing()
    {
        singCounter++;

        if (singCounter % 3 == 0)
        {
            Agility++;
            if (Agility > 10)
                Agility = 10;
        }
        Console.WriteLine($"{Name} is singing.");
    }
    public override int Power
    {
        get
        {
            return (8 * Level) + (2 * Agility);
        }
    }

    public Elf() { }
    public Elf(string name, int level = 1, int agility = 1)
    {
        Name = name;
        Level = level;
        Agility = agility;
    }
}
