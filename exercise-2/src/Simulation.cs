using Microsoft.Extensions.Logging;

class SimulationManager
{
    private Grid? _grid;
    private Rover? _rover;
    private readonly ILogger _logger;

    public SimulationManager(ILogger logger)
    {
        _logger = logger;
    }

    public void Run()
    {
        DisplayWelcomeBanner();

        while (true)
        {
            string? input = Console.ReadLine();
            if (input == null) continue;

            string[] args = input.Trim().Split(' ');

            if (args.Length == 0) continue;

            string command = args[0].ToLower();

            try
            {
                switch (command)
                {
                    case "init":
                        InitializeSimulation(args.Skip(1).ToArray());
                        break;
                    case "command":
                        ExecuteCommands(args.Skip(1).ToArray());
                        break;
                    case "status":
                        DisplayStatus();
                        break;
                    case "help":
                        DisplayHelp();
                        break;
                    case "exit":
                        Console.WriteLine("Exiting the simulation. Goodbye!");
                        return;
                    default:
                        _logger.LogWarning("Invalid command. Type 'help' for available commands.");
                        break;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
            }
        }
    }

    private void DisplayWelcomeBanner()
    {
        Console.WriteLine(@"
 ____                        ____  _                 _       _             
|  _ \ _____   _____ _ __   / ___|(_)_ __ ___  _   _| | __ _| |_ ___  _ __ 
| |_) / _ \ \ / / _ \ '__| \___ \| | '_ ` _ \| | | | |/ _` | __/ _ \| '__|
|  _ < (_) \ V /  __/ |     ___) | | | | | | | |_| | | (_| | || (_) | |   
|_| \_\___/ \_/ \___|_|    |____/|_|_| |_| |_|\__,_|_|\__,_|\__\___/|_|   
                                                                          
Welcome to the Rover Simulation!
Type 'help' for available commands.
");
    }

    private void DisplayHelp()
    {
        Console.WriteLine(@"
Available commands:
  init <gridSize> <roverPosition> <obstacles>   Initialize the simulation
    e.g., init 10x10 2,2,N (2,2),(3,5)
  command <movements>                          Execute rover movements
    e.g., command m l r m m l r
  status                                       Display rover's current status
  help                                         Display this help message
  exit                                         Exit the simulation
");
    }

    private void InitializeSimulation(string[] args)
    {
        if (args.Length < 3)
        {
            throw new ArgumentException("Usage: init <gridSize> <roverPosition> <obstacles>");
        }

        string[] gridSize = args[0].Split('x');
        int width = int.Parse(gridSize[0]);
        int height = int.Parse(gridSize[1]);

        string[] roverInfo = args[1].Split(',');
        int x = int.Parse(roverInfo[0]);
        int y = int.Parse(roverInfo[1]);
        IDirection direction = GetDirection(roverInfo[2]);

        List<(int, int)> obstacles = ParseObstacles(args[2]);

        _grid = new Grid(width, height, obstacles);
        _rover = new Rover(x, y, direction);

        _logger.LogInformation("Simulation initialized successfully.");
    }

    private void ExecuteCommands(string[] commands)
    {
        if (_rover == null || _grid == null)
        {
            throw new InvalidOperationException("Simulation not initialized. Use 'init' command first.");
        }

        foreach (string cmd in commands)
        {
            IRoverCommand? command = GetCommand(cmd);
            if (command != null)
            {
                command.Execute(_rover, _grid);
            }
            else
            {
                _logger.LogWarning($"Invalid command: {cmd}");
            }
        }

        _logger.LogInformation("Commands executed.");
    }

    private void DisplayStatus()
    {
        if (_rover == null)
        {
            throw new InvalidOperationException("Simulation not initialized. Use 'init' command first.");
        }
        _logger.LogInformation(_rover.ReportStatus());
    }

    private IDirection GetDirection(string dir)
    {
        return dir.ToUpper() switch
        {
            "N" => new North(),
            "E" => new East(),
            "S" => new South(),
            "W" => new West(),
            _ => throw new ArgumentException("Invalid direction")
        };
    }

    private List<(int, int)> ParseObstacles(string input)
    {
        List<(int, int)> obstacles = new List<(int, int)>();
        string[] obstaclePairs = input.Trim('(', ')').Split("),(");

        foreach (string pair in obstaclePairs)
        {
            string[] coords = pair.Split(',');
            obstacles.Add((int.Parse(coords[0]), int.Parse(coords[1])));
        }

        return obstacles;
    }

    private IRoverCommand? GetCommand(string cmd)
    {
        return cmd.ToLower() switch
        {
            "m" => new MoveCommand(),
            "l" => new TurnLeftCommand(),
            "r" => new TurnRightCommand(),
            _ => null
        };
    }
}
