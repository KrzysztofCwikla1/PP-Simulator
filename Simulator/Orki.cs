namespace Simulator;

public class Orc : Creature
{
    private int rage;
    public int Rage
    { 
        get { return rage; }
        set
        {
            rage = Validator.Limiter(value, 0, 10);
        }
    }
    public override string Greeting()
    {
        string message = $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.";
        return message;             
    }
    public override string Info
    {
        get
        {
            return $"{Name} [{Level}][{Rage}]";
        }
    }
    public override char Symbol => 'O';
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
