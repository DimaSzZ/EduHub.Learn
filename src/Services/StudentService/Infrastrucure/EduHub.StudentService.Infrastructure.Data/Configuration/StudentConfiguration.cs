using EduHub.StudentService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduHub.StudentService.Infrastructure.Data.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .HasColumnName("id")
                .IsRequired();
            
            builder.Property(s => s.Gender)
                .HasColumnName("gender")
                .IsRequired();
            
            builder.OwnsOne(s => s.FullName, fullName =>
            {
                fullName.Property(f => f.FirstName)
                    .HasColumnName("first_name")
                    .IsRequired();
                
                fullName.Property(f => f.Surname)
                    .HasColumnName("surname")
                    .IsRequired();
                
                fullName.Property(f => f.Patronymic)
                    .HasColumnName("patronymic")
                    .IsRequired();
            });
            
            builder.OwnsOne(s => s.Phone, phone =>
            {
                phone.Property(p => p.Value)
                    .HasColumnName("phone")
                    .IsRequired();
            });
            
            builder.Property(s => s.Avatar)
                .HasColumnName("avatar")
                .IsRequired();
            
            builder.OwnsOne(s => s.Email)
                .Property(e => e.Value)
                .HasColumnName("email")
                .IsRequired();
            
            builder.OwnsOne(s => s.Address, address =>
            {
                address.Property(a => a.City)
                    .HasColumnName("city")
                    .IsRequired();
                
                address.Property(a => a.Street)
                    .HasColumnName("street")
                    .IsRequired();
                
                address.Property(a => a.NumberHouse)
                    .HasColumnName("number_house")
                    .IsRequired();
            });
            
            builder.Property(s => s.DateBirth)
                .HasColumnName("date_birth")
                .HasColumnType("date")
                .IsRequired();
        }
    }
}