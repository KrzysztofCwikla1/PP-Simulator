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
    public abstract string Greeting();
    public abstract int Power{ get; }
    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";

    public string[] Go(Direction[] directions) => directions.Select(Go).ToArray();


    public string[] Go(string input)
    {
        var directions = DirectionParser.Parse(input);
        return Go(directions); 
    }
    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
}
