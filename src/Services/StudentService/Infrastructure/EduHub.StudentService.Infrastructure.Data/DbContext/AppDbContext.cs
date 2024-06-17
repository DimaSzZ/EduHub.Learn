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
    
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Educator> Educators { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    
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
        builder.HasPostgresEnum<Gender>();
    }
}