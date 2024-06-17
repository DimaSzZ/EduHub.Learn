using EduHub.StudentService.Domain.Entities;
using EduHub.StudentService.Domain.Entities.Enums;
using EduHub.StudentService.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EduHub.StudentService.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new EducatorConfiguration());
        builder.ApplyConfiguration(new CourseConfiguration());
        builder.ApplyConfiguration(new StudentConfiguration());
        builder.ApplyConfiguration(new EnrollmentConfiguration());
        builder.HasPostgresEnum<Gender>();
    }
    
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Educator> Educators { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
}