using System.ComponentModel;
using MarsRover;

namespace MarsRover.Tests;

public class _roverTests
{
    private Map _map;
    private Rover _rover;

    public _roverTests()
    {
        // Given _rover is initialized with default location
        _map = new Map (6,6);
        _rover = new Rover(_map);
    }
    
    [Fact]
    public void _rover_GetPositionForDefault_ShouldReturnDefaultLocation()
    {
        // When ask for current position
        string position = _rover.GetPosition();

        // Then return default location and direction.
        Assert.Equal("0:0:N", position);
    }

    [Fact]
    public void Execute_ReceivesForwardCommand_ShouldMoveForward()
    {
        // When Execute command to go forward
        _rover.Execute('f');
        
        // Then return new position
        Assert.Equal("0:1:N", _rover.GetPosition());
    }
    
    [Fact]
    public void Execute_ReceivesForwardCommandTwiceFromDefaultPosition_ShouldMoveForwardTwice()
    {
        // When Execute command to go forward twice
        _rover.Execute("ff");
        
        // Then return new position
        Assert.Equal("0:2:N", _rover.GetPosition());
    }
    
    [Fact]
    public void Execute_ForwardAndBackFromDefaultPosition_ShouldReturnToStartingPoint()
    {
        // When Execute command to go forward and back
        _rover.Execute("fb");
        
        // Then return to original position
        Assert.Equal("0:0:N", _rover.GetPosition());
    }
    
    [Fact]
    public void Execute_TurnRightFromNorth_ShouldTurnEast()
    {
        // When Execute command to turn right
        _rover.Execute('r');
        
        // Then return new position
        Assert.Equal("0:0:E", _rover.GetPosition());
    }
    
    [Fact]
    public void Execute_TurnLeftFromNorth_ShouldTurnWest()
    {
        // When Execute command to turn left
        _rover.Execute('l');
        
        // Then return new position
        Assert.Equal("0:0:W", _rover.GetPosition());
    }
    
    [Fact]
    public void Execute_TurnRightFromNorthFourTimes_ShouldReturnToNorth()
    {
        // When Execute command to turn left
        _rover.Execute("rrrr");
        
        // Then return new position
        Assert.Equal("0:0:N", _rover.GetPosition());
    }
    
    [Fact]
    public void Execute_TurnLeftFromNorthFourTimes_ShouldReturnToNorth()
    {
        // When Execute command to turn left
        _rover.Execute("llll");
        
        // Then return new position
        Assert.Equal("0:0:N", _rover.GetPosition());
    }
    
    [Fact]
    public void Execute_TurnRightThenForwardFromNorth_ShouldMoveEastOne()
    {
        // When Execute command to turn left
        _rover.Execute("rf");
        
        // Then return new position
        Assert.Equal("1:0:E", _rover.GetPosition());
    }
    
    [Fact]
    public void Execute_TurnRightThenForwardTurnLeftTwiceThenForwardFromNorth_ShouldMoveBackToStartingPoint()
    {
        // When Execute command to turn left
        _rover.Execute("rfllf");
        
        // Then return new position
        Assert.Equal("0:0:W", _rover.GetPosition());
    }
    
    [Fact]
    public void Execute_TurnLeftThenBackwardFromNorth_ShouldMoveEastOne()
    {
        // When Execute command to turn left
        _rover.Execute("lb");
        
        // Then return new position
        Assert.Equal("1:0:W", _rover.GetPosition());
    }
    
    [Fact]
    public void Execute_TurnRightThenBackwardFromNorth_ShouldMoveWestOne()
    {
        // When Execute command to turn left
        _rover.Execute("lbrrb");
        
        // Then return new position
        Assert.Equal("0:0:E", _rover.GetPosition());
    }
    
    [Fact]
    public void Execute_ForwardsSixTimesFromNorth_ShouldWrapBackToStartingPoint()
    {
        // When Execute command to turn left
        _rover.Execute("ffffff");
        
        // Then return new position
        Assert.Equal("0:0:N", _rover.GetPosition());
    }
    
    [Fact]
    public void Execute_TurnRightForwardsSixTimesFromNorth_ShouldWrapBackToStartingPointFacingEast()
    {
        // When Execute command to turn left
        _rover.Execute("rffffff");
        
        // Then return new position
        Assert.Equal("0:0:E", _rover.GetPosition());
    }
    
    [Fact]
    public void Execute_TurnRightTwiceForwardsSixTimesFromNorth_ShouldWrapBackToStartingPointFacingSouth()
    {
        // When Execute command to turn left
        _rover.Execute("rrffffff");
        
        // Then return new position
        Assert.Equal("0:0:S", _rover.GetPosition());
    }
    
    [Fact]
    public void Execute_TurnRightThriceForwardsSixTimesFromNorth_ShouldWrapBackToStartingPointFacingWest()
    {
        // When Execute command to turn left
        _rover.Execute("rrrffffff");
        
        // Then return new position
        Assert.Equal("0:0:W", _rover.GetPosition());
    }
    
    [Fact]
    public void Execute_BackwardsSixTimesFromNorth_ShouldWrapBackToStartingPoint()
    {
        // When Execute command to turn left
        _rover.Execute("ffffff");
        
        // Then return new position
        Assert.Equal("0:0:N", _rover.GetPosition());
    }
    
    [Fact]
    public void Execute_TurnRightBackwardsSixTimesFromNorth_ShouldWrapBackToStartingPointFacingEast()
    {
        // When Execute command to turn left
        _rover.Execute("rbbbbbb");
        
        // Then return new position
        Assert.Equal("0:0:E", _rover.GetPosition());
    }
    
    [Fact]
    public void Execute_TurnRightTwiceBackwardsSixTimesFromNorth_ShouldWrapBackToStartingPointFacingSouth()
    {
        // When Execute command to turn left
        _rover.Execute("rrbbbbbb");
        
        // Then return new position
        Assert.Equal("0:0:S", _rover.GetPosition());
    }
    
    [Fact]
    public void Execute_TurnRightThriceBackwardsSixTimesFromNorth_ShouldWrapBackToStartingPointFacingWest()
    {
        // When Execute command to turn left
        _rover.Execute("rrrbbbbbb");
        
        // Then return new position
        Assert.Equal("0:0:W", _rover.GetPosition());
    }
    [Fact]
    public void Execute_ReceivesForwardCommandWithObstacle_ShouldNotMove()
    {
        var obstacles = new HashSet<Coordinate>();
        obstacles.Add(new Coordinate()
        {
            X = 0,
            Y = 1
        });
        
        var map = new Map(6, 6, obstacles);
        var rover = new Rover(map);
        
        // When Execute command to go forward
        var result = rover.Execute('f');
        
        // Then return new position
        Assert.Equal("0:0:N", rover.GetPosition());
        Assert.True(result.ObstaclesEncountered);
        Assert.Equal(new Coordinate(0,1), result.Obstacle);
    }

    [Fact]
    public void Execute_InvalidCommand_ShouldThrowException()
    {
        // When an unmappped command is called
        // Then it will throw an exception.
        var ex = Assert.Throws<InvalidOperationException>(()=> _rover.Execute('X'));
        Assert.Equal("Unknown command 'X'.", ex.Message);
    }
    
    [Fact]
    public void Execute_InvalidMapHeight_ShouldThrowException()
    { 
        // Given a map with 0 height
        // When the map is instantiated
        // Then it will throw an exception.
        var ex = Assert.Throws<ArgumentOutOfRangeException>((()=> new Map(1, 0)));
        Assert.Equal("height ('0') must be greater than or equal to '1'. (Parameter 'height')\r\nActual value was 0.", ex.Message);
    }
    
    [Fact]
    public void Execute_InvalidMapWidth_ShouldThrowException()
    {
        // Given a map with 0 width
        // When the map is instantiated
        // Then it will throw an exception.
        var ex = Assert.Throws<ArgumentOutOfRangeException>((()=> new Map(0, 1)));
        Assert.Equal("width ('0') must be greater than or equal to '1'. (Parameter 'width')\r\nActual value was 0.", ex.Message);
    }
    
    [Fact]
    public void Execute_OnOneByOneMap_CantLeaveStartingPoint()
    {
        // Given a map of 1x1
        var map = new Map(1, 1);
        var rover = new Rover(map);
        
        // When the rover moves
        rover.Execute('f');
        
        // Then it will stay on the same position.
        Assert.Equal("0:0:N", rover.GetPosition());
    }
    
    [Fact]
    public void Execute_ObstacleOnStartingPoint_ShouldThrowException()
    {
        // Given a map with an obstacle on the starting point
        var obstacles = new HashSet<Coordinate>();
        obstacles.Add(new Coordinate(0, 0));
        var map = new Map(1, 1, obstacles);
        
        // When the Rover class is instantiated
        // Then it will throw an exception.
        var ex = Assert.Throws<InvalidOperationException>(()=> new Rover(map));
        Assert.Equal("Rover cannot start on an obstacle.", ex.Message);
    }
}