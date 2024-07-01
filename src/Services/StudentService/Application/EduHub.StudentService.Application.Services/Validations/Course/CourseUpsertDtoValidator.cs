using EduHub.StudentService.Application.Services.Dto.Course;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Course;

/// <summary>
/// Валидатор на CourseCreateDto
/// </summary>
public class CourseUpsertDtoValidator : AbstractValidator<CourseUpsertDto>
{
    public CourseUpsertDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .Name(nameof(CourseUpsertDto.Name));
        
        RuleFor(dto => dto.EducatorId)
            .Id(nameof(CourseUpsertDto.EducatorId));
    }
}
