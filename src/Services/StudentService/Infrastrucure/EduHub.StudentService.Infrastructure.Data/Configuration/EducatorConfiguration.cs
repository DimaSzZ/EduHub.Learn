using EduHub.StudentService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduHub.StudentService.Infrastructure.Data.Configuration;

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
                .IsRequired()
                .HasColumnName("first_name"); 
            
            fullName.Property(f => f.Surname)
                .IsRequired()
                .HasColumnName("surname"); 
            
            fullName.Property(f => f.Patronymic)
                .IsRequired()
                .HasColumnName("patronymic");
        });

        
        builder.Property(e => e.Gender)
            .HasColumnName("gender")
            .IsRequired();
        
        builder.OwnsOne(e => e.Phone, phone =>
        {
            phone.Property(p => p.Value)
                .HasColumnName("phone")
                .IsRequired();
        });
        
        builder.Property(e => e.YearsExperience)
            .HasColumnName("years_experience")
            .IsRequired();
        
        builder.Property(e => e.DateEmployment)
            .HasColumnName("date_employment")
            .IsRequired();
    }
}