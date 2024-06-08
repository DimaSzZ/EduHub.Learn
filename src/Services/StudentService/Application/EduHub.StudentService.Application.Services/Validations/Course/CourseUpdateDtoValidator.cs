using EduHub.StudentService.Application.Services.Dto.Course;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Course;

/// <summary>
/// Валидатор на CourseUpdateDto
/// </summary>
public class CourseUpdateDtoValidator : AbstractValidator<CourseUpdateDto>
{
    public CourseUpdateDtoValidator()
    {
        RuleFor(dto => dto.Id)
            .Id(nameof(CourseUpdateDto.Id));
        
        RuleFor(dto => dto.Name)
            .Name(nameof(CourseUpdateDto.Name));
        
        RuleFor(dto => dto.EducatorId)
            .Id(nameof(CourseUpdateDto.EducatorId));
    }
}