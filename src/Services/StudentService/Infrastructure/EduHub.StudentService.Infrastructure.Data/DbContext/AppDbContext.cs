using EduHub.StudentService.Domain.Entities;
using EduHub.StudentService.Domain.Entities.Enums;
using EduHub.StudentService.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EduHub.StudentService.Infrastructure.Data.DbContext;

/// <summary>
/// Базовый контекст бд
/// </summary>
public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Student> Students { get; private set; }
    public DbSet<Course> Courses { get; private set; }
    public DbSet<Educator> Educators { get; private set; }
    public DbSet<Enrollment> Enrollments { get; private set; }
    
    /// <summary>
    /// Применение конфигурация и регистрация enum
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new EducatorConfiguration());
        builder.ApplyConfiguration(new CourseConfiguration());
        builder.ApplyConfiguration(new StudentConfiguration());
        builder.ApplyConfiguration(new EnrollmentConfiguration());
        
        ApplyConfigurationEnums(builder);
    }
    
    /// <summary>
    /// Установка конфигурации для enum'ов
    /// </summary>
    /// <param name="modelBuilder">Апи для конфигурации</param>
    private static void ApplyConfigurationEnums(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<Gender>();
    }
}