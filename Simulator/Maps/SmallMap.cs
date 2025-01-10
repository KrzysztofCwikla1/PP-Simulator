namespace Simulator.Maps;

public class SmallMap : Map
{
    // Struktura danych do przechowywania stworów na mapie (słownik z punktem jako kluczem)
    private Dictionary<Point, List<Creature>> _creaturesAtPosition;

    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        _creaturesAtPosition = new Dictionary<Point, List<Creature>>();
        if (sizeX > 20 || sizeY > 20)
            throw new ArgumentOutOfRangeException("SmallMap size can't exceed 20x20.");
    }

    // Implementacja metod mapy:

    // Dodanie stworzenia na mapie
    public override void Add(Creature creature, Point position)
    {
        if (!Exist(position))
            throw new ArgumentOutOfRangeException("Position is outside the map bounds.");

        if (!_creaturesAtPosition.ContainsKey(position))
            _creaturesAtPosition[position] = new List<Creature>();

        _creaturesAtPosition[position].Add(creature);
    }

    // Usunięcie stworzenia z mapy
    public override void Remove(Creature creature, Point position)
    {
        if (_creaturesAtPosition.ContainsKey(position))
        {
            _creaturesAtPosition[position].Remove(creature);
        }
    }

    // Przeniesienie stworzenia z jednej pozycji na drugą
    public override void Move(Creature creature, Point oldPosition, Point newPosition)
    {
        Remove(creature, oldPosition);
        Add(creature, newPosition);
    }

    // Sprawdzanie, jakie stwory są w danym punkcie
    public override List<Creature> At(Point position)
    {
        return _creaturesAtPosition.ContainsKey(position) ? _creaturesAtPosition[position] : new List<Creature>();
    }

    // Sprawdzanie, jakie stwory są w danym punkcie (z parametrami X, Y)
    public List<Creature> At(int x, int y)
    {
        return At(new Point(x, y));
    }

    // Implementacja metod Next i NextDiagonal
    public override Point Next(Point p, Direction d)
    {
        return p.Next(d);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        return p.NextDiagonal(d);
    }
}
