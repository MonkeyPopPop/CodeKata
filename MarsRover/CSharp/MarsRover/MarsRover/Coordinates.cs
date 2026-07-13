namespace MarsRover;

public readonly record struct Coordinate(int X, int Y)
{
    public static Coordinate operator +(Coordinate left, Coordinate right)
    {
        return new Coordinate(left.X + right.X, left.Y + right.Y);
    }
    
    public static Coordinate operator *(Coordinate coordinate, int scalar)
    {
        return new Coordinate(coordinate.X * scalar, coordinate.Y * scalar);
    }

}
