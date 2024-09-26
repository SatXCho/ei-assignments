
public interface IRoverCommand
{
    void Execute(Rover rover, Grid grid);
}

public class MoveCommand : IRoverCommand
{
    public void Execute(Rover rover, Grid grid)
    {
        rover.Move(grid);
    }
}

public class TurnLeftCommand : IRoverCommand
{
    public void Execute(Rover rover, Grid grid)
    {
        rover.TurnLeft();
    }
}

public class TurnRightCommand : IRoverCommand
{
    public void Execute(Rover rover, Grid grid)
    {
        rover.TurnRight();
    }
}
