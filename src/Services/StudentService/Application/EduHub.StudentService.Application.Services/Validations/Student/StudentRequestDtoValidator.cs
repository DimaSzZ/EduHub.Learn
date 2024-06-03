using EduHub.StudentService.Application.Services.Dto.Student;
using EduHub.StudentService.Application.Services.Exceptions.Primitives;
using EduHub.StudentService.Application.Services.Exceptions.Regular;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Student;

public class StudentRequestDtoValidator : AbstractValidator<StudentRequestDto>
{
    public StudentRequestDtoValidator()
    {
        RuleFor(dto => dto.FirstName)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(StudentRequestDto)))
            .MinimumLength(2).WithMessage(string.Format(ErrorMessages.MinLength, nameof(StudentRequestDto)))
            .MaximumLength(60).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(StudentRequestDto)))
            .Matches(RegexPatterns.NamePattern).WithMessage(string.Format(ErrorMessages.BadName, nameof(StudentRequestDto)));
        
        RuleFor(dto => dto.Surname)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(StudentRequestDto)))
            .MinimumLength(2).WithMessage(string.Format(ErrorMessages.MinLength, nameof(StudentRequestDto)))
            .MaximumLength(60).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(StudentRequestDto)))
            .Matches(RegexPatterns.NamePattern).WithMessage(string.Format(ErrorMessages.BadName, nameof(StudentRequestDto)));
        
        RuleFor(dto => dto.Patronymic)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(StudentRequestDto)))
            .MinimumLength(2).WithMessage(string.Format(ErrorMessages.MinLength, nameof(StudentRequestDto)))
            .MaximumLength(60).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(StudentRequestDto)))
            .Matches(RegexPatterns.NamePattern).WithMessage(string.Format(ErrorMessages.BadName, nameof(StudentRequestDto)));
        
        RuleFor(dto => dto.DateBirth)
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
            .WithMessage(ErrorMessages.BadDate);
        
        RuleFor(dto => dto.Email)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(StudentRequestDto)))
            .MaximumLength(255).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(StudentRequestDto)))
            .Matches(RegexPatterns.EmailPattern).WithMessage(ErrorMessages.BadEmail);
        
        RuleFor(dto => dto.Phone)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(StudentRequestDto)))
            .Matches(RegexPatterns.PmrPhonePattern).WithMessage(ErrorMessages.BadPhone);
        
        RuleFor(dto => dto.City)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(StudentRequestDto)))
            .MaximumLength(100).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(StudentRequestDto)));
        
        RuleFor(dto => dto.Street)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(StudentRequestDto)))
            .MaximumLength(100).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(StudentRequestDto)));
        
        RuleFor(dto => dto.NumberHouse)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(StudentRequestDto)))
            .GreaterThanOrEqualTo(0).WithMessage(string.Format(ErrorMessages.MinLength, nameof(StudentRequestDto)));
        
        RuleFor(dto => dto.Avatar)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(StudentRequestDto)))
            .Matches(RegexPatterns.FilePngJpgPattern).WithMessage(ErrorMessages.BadFile);
    }
}