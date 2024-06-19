using EduHub.StudentService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduHub.StudentService.Infrastructure.Data.Configuration;

/// <summary>
/// Конфигурация для Enrollment
/// </summary>
public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnName("id");
        
        builder.HasOne<Student>()
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId)
            .IsRequired();
        
        builder.Property(e => e.StudentId)
            .HasColumnName("student_id");
        
        builder.HasOne<Course>()
            .WithOne()
            .HasForeignKey<Enrollment>(e => e.CourseId)
            .IsRequired();
        
        builder.Property(e => e.CourseId)
            .HasColumnName("course_id");
        
        builder.Property(e => e.EnrollmentDate)
            .HasColumnName("enrollment_date")
            .IsRequired()
            .HasColumnType("date");
    }
}