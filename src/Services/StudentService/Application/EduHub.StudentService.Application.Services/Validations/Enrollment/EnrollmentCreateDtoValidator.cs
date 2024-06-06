using EduHub.StudentService.Application.Services.Dto.Enrollment;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Enrollment;

/// <summary>
/// Вадитаор на EnrollmentCreateDto
/// </summary>
public class EnrollmentCreateDtoValidator : AbstractValidator<EnrollmentCreateDto>
{
    public EnrollmentCreateDtoValidator()
    {
        RuleFor(dto => dto.CourseId)
            .Id();
        
        RuleFor(dto => dto.StudentId)
            .Id();
        
        RuleFor(dto => dto.EnrollmentDate)
            .Date();
    }
}