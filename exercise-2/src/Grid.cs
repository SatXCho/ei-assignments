using Microsoft.Extensions.Logging;

public class Grid
{
    private int width;
    private int height;
    private List<(int x, int y)> obstacles;
    private static readonly ILogger<Grid> _logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<Grid>();

    public Grid(int width, int height, List<(int, int)> obstacles)
    {
        this.width = width;
        this.height = height;
        this.obstacles = obstacles;
        _logger.LogInformation($"Grid initialized with width {width}, height {height} and {obstacles.Count} obstacles.");
    }

    public bool IsPositionValid(int x, int y)
    {
        if (x < 0 || x >= width || y < 0 || y >= height)
            return false;

        return !obstacles.Contains((x, y));
    }

    public string GetInvalidReason(int x, int y)
    {
        if (x < 0 || x >= width || y < 0 || y >= height)
            return "Out of bounds";

        if (obstacles.Contains((x, y)))
            return "Obstacle present";

        return "Position is valid";
    }
}