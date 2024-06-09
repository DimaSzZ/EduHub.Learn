using EduHub.StudentService.Application.Services.Dto.Course;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Course;

/// <summary>
/// Валидатор на CourseCreateDto
/// </summary>
public class CourseCreateDtoValidator : AbstractValidator<CourseCreateDto>
{
    public CourseCreateDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .Name(nameof(CourseCreateDto.Name));
        
        RuleFor(dto => dto.EducatorId)
            .Id(nameof(CourseCreateDto.EducatorId));
    }
}
