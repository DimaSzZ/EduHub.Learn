using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Course;
using EduHub.StudentService.Domain.Entities;

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
            CreateMap<CourseCreateDto, Course>()
                .ConstructUsing(dto =>
                    new Course(
                        Guid.NewGuid(),
                        dto.Name,
                        dto.Description,
                        dto.EducatorId
                    ));
            
            CreateMap<CourseUpdateDto, Course>()
                .ConstructUsing(dto =>
                    new Course(
                        dto.Id, 
                        dto.Name,
                        dto.Description,
                        dto.EducatorId
                    ));
            
            CreateMap<Course, CourseResponseDto>();
        }
    }
}