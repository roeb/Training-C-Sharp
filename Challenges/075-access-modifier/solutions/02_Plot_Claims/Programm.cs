class Program
{
    static void Main(string[] args)
    {
        var plot = new Plot(new Coord(1, 1), new Coord(2, 1), new Coord(1, 2), new Coord(2, 2));

        Console.ReadKey();
    }
}


public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }
    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot
{
    private const int PlotCoordinateCount = 4;
    private Coord[] Points { get; } = new Coord[PlotCoordinateCount];
    public Plot(Coord a, Coord b, Coord c, Coord d)
    {
        Points[0] = a;
        Points[1] = b;
        Points[2] = c;
        Points[3] = d;
    }
}