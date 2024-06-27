using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Enrollment;
using EduHub.StudentService.Domain.Entities;

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
            CreateMap<EnrollmentUpsertDto, Enrollment>()
                .ConstructUsing(dto =>
                    new Enrollment(
                        Guid.NewGuid(),
                        dto.EnrollmentDate,
                        dto.StudentId,
                        dto.CourseId
                    ));
            
            CreateMap<Enrollment, EnrollmentResponseDto>()
                .ConstructUsing(dto =>
                    new EnrollmentResponseDto(
                        dto.Id,
                        dto.EnrollmentDate,
                        dto.StudentId,
                        dto.CourseId
                    ));
        }
    }
}