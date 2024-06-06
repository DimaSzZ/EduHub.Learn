using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Educator;
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
            CreateMap<EducatorCreateDto, Domain.Entities.Educator>()
                .ConstructUsing(dto =>
                    new Domain.Entities.Educator(
                        Guid.NewGuid(),
                        new FullName(dto.FirstName, dto.Surname, dto.Patronymic),
                        dto.Gender,
                        new Phone(dto.Phone),
                        dto.WorkExperience,
                        dto.DateEmployment
                    ));
            
            CreateMap<EducatorUpdateDto, Domain.Entities.Educator>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => new FullName(src.FirstName, src.Surname, src.Patronymic)))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => new Phone(src.Phone)))
                .ForMember(dest => dest.YearsExperience, opt => opt.MapFrom(src => src.WorkExperience))
                .ForMember(dest => dest.DateEmployment, opt => opt.MapFrom(src => src.DateEmployment));
            
            CreateMap<Domain.Entities.Educator, EducatorResponseDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FullName.FirstName))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.FullName.Surname))
                .ForMember(dest => dest.Patronymic, opt => opt.MapFrom(src => src.FullName.Patronymic))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone.Value))
                .ForMember(dest => dest.WorkExperience, opt => opt.MapFrom(src => src.YearsExperience))
                .ForMember(dest => dest.DateEmployment, opt => opt.MapFrom(src => src.DateEmployment));
        }
    }
}