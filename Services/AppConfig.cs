using System.Text.Json;

namespace aspnetcoreapi.Services;

public class AppConfig : IAppConfig
{
    public Settings Settings { get; private set; }
    public IConfiguration Configuration { get; private set; }

    public AppConfig(IConfiguration configuration)
    {
        Settings = configuration.GetRequiredSection("Settings").Get<Settings>()!;
        Configuration = configuration;
    }
}