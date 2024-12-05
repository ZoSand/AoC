using System.Net.Http;

namespace AoC.Common;

public static class Api
{
    private static readonly Dictionary<string, string> Env = new();
    private static bool _loaded = false;

    private static void Load()
    {
        var envFile = File.ReadAllLines(".env");
        foreach (var line in envFile)
        {
            var parts = line.Split('=');
            Env.Add(parts[0], parts.Length > 1 ? parts[1] : "");
        }
        _loaded = true;
    }
    
    public static string GetInput(int year, int day)
    {
        if (!_loaded)
        {
            Load();
        }
        
        string url = $"https://adventofcode.com/{year}/day/{day}/input";
        string session = Env["AOC_SESSION_COOKIE"];
        
        using HttpClient client = new();
        client.DefaultRequestHeaders.Add("Cookie", $"session={session}");

        try
        {
            return client.GetStringAsync(url).Result;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}