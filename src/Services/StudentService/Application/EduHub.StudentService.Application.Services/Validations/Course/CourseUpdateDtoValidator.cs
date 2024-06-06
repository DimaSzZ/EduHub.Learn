using EduHub.StudentService.Application.Services.Dto.Course;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Course;

/// <summary>
/// Вадитаор на CourseUpdateDto
/// </summary>
public class CourseUpdateDtoValidator : AbstractValidator<CourseUpdateDto>
{
    public CourseUpdateDtoValidator()
    {
        RuleFor(dto => dto.Id)
            .Id();
        
        RuleFor(dto => dto.Name)
            .PersonName();
        
        RuleFor(dto => dto.EducatorId)
            .Id();
    }
}