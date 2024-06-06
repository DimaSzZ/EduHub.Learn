using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Enrollment;

namespace EduHub.StudentService.Application.Services.Mapping
{
    /// <summary>
    /// Компонент автомаппера
    /// </summary>
    public class EnrollmentMappingProfile : Profile
    {
        /// <summary>
        /// EnrollmentCreateDto в Enrollment
        /// EnrollmentUpdateDto в Enrollment
        /// Enrollment в EnrollmentResponseDto
        /// </summary>
        public EnrollmentMappingProfile()
        {
            CreateMap<EnrollmentCreateDto, Domain.Entities.Enrollment>()
                .ConstructUsing(dto =>
                    new Domain.Entities.Enrollment(
                        Guid.NewGuid(),
                        dto.EnrollmentDate,
                        dto.StudentId,
                        dto.CourseId
                    ));
            
            CreateMap<EnrollmentUpdateDto, Domain.Entities.Enrollment>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.EnrollmentDate, opt => opt.MapFrom(src => src.EnrollmentDate))
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId));
            
            CreateMap<Domain.Entities.Enrollment, EnrollmentResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.EnrollmentDate, opt => opt.MapFrom(src => src.EnrollmentDate))
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId));
        }
    }
}