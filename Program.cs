using aspnetcoreapi.Services;

var builder = WebApplication.CreateBuilder(args);

/*
// Build a config object, using env vars and JSON providers.
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables("ASPNETCORE_")
    .Build();
*/

// Add services to the container.
builder.Services.AddScoped<IAppConfig>((provider) => new AppConfig(builder.Configuration));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

Console.WriteLine(new string('-', 80));
foreach (var c in builder.Configuration.AsEnumerable())
{
    Console.WriteLine(c.Key + " = " + c.Value);
}
Console.WriteLine(new string('-', 80));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();