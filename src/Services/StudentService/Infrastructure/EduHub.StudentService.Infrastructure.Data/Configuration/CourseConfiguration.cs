using EduHub.StudentService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduHub.StudentService.Infrastructure.Data.Configuration;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Id)
            .HasColumnName("id");
        
        builder.Property(c => c.Name)
            .HasColumnName("name")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(c => c.Description)
            .HasColumnName("description");
        
        builder.Property(c => c.EducatorId)
            .HasColumnName("educator_id")
            .IsRequired();
        
        builder.HasOne<Educator>()
            .WithMany(e => e.Courses)
            .HasForeignKey(c => c.EducatorId)
            .IsRequired();
    }
}