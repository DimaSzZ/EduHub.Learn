using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Educator;
using EduHub.StudentService.Domain.Entities;
using EduHub.StudentService.Domain.ValueObjects;

namespace EduHub.StudentService.Application.Services.Mapping
{
    /// <summary>
    /// Компонент автомаппера 
    /// </summary>
    public class EducatorMappingProfile : Profile
    {
        /// <summary>
        /// EducatorCreateDto в Educator
        /// EducatorUpdateDto в Educator
        /// Educator в EducatorResponseDto 
        /// </summary>
        public EducatorMappingProfile()
        {
            CreateMap<EducatorUpsertDto, Educator>()
                .ConstructUsing(dto =>
                    new Educator(
                        Guid.NewGuid(),
                        new FullName(dto.FirstName, dto.Surname, dto.Patronymic),
                        dto.Gender,
                        new Phone(dto.Phone),
                        dto.YearsExperience,
                        dto.DateEmployment
                    ));
            
            CreateMap<Educator, EducatorResponseDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FullName.FirstName))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.FullName.Surname))
                .ForMember(dest => dest.Patronymic, opt => opt.MapFrom(src => src.FullName.Patronymic))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone.Value))
                .ConstructUsing(src => new EducatorResponseDto(
                    src.Id,
                    src.FullName.FirstName,
                    src.FullName.Surname,
                    src.FullName.Patronymic,
                    src.Gender,
                    src.Phone.Value,
                    src.YearsExperience,
                    src.DateEmployment
                ));
        }
    }
}