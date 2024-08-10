using Microsoft.Extensions.Configuration;

namespace EduHub.StudentService.Shared.Config;

public static class ConfigHelper
{
    public static IConfiguration LoadConfiguration()
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{environmentName}.json", true, true)
            .AddEnvironmentVariables()
            .Build();
        
        return configuration;
    }
}