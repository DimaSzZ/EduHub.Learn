using EduHub.StudentService.Domain.Entities;
using EduHub.StudentService.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace EduHub.StudentService.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasPostgresEnum<Gender>();
    }
    
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Educator> Educators { get; set; } = null!;
    public DbSet<Enrollment> Enrollments { get; set; } = null!;
}