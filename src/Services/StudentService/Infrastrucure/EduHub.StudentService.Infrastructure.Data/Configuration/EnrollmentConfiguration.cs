using EduHub.StudentService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduHub.StudentService.Infrastructure.Data.Configuration;

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnName("id");
        
        builder.HasOne<Student>()
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId);
        
        builder.Property(e => e.StudentId)
            .HasColumnName("student_id");
        
        builder.HasOne<Course>()
            .WithOne()
            .HasForeignKey<Enrollment>(e => e.CourseId);
        
        builder.Property(e => e.CourseId)
            .HasColumnName("course_id");
        
        builder.Property(e => e.EnrollmentDate)
            .HasColumnName("enrollment_date");
    }
}