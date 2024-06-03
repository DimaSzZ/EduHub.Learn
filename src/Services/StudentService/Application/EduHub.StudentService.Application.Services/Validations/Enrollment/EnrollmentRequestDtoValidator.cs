using EduHub.StudentService.Application.Services.Dto.Enrollment;
using EduHub.StudentService.Application.Services.Exceptions.Primitives;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Enrollment;

public class EnrollmentRequestDtoValidator : AbstractValidator<EnrollmentRequestDto>
{
    public EnrollmentRequestDtoValidator()
    {
        RuleFor(dto => dto.CourseId)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(EnrollmentRequestDto)));
        
        RuleFor(dto => dto.StudentId)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(EnrollmentRequestDto)));
        
        RuleFor(dto => dto.EnrollmentDate)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(EnrollmentRequestDto)))
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today)).WithMessage(ErrorMessages.BadDate);
    }
}