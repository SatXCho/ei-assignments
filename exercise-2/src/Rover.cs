public class Rover
{
    private int x;
    private int y;
    private IDirection direction;

    public Rover(int startX, int startY, IDirection startDirection)
    {
        x = startX;
        y = startY;
        direction = startDirection;
    }

    public void TurnLeft() => direction = direction.TurnLeft();
    public void TurnRight() => direction = direction.TurnRight();

    public void Move(Grid grid)
    {
        var (newX, newY) = direction.MoveForward(x, y);
        if (grid.IsPositionValid(newX, newY))
        {
            x = newX;
            y = newY;
        }
        else
        {
            Console.WriteLine($"Obstacle detected at ({newX}, {newY}). Can't move forward.");
        }
    }

    public string ReportStatus()
    {
        return $"Rover is at ({x}, {y}) facing {direction.Name}.";
    }
}
