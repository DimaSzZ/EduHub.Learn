using EduHub.StudentService.Domain.Entities;
using EduHub.StudentService.Domain.Entities.Enums;
using EduHub.StudentService.Infrastructure.Data.Constant;
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
                .IsRequired()
                .HasColumnName("first_name");
            
            fullName.Property(f => f.Surname)
                .HasMaxLength(60)
                .IsRequired()
                .HasColumnName("surname");
            
            fullName.Property(f => f.Patronymic)
                .HasMaxLength(60)
                .IsRequired()
                .HasColumnName("patronymic");
        });
        
        
        builder.Property(e => e.Gender)
            .HasDefaultValue(Gender.Default)
            .IsRequired()
            .HasColumnName("gender");
        
        builder.OwnsOne(e => e.Phone, phone =>
        {
            phone.Property(p => p.Value)
                .HasMaxLength(11)
                .IsRequired()
                .HasColumnName("phone");
            
            phone.HasIndex(p => p.Value)
                .HasDatabaseName(IndexNames.PhoneEducator)
                .IsUnique();
        });
        
        builder.Property(e => e.YearsExperience)
            .IsRequired()
            .HasColumnName("years_experience");
        
        builder.Property(e => e.DateEmployment)
            .HasColumnName("date_employment")
            .IsRequired()
            .HasColumnType("date");
    }
}