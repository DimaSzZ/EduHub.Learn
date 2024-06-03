using EduHub.StudentService.Application.Services.Dto.Student;
using EduHub.StudentService.Application.Services.Exceptions.Primitives;
using EduHub.StudentService.Application.Services.Exceptions.Regular;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Student;

public class StudentRequestUpdateDtoValidator : AbstractValidator<StudentRequestUpdateDto>
{
    public StudentRequestUpdateDtoValidator()
    {
        RuleFor(dto => dto.Id)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(StudentRequestUpdateDto)));
        
        RuleFor(dto => dto.FirstName)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(StudentRequestUpdateDto)))
            .MinimumLength(2).WithMessage(string.Format(ErrorMessages.MinLength, nameof(StudentRequestUpdateDto)))
            .MaximumLength(60).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(StudentRequestUpdateDto)))
            .Matches(RegexPatterns.NamePattern).WithMessage(string.Format(ErrorMessages.BadName, nameof(StudentRequestUpdateDto)));
        
        RuleFor(dto => dto.Surname)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(StudentRequestUpdateDto)))
            .MinimumLength(2).WithMessage(string.Format(ErrorMessages.MinLength, nameof(StudentRequestUpdateDto)))
            .MaximumLength(60).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(StudentRequestUpdateDto)))
            .Matches(RegexPatterns.NamePattern).WithMessage(string.Format(ErrorMessages.BadName, nameof(StudentRequestUpdateDto)));
        
        RuleFor(dto => dto.Patronymic)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(StudentRequestUpdateDto)))
            .MinimumLength(2).WithMessage(string.Format(ErrorMessages.MinLength, nameof(StudentRequestUpdateDto)))
            .MaximumLength(60).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(StudentRequestUpdateDto)))
            .Matches(RegexPatterns.NamePattern).WithMessage(string.Format(ErrorMessages.BadName, nameof(StudentRequestUpdateDto)));
        
        RuleFor(dto => dto.DateBirth)
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
            .WithMessage(ErrorMessages.BadDate);
        
        RuleFor(dto => dto.Email)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(StudentRequestUpdateDto)))
            .MaximumLength(255).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(StudentRequestUpdateDto)))
            .Matches(RegexPatterns.EmailPattern).WithMessage(ErrorMessages.BadEmail);
        
        RuleFor(dto => dto.Phone)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(StudentRequestUpdateDto)))
            .Matches(RegexPatterns.PmrPhonePattern).WithMessage(ErrorMessages.BadPhone);
        
        RuleFor(dto => dto.City)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(StudentRequestUpdateDto)))
            .MaximumLength(100).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(StudentRequestUpdateDto)));
        
        RuleFor(dto => dto.Street)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(StudentRequestUpdateDto)))
            .MaximumLength(100).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(StudentRequestUpdateDto)));
        
        RuleFor(dto => dto.NumberHouse)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(StudentRequestUpdateDto)))
            .GreaterThanOrEqualTo(0).WithMessage(string.Format(ErrorMessages.MinLength, nameof(StudentRequestUpdateDto)));
        
        RuleFor(dto => dto.Avatar)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(StudentRequestUpdateDto)))
            .Matches(RegexPatterns.FilePngJpgPattern).WithMessage(ErrorMessages.BadFile);
    }
}