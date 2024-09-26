public class Grid
{
    private int width;
    private int height;
    private List<(int x, int y)> obstacles;

    public Grid(int width, int height, List<(int, int)> obstacles)
    {
        this.width = width;
        this.height = height;
        this.obstacles = obstacles;
    }

    public bool IsPositionValid(int x, int y)
    {
        // Check if within bounds
        if (x < 0 || x >= width || y < 0 || y >= height)
            return false;

        // Check if obstacle is present
        return !obstacles.Contains((x, y));
    }
}
