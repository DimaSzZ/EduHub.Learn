using EduHub.StudentService.Application.Services.Dto.Educator;
using EduHub.StudentService.Application.Services.Exceptions.Primitives;
using EduHub.StudentService.Application.Services.Exceptions.Regular;
using EduHub.StudentService.Domain.Entities.Enums;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Educator;

public class EducatorRequestUpdateDtoValidator:  AbstractValidator<EducatorRequestUpdateDto>
{
    public EducatorRequestUpdateDtoValidator()
    {
        RuleFor(dto => dto.Id)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(EducatorRequestUpdateDto)));
        
        RuleFor(dto => dto.FirstName)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(EducatorRequestUpdateDto)))
            .MinimumLength(2).WithMessage(string.Format(ErrorMessages.MinLength, nameof(EducatorRequestUpdateDto)))
            .MaximumLength(60).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(EducatorRequestUpdateDto)))
            .Matches(RegexPatterns.NamePattern).WithMessage(string.Format(ErrorMessages.BadName, nameof(EducatorRequestUpdateDto)));
        
        RuleFor(dto => dto.Surname)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(EducatorRequestUpdateDto)))
            .MinimumLength(2).WithMessage(string.Format(ErrorMessages.MinLength, nameof(EducatorRequestUpdateDto)))
            .MaximumLength(60).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(EducatorRequestUpdateDto)))
            .Matches(RegexPatterns.NamePattern).WithMessage(string.Format(ErrorMessages.BadName, nameof(EducatorRequestUpdateDto)));
        
        RuleFor(dto => dto.Patronymic)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(EducatorRequestUpdateDto)))
            .MinimumLength(2).WithMessage(string.Format(ErrorMessages.MinLength, nameof(EducatorRequestUpdateDto)))
            .MaximumLength(60).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(EducatorRequestUpdateDto)))
            .Matches(RegexPatterns.NamePattern).WithMessage(string.Format(ErrorMessages.BadName, nameof(EducatorRequestUpdateDto)));
        
        RuleFor(dto => dto.Gender)
            .NotEqual(default(Gender)).WithMessage(string.Format(ErrorMessages.NotDefault, nameof(EducatorRequestUpdateDto)))
            .IsInEnum();
        
        RuleFor(dto => dto.DateEmployment)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(EducatorRequestUpdateDto)))
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today)).WithMessage(ErrorMessages.BadDate);
        
        RuleFor(dto => dto.Phone)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(EducatorRequestUpdateDto)))
            .Matches(RegexPatterns.PmrPhonePattern).WithMessage(ErrorMessages.BadPhone);
        
        RuleFor(dto => dto.WorkExperience)
            .NotNull().WithMessage(string.Format(ErrorMessages.Required, nameof(EducatorRequestUpdateDto)))
            .GreaterThanOrEqualTo(0).WithMessage(string.Format(ErrorMessages.MinLength, nameof(EducatorRequestUpdateDto)));
    }
}