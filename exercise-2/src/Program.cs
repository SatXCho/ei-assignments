using Microsoft.Extensions.Logging;
class Program
{
    static void Main(string[] args)
    {
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });
        ILogger logger = loggerFactory.CreateLogger<Program>();
        // Initialize Grid with Obstacles
        var obstacles = new List<(int, int)> { (2, 2), (3, 5) };
        Grid grid = new Grid(10, 10, obstacles);
        
        // Initialize Rover at position (0, 0) facing North
        Rover rover = new Rover(0, 0, new North());

        // Define Commands
        List<IRoverCommand> commands = new List<IRoverCommand>
        {
            new MoveCommand(),
            new MoveCommand(),
            new TurnRightCommand(),
            new MoveCommand(),
            new MoveCommand(),
            new TurnLeftCommand(),
            new MoveCommand()
        };

        // Execute Commands
        foreach (var command in commands)
        {
            command.Execute(rover, grid);
        }

        // Final Status Report
        logger.LogInformation(rover.ReportStatus());
    }
}
