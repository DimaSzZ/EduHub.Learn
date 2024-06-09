using EduHub.StudentService.Application.Services.Dto.Enrollment;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Enrollment;

/// <summary>
/// Валидатор на EnrollmentCreateDto
/// </summary>
public class EnrollmentCreateDtoValidator : AbstractValidator<EnrollmentCreateDto>
{
    public EnrollmentCreateDtoValidator()
    {
        RuleFor(dto => dto.CourseId)
            .Id(nameof(EnrollmentCreateDto.CourseId));
        
        RuleFor(dto => dto.StudentId)
            .Id(nameof(EnrollmentCreateDto.StudentId));
        
        RuleFor(dto => dto.EnrollmentDate)
            .Date(nameof(EnrollmentCreateDto.EnrollmentDate));
    }
}