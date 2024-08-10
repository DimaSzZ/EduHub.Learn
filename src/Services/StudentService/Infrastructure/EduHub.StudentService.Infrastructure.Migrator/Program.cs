using EduHub.StudentService.Infrastructure.Migrator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

public class Program
{
    /// <summary>
    /// Старт мигратора
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        var contextFactory = new DesignTimeDbContextFactory();
        using (var context = contextFactory.CreateDbContext(args))
        {
            var migrator = context.Database.GetService<IMigrator>();
            migrator.Migrate();
            Console.WriteLine("Migration applied successfully.");
            
            var appliedMigrations = context.Database.GetAppliedMigrations();
            Console.WriteLine("Applied migrations:");
            foreach (var migration in appliedMigrations)
            {
                Console.WriteLine($"- {migration}");
            }
        }
    }
}