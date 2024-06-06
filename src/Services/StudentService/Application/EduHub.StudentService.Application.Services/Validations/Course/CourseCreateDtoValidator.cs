using EduHub.StudentService.Application.Services.Dto.Course;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Course;

/// <summary>
/// Вадитаор на CourseCreateDto
/// </summary>
public class CourseCreateDtoValidator : AbstractValidator<CourseCreateDto>
{
    public CourseCreateDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .Name();
        
        RuleFor(dto => dto.EducatorId)
            .Id();
    }
}
