using EduHub.StudentService.Application.Services.Dto.Enrollment;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Enrollment;

/// <summary>
/// Валидатор на EnrollmentUpdateDto
/// </summary>
public class EnrollmentUpdateDtoValidator : AbstractValidator<EnrollmentUpdateDto>
{
    public EnrollmentUpdateDtoValidator()
    {
        RuleFor(dto => dto.Id)
            .Id(nameof(EnrollmentUpdateDto.Id));
        
        RuleFor(dto => dto.CourseId)
            .Id(nameof(EnrollmentUpdateDto.CourseId));
        
        RuleFor(dto => dto.StudentId)
            .Id(nameof(EnrollmentUpdateDto.StudentId));
        
        RuleFor(dto => dto.EnrollmentDate)
            .Date(nameof(EnrollmentUpdateDto.EnrollmentDate));
    }
}