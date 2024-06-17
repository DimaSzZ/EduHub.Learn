using EduHub.StudentService.Domain.Entities;
using EduHub.StudentService.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduHub.StudentService.Infrastructure.Data.Configuration;

/// <summary>
/// Конфигурация для Educator
/// </summary>
public class EducatorConfiguration : IEntityTypeConfiguration<Educator>
{
    public void Configure(EntityTypeBuilder<Educator> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnName("id");
        
        builder.OwnsOne(e => e.FullName, fullName =>
        {
            fullName.Property(f => f.FirstName)
                .HasMaxLength(60)
                .HasColumnName("first_name");
            
            fullName.Property(f => f.Surname)
                .HasMaxLength(60)
                .HasColumnName("surname");
            
            fullName.Property(f => f.Patronymic)
                .HasMaxLength(60)
                .HasColumnName("patronymic");
        });
        
        
        builder.Property(e => e.Gender)
            .HasDefaultValue(Gender.Default)
            .HasColumnName("gender");
        
        builder.OwnsOne(e => e.Phone, phone =>
        {
            phone.Property(p => p.Value)
                .HasMaxLength(8)
                .HasColumnName("phone");
            
            phone.HasIndex(p => p.Value)
                .IsUnique();
        });
        
        builder.Property(e => e.YearsExperience)
            .HasColumnName("years_experience");
        
        builder.Property(e => e.DateEmployment)
            .HasColumnName("date_employment")
            .HasColumnType("date");
    }
}