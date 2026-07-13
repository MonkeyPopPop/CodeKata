namespace MarsRover;

public class Map
{
    private int Width { get; } // 0-5 -> 1-6
    private int Height { get; }
    private readonly HashSet<Coordinate> _obstacles;

    public Map(int width, int height, IEnumerable<Coordinate>? obstacles = null)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(width, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(height, 1);

        Width = width;
        Height = height;
        _obstacles = obstacles?.ToHashSet() ?? [];
    }

    public bool HasObstacle(Coordinate position)
    {
        return _obstacles.Contains(position);
    }

    public Coordinate Wrap(Coordinate coordinate)
    {
        if (coordinate.X >= Width)
        {
            coordinate = coordinate with { X = 0 };
        }
        else if (coordinate.X < 0)
        {
            coordinate = coordinate with { X = Width - 1 };
        }
        
        if (coordinate.Y >= Height)
        {
            coordinate = coordinate with { Y = 0 };
        }
        
        if (coordinate.Y < 0)
        {
            coordinate = coordinate with { Y = Height - 1 };
        }

        return coordinate;
    }
}