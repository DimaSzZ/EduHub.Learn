using EduHub.StudentService.Application.Services.Dto.Educator;
using EduHub.StudentService.Application.Services.Exceptions.Primitives;
using EduHub.StudentService.Application.Services.Exceptions.Regular;
using EduHub.StudentService.Domain.Entities.Enums;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Educator;

public class EducatorRequestDtoValidator : AbstractValidator<EducatorRequestDto>
{
    public EducatorRequestDtoValidator()
    {
        RuleFor(dto => dto.FirstName)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(EducatorRequestDto)))
            .MinimumLength(2).WithMessage(string.Format(ErrorMessages.MinLength, nameof(EducatorRequestDto)))
            .MaximumLength(60).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(EducatorRequestDto)))
            .Matches(RegexPatterns.NamePattern).WithMessage(string.Format(ErrorMessages.BadName, nameof(EducatorRequestDto)));
        
        RuleFor(dto => dto.Surname)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(EducatorRequestDto)))
            .MinimumLength(2).WithMessage(string.Format(ErrorMessages.MinLength, nameof(EducatorRequestDto)))
            .MaximumLength(60).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(EducatorRequestDto)))
            .Matches(RegexPatterns.NamePattern).WithMessage(string.Format(ErrorMessages.BadName, nameof(EducatorRequestDto)));
        
        RuleFor(dto => dto.Patronymic)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(EducatorRequestDto)))
            .MinimumLength(2).WithMessage(string.Format(ErrorMessages.MinLength, nameof(EducatorRequestDto)))
            .MaximumLength(60).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(EducatorRequestDto)))
            .Matches(RegexPatterns.NamePattern).WithMessage(string.Format(ErrorMessages.BadName, nameof(EducatorRequestDto)));
        
        RuleFor(dto => dto.Gender)
            .NotEqual(default(Gender)).WithMessage(string.Format(ErrorMessages.NotDefault, nameof(EducatorRequestDto)))
            .IsInEnum();
        
        RuleFor(dto => dto.DateEmployment)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(EducatorRequestDto)))
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today)).WithMessage(ErrorMessages.BadDate);
        
        RuleFor(dto => dto.Phone)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(EducatorRequestDto)))
            .Matches(RegexPatterns.PmrPhonePattern).WithMessage(ErrorMessages.BadPhone);
        
        RuleFor(dto => dto.WorkExperience)
            .NotNull().WithMessage(string.Format(ErrorMessages.Required, nameof(EducatorRequestDto)))
            .GreaterThanOrEqualTo(0).WithMessage(string.Format(ErrorMessages.MinLength, nameof(EducatorRequestDto)));
    }
}