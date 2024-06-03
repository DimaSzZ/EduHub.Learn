using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Enrollment;

namespace EduHub.StudentService.Application.Services.Mapping.Enrollment
{
    public class EnrollmentMappingProfile : Profile
    {
        public EnrollmentMappingProfile()
        {
            CreateMap<EnrollmentRequestDto, Domain.Entities.Enrollment>()
                .ConstructUsing(dto =>
                    new Domain.Entities.Enrollment(
                        Guid.NewGuid(),
                        dto.EnrollmentDate,
                        dto.StudentId,
                        dto.CourseId
                    ));
            
            CreateMap<EnrollmentRequestUpdateDto, Domain.Entities.Enrollment>().ReverseMap();
            
            CreateMap<Domain.Entities.Enrollment, EnrollmentResponseDto>().ReverseMap();
        }
    }
}