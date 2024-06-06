using EduHub.StudentService.Application.Services.Dto.Student;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Student;

/// <summary>
/// Вадитаор на StudentUpdateDto
/// </summary>
public class StudentUpdateDtoValidator : AbstractValidator<StudentUpdateDto>
{
    public StudentUpdateDtoValidator()
    {
        RuleFor(dto => dto.Id)
            .Id();
        
        RuleFor(dto => dto.FirstName)
            .PersonName();
        
        RuleFor(dto => dto.Surname)
            .PersonName();
        
        RuleFor(dto => dto.Patronymic)
            .PersonName();
        
        RuleFor(dto => dto.DateBirth)
            .Date();
        
        RuleFor(dto => dto.Email)
            .Email();
        
        RuleFor(dto => dto.Phone)
            .Phone();
        
        RuleFor(dto => dto.City)
            .Address();
        
        RuleFor(dto => dto.Street)
            .Address();
        
        RuleFor(dto => dto.NumberHouse)
            .NumberHouse();
        
        RuleFor(dto => dto.Avatar)
            .Avatar();
    }
}