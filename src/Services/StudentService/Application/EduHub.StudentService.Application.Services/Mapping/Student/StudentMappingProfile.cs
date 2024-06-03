using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Student;
using EduHub.StudentService.Domain.ValueObjects;

namespace EduHub.StudentService.Application.Services.Mapping.Student
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<Domain.Entities.Student, StudentResponseDto>().ReverseMap();
            
            CreateMap<StudentRequestUpdateDto, Domain.Entities.Student>().ReverseMap();
            
            CreateMap<StudentRequestDto, Domain.Entities.Student>()
                .ConstructUsing(src => new Domain.Entities.Student(
                    Guid.NewGuid(),
                    src.Avatar,
                    new FullName(src.FirstName, src.Surname, src.Patronymic),
                    src.Gender,
                    src.DateBirth,
                    new Email(src.Email),
                    new Phone(src.Phone),
                    new Address(src.City, src.Street, src.NumberHouse)
                ))
                .ForPath(dest => dest.FullName.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForPath(dest => dest.FullName.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForPath(dest => dest.FullName.Patronymic, opt => opt.MapFrom(src => src.Patronymic))
                .ForPath(dest => dest.Address.City, opt => opt.MapFrom(src => src.City))
                .ForPath(dest => dest.Address.Street, opt => opt.MapFrom(src => src.Street))
                .ForPath(dest => dest.Address.NumberHouse, opt => opt.MapFrom(src => src.NumberHouse));
        }
    }
}