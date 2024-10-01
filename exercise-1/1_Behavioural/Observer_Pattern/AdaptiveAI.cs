using System;
using System.Collections.Generic;

public interface IPlayerPerformanceObserver
{
    void Update(PlayerPerformance performance);
}

public class PlayerPerformance
{
    public int Score { get; set; }
    public int Deaths { get; set; }
    public TimeSpan PlayTime { get; set; }
}

public class GameSession
{
    private PlayerPerformance _currentPerformance = new PlayerPerformance();
    private List<IPlayerPerformanceObserver> _observers = new List<IPlayerPerformanceObserver>();

    public void AddObserver(IPlayerPerformanceObserver observer)
    {
        _observers.Add(observer);
    }

    public void UpdatePerformance(int scoreDelta, int deathsDelta, TimeSpan playTimeDelta)
    {
        _currentPerformance.Score += scoreDelta;
        _currentPerformance.Deaths += deathsDelta;
        _currentPerformance.PlayTime += playTimeDelta;
        NotifyObservers();
    }

    private void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_currentPerformance);
        }
    }
}

public class EnemyAI : IPlayerPerformanceObserver
{
    private double _difficultyMultiplier = 1.0;

    public void Update(PlayerPerformance performance)
    {
        double scorePerMinute = performance.Score / (performance.PlayTime.TotalMinutes + 1);
        double deathsPerMinute = performance.Deaths / (performance.PlayTime.TotalMinutes + 1);

        if (scorePerMinute > 100 && deathsPerMinute < 0.5)
        {
            _difficultyMultiplier *= 1.1; // Increase difficulty
        }
        else if (scorePerMinute < 50 || deathsPerMinute > 2)
        {
            _difficultyMultiplier *= 0.9; // Decrease difficulty
        }

        Console.WriteLine($"AI Difficulty adjusted. New multiplier: {_difficultyMultiplier:F2}");
    }
}

public class AchievementSystem : IPlayerPerformanceObserver
{
    public void Update(PlayerPerformance performance)
    {
        if (performance.Score > 1000 && performance.Deaths == 0)
        {
            Console.WriteLine("Achievement Unlocked: Flawless Victory!");
        }
    }
}

public class Program
{
    public static void Main()
    {
        var gameSession = new GameSession();
        var enemyAI = new EnemyAI();
        var achievementSystem = new AchievementSystem();

        gameSession.AddObserver(enemyAI);
        gameSession.AddObserver(achievementSystem);

        gameSession.UpdatePerformance(150, 0, TimeSpan.FromMinutes(5));
        gameSession.UpdatePerformance(300, 1, TimeSpan.FromMinutes(10));
        gameSession.UpdatePerformance(600, 0, TimeSpan.FromMinutes(15));
    }
}