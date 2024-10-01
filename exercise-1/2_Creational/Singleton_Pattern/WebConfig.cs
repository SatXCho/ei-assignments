using System;

public class ConfigurationManager
{
    private static ConfigurationManager _instance;
    private static readonly object lockObject = new object();
    private string configData;

    // un-instantiation
    private ConfigurationManager()
    {
        configData = "Database Connection String: Server=localhost;User=admin;Password=pass123;";
    }

    public static ConfigurationManager GetInstance()
    {
        if (_instance == null)
        {
            lock (lockObject)
            {
                if (_instance == null)
                {
                    _instance = new ConfigurationManager();
                }
            }
        }
        return _instance;
    }

    public string GetConfigurationData()
    {
        return configData;
    }
}

class Program
{
    static void Main()
    {
        ConfigurationManager configManager1 = ConfigurationManager.GetInstance();
        Console.WriteLine(configManager1.GetConfigurationData());

        ConfigurationManager configManager2 = ConfigurationManager.GetInstance();
        Console.WriteLine(ReferenceEquals(configManager1, configManager2));  // True
    }
}
