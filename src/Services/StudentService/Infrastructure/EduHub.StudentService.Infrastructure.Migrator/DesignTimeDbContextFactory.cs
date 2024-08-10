using EduHub.StudentService.Infrastructure.Data.DataSource;
using EduHub.StudentService.Infrastructure.Data.DbContext;
using EduHub.StudentService.Shared.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EduHub.StudentService.Infrastructure.Migrator;

/// <summary>
/// Фабрика по созданию дб контекста
/// </summary>
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var configuration = ConfigHelper.LoadConfiguration();
        
        var builder = new DbContextOptionsBuilder<AppDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var dataSource = EduHubNpgsqlDataSource.Create(connectionString);
        
        var migrationsAssembly = typeof(Program).Assembly.GetName().Name;
        builder.UseNpgsql(dataSource,
            options => options.MigrationsAssembly(migrationsAssembly));
        
        
        return new AppDbContext(builder.Options);
    }
}