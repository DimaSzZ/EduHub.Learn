using EduHub.StudentService.Application.Services.Dto.Enrollment;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Enrollment;

/// <summary>
/// Вадитаор на EnrollmentUpdateDto
/// </summary>
public class EnrollmentUpdateDtoValidator : AbstractValidator<EnrollmentUpdateDto>
{
    public EnrollmentUpdateDtoValidator()
    {
        RuleFor(dto => dto.Id)
            .Id();
        
        RuleFor(dto => dto.CourseId)
            .Id();
        
        RuleFor(dto => dto.StudentId)
            .Id();
        
        RuleFor(dto => dto.EnrollmentDate)
            .Date();
    }
}