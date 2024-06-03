using EduHub.StudentService.Application.Services.Dto.Enrollment;
using EduHub.StudentService.Application.Services.Exceptions.Primitives;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Enrollment;

public class EnrollmentRequestUpdateDtoValidator : AbstractValidator<EnrollmentRequestUpdateDto>
{
    public EnrollmentRequestUpdateDtoValidator()
    {
        RuleFor(dto => dto.Id)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(EnrollmentRequestUpdateDto)));
        
        RuleFor(dto => dto.CourseId)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(EnrollmentRequestUpdateDto)));
        
        RuleFor(dto => dto.StudentId)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(EnrollmentRequestUpdateDto)));
        
        RuleFor(dto => dto.EnrollmentDate)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(EnrollmentRequestUpdateDto)))
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today)).WithMessage(ErrorMessages.BadDate);
    }
}