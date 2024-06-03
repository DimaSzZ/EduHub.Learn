using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Course;

namespace EduHub.StudentService.Application.Services.Mapping.Course
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<CourseRequestDto, Domain.Entities.Course>()
                .ConstructUsing(dto =>
                    new Domain.Entities.Course(
                        Guid.NewGuid(),
                        dto.Name,
                        dto.Description,
                        dto.EducatorId
                    ));
            
            CreateMap<CourseRequestUpdateDto, Domain.Entities.Course>().ReverseMap();
            
            CreateMap<Domain.Entities.Course, CourseResponseDto>().ReverseMap();
        }
    }
}