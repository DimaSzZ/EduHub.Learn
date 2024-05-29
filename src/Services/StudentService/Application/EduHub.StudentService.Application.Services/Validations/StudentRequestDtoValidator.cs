using EduHub.StudentService.Application.Services.Dto.Student;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations;

public class StudentRequestDtoValidator : AbstractValidator<StudentRequestDto>
{
    public StudentRequestDtoValidator()
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
        
        RuleFor(dto => dto.DateBirth)
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
            .WithMessage("Date of birth cannot be in the future");
        
        RuleFor(dto => dto.Email)
            .NotEmpty().WithMessage("Email is required")
            .MaximumLength(255).WithMessage("Email length cannot exceed 255 characters")
            .Must(email => email.Contains("@")).WithMessage("Invalid email format");
        
        RuleFor(dto => dto.Phone)
            .NotEmpty().WithMessage("Phone number is required")
            .Matches(@"^\+373(?:6|7)[0-9]{7}$").WithMessage("Invalid phone number format for PMR");
        
        RuleFor(dto => dto.City)
            .NotEmpty().WithMessage("City is required")
            .MaximumLength(100).WithMessage("City cannot exceed 100 characters");
        
        RuleFor(dto => dto.Street)
            .NotEmpty().WithMessage("Street is required")
            .MaximumLength(100).WithMessage("Street cannot exceed 100 characters");
        
        RuleFor(dto => dto.NumberHouse)
            .GreaterThanOrEqualTo(0).WithMessage("House number must be non-negative");
        
        RuleFor(dto => dto.Avatar)
            .NotEmpty().WithMessage("Avatar URL is required")
            .Matches(@"\.(png|jpg)$").WithMessage("Avatar URL must be a .png or .jpg image");
    }
}