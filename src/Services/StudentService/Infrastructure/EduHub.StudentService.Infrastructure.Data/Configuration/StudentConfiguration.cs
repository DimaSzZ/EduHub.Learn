using EduHub.StudentService.Domain.Entities;
using EduHub.StudentService.Domain.Entities.Enums;
using EduHub.StudentService.Infrastructure.Data.Constant;
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
            
            builder.OwnsOne(s => s.Phone, phone =>
            {
                phone.Property(p => p.Value)
                    .HasMaxLength(13)
                    .IsRequired()
                    .HasColumnName("phone");
                
                phone.HasIndex(p => p.Value)
                    .HasDatabaseName(IndexNames.PhoneStudent)
                    .IsUnique();
            });
            
            builder.Property(s => s.Avatar)
                .IsRequired()
                .HasColumnName("avatar");
            
            builder.OwnsOne(s => s.Email, email =>
            {
                email.Property(e => e.Value)
                    .HasColumnName("email")
                    .IsRequired()
                    .HasMaxLength(255);
                
                email.HasIndex(e => e.Value)
                    .HasDatabaseName(IndexNames.Email)
                    .IsUnique();
            });
            builder.OwnsOne(s => s.Address, address =>
            {
                address.Property(a => a.City)
                    .HasColumnName("city")
                    .IsRequired()
                    .HasMaxLength(100);
                
                address.Property(a => a.Street)
                    .HasColumnName("street")
                    .IsRequired()
                    .HasMaxLength(100);
                
                address.Property(a => a.NumberHouse)
                    .HasColumnName("number_house")
                    .IsRequired();
            });
            
            builder.Property(s => s.DateBirth)
                .HasColumnName("date_birth")
                .IsRequired()
                .HasColumnType("date");
        }
    }
}