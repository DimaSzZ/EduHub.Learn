using EduHub.StudentService.Domain.Entities;
using EduHub.StudentService.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduHub.StudentService.Infrastructure.Data.Configuration
{
    /// <summary>
    /// Конфигурация для Student
    /// </summary>
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .HasColumnName("id");
            
            builder.Property(s => s.Gender)
                .HasDefaultValue(Gender.Default)
                .HasColumnName("gender");
            
            builder.OwnsOne(s => s.FullName, fullName =>
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
            
            builder.OwnsOne(s => s.Phone, phone =>
            {
                phone.Property(p => p.Value)
                    .HasMaxLength(8)
                    .HasColumnName("phone");
                
                phone.HasIndex(p => p.Value)
                    .IsUnique();
            });
            
            builder.Property(s => s.Avatar)
                .HasColumnName("avatar");
            
            builder.OwnsOne(s => s.Email, email =>
            {
                email.Property(e => e.Value)
                    .HasColumnName("email")
                    .HasMaxLength(255);
                
                email.HasIndex(e => e.Value)
                    .IsUnique();
            });
            builder.OwnsOne(s => s.Address, address =>
            {
                address.Property(a => a.City)
                    .HasColumnName("city")
                    .HasMaxLength(100);
                
                address.Property(a => a.Street)
                    .HasColumnName("street")
                    .HasMaxLength(100);
                
                address.Property(a => a.NumberHouse)
                    .HasColumnName("number_house");
            });
            
            builder.Property(s => s.DateBirth)
                .HasColumnName("date_birth")
                .HasColumnType("date");
        }
    }
}