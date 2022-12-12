namespace aspnetcoreapi.Services;

public interface IAppConfig
{
    Settings Settings { get; }
    IConfiguration Configuration { get; }
}