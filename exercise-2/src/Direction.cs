public interface IDirection
{
    IDirection TurnLeft();
    IDirection TurnRight();
    (int x, int y) MoveForward(int x, int y);
    string Name { get; }
}

public class North : IDirection
{
    public IDirection TurnLeft() => new West();
    public IDirection TurnRight() => new East();
    public (int x, int y) MoveForward(int x, int y) => (x, y + 1);
    public string Name => "N";
}

public class East : IDirection
{
    public IDirection TurnLeft() => new North();
    public IDirection TurnRight() => new South();
    public (int x, int y) MoveForward(int x, int y) => (x + 1, y);
    public string Name => "E";
}

public class South : IDirection
{
    public IDirection TurnLeft() => new East();
    public IDirection TurnRight() => new West();
    public (int x, int y) MoveForward(int x, int y) => (x, y - 1);
    public string Name => "S";
}

public class West : IDirection
{
    public IDirection TurnLeft() => new South();
    public IDirection TurnRight() => new North();
    public (int x, int y) MoveForward(int x, int y) => (x - 1, y);
    public string Name => "W";
}
