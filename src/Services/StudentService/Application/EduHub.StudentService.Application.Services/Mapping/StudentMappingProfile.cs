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
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FullName.FirstName))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.FullName.Surname))
                .ForMember(dest => dest.Patronymic, opt => opt.MapFrom(src => src.FullName.Patronymic))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone.Value))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(dest => dest.NumberHouse, opt => opt.MapFrom(src => src.Address.NumberHouse));
        }
    }
}
