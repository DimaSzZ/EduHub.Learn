using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Course;
using EduHub.StudentService.Application.Services.Dto.Educator;
using EduHub.StudentService.Application.Services.Dto.Enrollment;
using EduHub.StudentService.Application.Services.Dto.Student;
using EduHub.StudentService.Domain.Entities;
using EduHub.StudentService.Domain.ValueObjects;

namespace EduHub.StudentService.Application.Services.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EducatorRequestDto, Educator>()
            .ConstructUsing(dto =>
                new Educator(
                    Guid.NewGuid(),
                    new FullName(dto.FirstName, dto.Surname, dto.Patronymic),
                    dto.Gender,
                    new Phone(dto.Phone),
                    dto.WorkExperience,
                    dto.DateEmployment
                ));
        CreateMap<Educator, EducatorResponseDto>();
        
        CreateMap<CourseRequestDto, Course>()
            .ConstructUsing(dto =>
                new Course(
                    Guid.NewGuid(),
                    dto.Name,
                    dto.Description,
                    dto.EducatorId
                ));
        CreateMap<Course, CourseResponseDto>();
        
        CreateMap<EnrollmentRequestDto, Enrollment>()
            .ConstructUsing(dto =>
                new Enrollment(
                    Guid.NewGuid(),
                    dto.EnrollmentDate,
                    dto.StudentId,
                    dto.CourseId
                ));
        CreateMap<Enrollment, EnrollmentResponseDto>();
        
        CreateMap<StudentRequestDto, Student>()
            .ConstructUsing(dto =>
                new Student(
                    Guid.NewGuid(),
                    dto.Avatar,
                    new FullName(dto.FirstName, dto.Surname, dto.Patronymic),
                    dto.Gender,
                    dto.DateBirth,
                    new Email(dto.Email),
                    new Phone(dto.Phone),
                    new Address(dto.City, dto.Street, dto.NumberHouse)
                ));
    }
}