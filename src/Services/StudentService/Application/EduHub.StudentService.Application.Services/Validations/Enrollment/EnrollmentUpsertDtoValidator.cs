using EduHub.StudentService.Application.Services.Dto.Enrollment;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Enrollment;

/// <summary>
/// Валидатор на EnrollmentCreateDto
/// </summary>
public class EnrollmentUpsertDtoValidator : AbstractValidator<EnrollmentUpsertDto>
{
    public EnrollmentUpsertDtoValidator()
    {
        RuleFor(dto => dto.CourseId)
            .Id(nameof(EnrollmentUpsertDto.CourseId));
        
        RuleFor(dto => dto.StudentId)
            .Id(nameof(EnrollmentUpsertDto.StudentId));
        
        RuleFor(dto => dto.EnrollmentDate)
            .Date(nameof(EnrollmentUpsertDto.EnrollmentDate));
    }
}