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

        SimulationManager simulationManager = new SimulationManager(logger);
        simulationManager.Run();
    }
}