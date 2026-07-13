namespace MarsRover;

public class Rover
{
    private Coordinate _position;
    private Direction _direction = Direction.North;
    private readonly Map _map;
    
    public Rover(Map map)
    {
        _map = map;

        if (_map.HasObstacle(_position))
        {
            throw new InvalidOperationException("Rover cannot start on an obstacle.");
        }
    }

    public string GetPosition() => $"{_position.X}:{_position.Y}:{_direction.ToString()[..1]}";

    public ExecutionResult Execute(string commands)
    {
        ArgumentNullException.ThrowIfNull(commands);
        
        foreach (var command in commands)
        {
            var result = Execute(command);
            if (result.ObstaclesEncountered)
            {
                return result;
            }
        }

        return ExecutionResult.Success();
    }
    
    public ExecutionResult Execute(char command)
    {
       
        return command switch
        {
            'f' => TryMove(1),
            'b' => TryMove(-1),
            'r' => TurnRight(),
            'l' => TurnLeft(),
            _ => throw new InvalidOperationException($"Unknown command '{command}'.")
        };
    }

    private ExecutionResult TurnLeft()
    {
        if (_direction == Direction.North)
        {
            _direction = Direction.West;
        }
        else
        {
            _direction--;
        }

        return ExecutionResult.Success();
    }

    private ExecutionResult TurnRight()
    {
        if (_direction == Direction.West)
        {
            _direction = Direction.North;
        }
        else
        {
            _direction++;
        }
        
        return ExecutionResult.Success();
    }

    private ExecutionResult TryMove(int stepsForward)
    {
        var vector = GetMovementVector(_direction);

        var nextPosition = _position + (vector * stepsForward);

        nextPosition = _map.Wrap(nextPosition);

        if (_map.HasObstacle(nextPosition))
        {
            return ExecutionResult.BlockedBy(nextPosition);
        }

        _position = nextPosition;

        return ExecutionResult.Success();
    }

    private static Coordinate GetMovementVector(Direction direction = Direction.North)
    {
        return direction switch
        {
            Direction.North => new Coordinate(0, 1),
            Direction.East => new Coordinate(1, 0),
            Direction.South => new Coordinate(0, -1),
            Direction.West => new Coordinate(-1, 0),
            _ => throw new InvalidOperationException($"Unknown direction '{direction}.")
        };
    }
}

