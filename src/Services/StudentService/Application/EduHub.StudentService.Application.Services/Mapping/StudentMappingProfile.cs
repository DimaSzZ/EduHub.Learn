using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Student;
using EduHub.StudentService.Domain.Entities;
using EduHub.StudentService.Domain.ValueObjects;

namespace EduHub.StudentService.Application.Services.Mapping
{
    /// <summary>
    /// Компонент автомаппера
    /// </summary>
    public class StudentMappingProfile : Profile
    {
        /// <summary>
        /// StudentCreateDto в Student
        /// StudentUpdateDto в Student
        /// Student в StudentResponseDto
        /// </summary>
        public StudentMappingProfile()
        {
            CreateMap<StudentCreateDto, Student>()
                .ConstructUsing(src => new Student(
                    Guid.NewGuid(),
                    src.Avatar,
                    new FullName(src.FirstName, src.Surname, src.Patronymic),
                    src.Gender,
                    src.DateBirth,
                    new Email(src.Email),
                    new Phone(src.Phone),
                    new Address(src.City, src.Street, src.NumberHouse)
                ));
            
            CreateMap<StudentUpdateDto, Student>()
                .ConstructUsing(src => new Student(
                    src.Id,
                    src.Avatar,
                    new FullName(src.FirstName, src.Surname, src.Patronymic),
                    src.Gender,
                    src.DateBirth,
                    new Email(src.Email),
                    new Phone(src.Phone),
                    new Address(src.City, src.Street, src.NumberHouse)
                ));
            
            CreateMap<Student, StudentResponseDto>()
                .ConstructUsing(src => new StudentResponseDto(
                    src.Id,
                    src.Avatar,
                    src.FullName.FirstName,
                    src.FullName.Surname,
                    src.FullName.Patronymic,
                    src.Gender,
                    src.DateBirth,
                    src.Email.Value,
                    src.Phone.Value,
                    src.Address.City,
                    src.Address.Street,
                    src.Address.NumberHouse
                ));
        }
    }
}