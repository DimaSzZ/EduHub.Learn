using EduHub.StudentService.Application.Services.AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Course;
using EduHub.StudentService.Application.Services.Dto.Educator;
using EduHub.StudentService.Application.Services.Dto.Student;
using EduHub.StudentService.Application.Services.Validations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EduHub.StudentService.Application.Services.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddValidators();
        services.AddAutoMapper(typeof(MappingProfile));
        return services;
    }
    
    private static IServiceCollection AddValidators(
        this IServiceCollection services
    )
    {
        services.AddScoped<IValidator<CourseRequestDto>, CourseRequestDtoValidator>();
        services.AddScoped<IValidator<StudentRequestDto>, StudentRequestDtoValidator>();
        services.AddScoped<IValidator<EducatorRequestDto>, EducatorRequestDtoValidator>();
        return services;
    }
}