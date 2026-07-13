namespace MarsRover;

public readonly record struct ExecutionResult(bool ObstaclesEncountered, Coordinate? Obstacle)
{
    public static ExecutionResult Success()
    {
        return new ExecutionResult(false, null);
    }

    public static ExecutionResult BlockedBy(Coordinate obstacle)
    {
        return new ExecutionResult(true, obstacle);
    }
    
}
    
