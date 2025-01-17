namespace Simulator.Maps;

public interface IMappable
{
    string Name { get; }
    int Level { get; }
    
    Map? CurrentMap { get; set; }

    void AssignMap(Map map, Point startPosition);
    string Go(Direction direction);
    string Info { get; }
    public char Symbol { get; } // umowny symbol obiektu
    Point CurrentPosition { get; set; }

    public string ToString();
    // sugerujemy override, bo object.ToString() zwraca string?
}

