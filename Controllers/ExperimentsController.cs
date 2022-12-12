using System.Text.Json;
using aspnetcoreapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcoreapi.Controllers;

[ApiController]
[Route("[controller]")]
public class ExperimentsController : ControllerBase
{
    IAppConfig _appConfig;

    public ExperimentsController(IAppConfig appConfig)
    {
        _appConfig = appConfig;
    }

    [HttpGet("[action]")]
    public string Hello() => "Hello, World!";

    [HttpGet("[action]")]
    public Settings GetSettings() => _appConfig.Settings;

    [HttpGet("[action]")]
    public object? GetEnvironment() => null;

    [HttpGet("[action]")]
    public object? Tap()
    {
        LogConfiguration<IDictionary<string, IDictionary<string, string>>>("Logging");
        LogConfiguration<Settings>("Settings");
        LogEnvironment("ASPNETCORE_ENVIRONMENT");
        LogEnvironment("ASPNETCORE_X");
        LogEnvironment("ASPNETCORE_K");
        return null;
    }

    private void LogConfiguration<T>(string name)
    {
        var value = _appConfig.Configuration.GetRequiredSection(name).Get<T>();
        var json = JsonSerializer.Serialize(value);
        Console.WriteLine($"{name}: {json}");
    }

    private static void LogEnvironment(string name)
    {
        var value = GetEnvironmentVariable(name);
        Console.WriteLine($"{name}: {value}");
    }

    private static string? GetEnvironmentVariable(string name)
    {
        var value = Environment.GetEnvironmentVariable(name);
        return value;
    }
}