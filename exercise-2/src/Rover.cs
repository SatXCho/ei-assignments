using Microsoft.Extensions.Logging;

public class Rover
{
    private int x;
    private int y;
    private IDirection direction;
    private static readonly ILogger<Rover> _logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<Rover>();

    public Rover(int startX, int startY, IDirection startDirection)
    {
        x = startX;
        y = startY;
        direction = startDirection;
        _logger.LogInformation($"Rover initialized at ({x}, {y}) facing {direction.Name}.");
    }

    public void TurnLeft()
    {
        direction = direction.TurnLeft();
        _logger.LogInformation($"Rover turned left, now facing {direction.Name}.");
    }

    public void TurnRight()
    {
        direction = direction.TurnRight();
        _logger.LogInformation($"Rover turned right, now facing {direction.Name}.");
    }

    public void Move(Grid grid)
    {
        var (newX, newY) = direction.MoveForward(x, y);

        if (grid.IsPositionValid(newX, newY))
        {
            x = newX;
            y = newY;
            _logger.LogInformation($"Rover moved to ({x}, {y}).");
        }
        else
        {
            var reason = grid.GetInvalidReason(newX, newY);
            _logger.LogWarning($"Move failed: {reason} at ({newX}, {newY}). Rover remains at ({x}, {y}).");
        }
    }

    public string ReportStatus()
    {
        return $"Rover is at ({x}, {y}) facing {direction.Name}.";
    }
}