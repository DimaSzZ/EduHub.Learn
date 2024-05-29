using EduHub.StudentService.Application.Services.Dto.Educator;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations;

public class EducatorRequestDtoValidator : AbstractValidator<EducatorRequestDto>
{
    public EducatorRequestDtoValidator()
    {
        RuleFor(dto => dto.FirstName)
            .NotEmpty().WithMessage("FirstName is required")
            .MinimumLength(2).WithMessage("FirstName must be at least 2 characters long")
            .MaximumLength(60).WithMessage("FirstName cannot exceed 60 characters")
            .Matches("^[A-Za-z]+$").WithMessage("FirstName must contain only letters");
        
        RuleFor(dto => dto.Surname)
            .NotEmpty().WithMessage("Surname is required")
            .MinimumLength(2).WithMessage("Surname must be at least 2 characters long")
            .MaximumLength(60).WithMessage("Surname cannot exceed 60 characters")
            .Matches("^[A-Za-z]+$").WithMessage("Surname must contain only letters");
        
        RuleFor(dto => dto.Patronymic)
            .NotEmpty().WithMessage("Patronymic is required")
            .MinimumLength(2).WithMessage("Patronymic must be at least 2 characters long")
            .MaximumLength(60).WithMessage("Patronymic cannot exceed 60 characters")
            .Matches("^[A-Za-z]+$").WithMessage("Patronymic must contain only letters");
        
        RuleFor(dto => dto.Phone)
            .NotEmpty().WithMessage("Phone number is required")
            .Matches(@"^\+373(?:6|7)[0-9]{7}$").WithMessage("Invalid phone number format for PMR");
        
        RuleFor(dto => dto.WorkExperience)
            .GreaterThanOrEqualTo(0).WithMessage("Work experience must be non-negative");
    }
}