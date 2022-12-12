Having a appsettings.json object like:


```json
{
  "Settings": {
    "KeyOne": 1,
    "KeyTwo": true
  }
}
```

You can change this values settings the environment variables, like:

```powershell
$Env:Settings:KeyOne = '100'
$Env:Settings:KeyTwo = 'false'
```

Put this code in your Program.cs file, to see this values:

```cs
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Console.WriteLine(new string('-', 80));
foreach (var c in builder.Configuration.AsEnumerable())
{
    Console.WriteLine(c.Key + " = " + c.Value);
}
Console.WriteLine(new string('-', 80));
```

# References

* [Microsoft - Configuration in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-7.0)
* [Microsoft - Use multiple environments in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-7.0)
* [Github - ASP.NET Program.cs sample](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/fundamentals/configuration/index/samples/6.x/ConfigSample/Program.cs)
* [Anthony Chu - Managing ASP.NET Core App Settings on Kubernetes](https://anthonychu.ca/post/aspnet-core-appsettings-secrets-kubernetes/)
* [Code 4 It - 3 (and more) ways to set configuration values in .NET](https://www.code4it.dev/blog/how-to-set-configurations-values-dotnet)
