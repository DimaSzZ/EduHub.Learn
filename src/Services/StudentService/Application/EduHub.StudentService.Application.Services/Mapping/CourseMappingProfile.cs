using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Course;

namespace EduHub.StudentService.Application.Services.Mapping
{
    /// <summary>
    /// Компонент автомаппера 
    /// </summary>
    public class CourseMappingProfile : Profile
    {
        /// <summary>
        /// CourseCreateDto в Course
        /// CourseUpdateDto в Course
        /// Course в CourseResponseDto
        /// </summary>
        public CourseMappingProfile()
        {
            CreateMap<CourseCreateDto, Domain.Entities.Course>()
                .ConstructUsing(dto =>
                    new Domain.Entities.Course(
                        Guid.NewGuid(),
                        dto.Name,
                        dto.Description,
                        dto.EducatorId
                    ));
            
            CreateMap<CourseUpdateDto, Domain.Entities.Course>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.EducatorId, opt => opt.MapFrom(src => src.EducatorId));
            
            CreateMap<Domain.Entities.Course, CourseResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.EducatorId, opt => opt.MapFrom(src => src.EducatorId));
        }
    }
}