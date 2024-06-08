using EduHub.StudentService.Application.Services.Dto.Student;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Student;

/// <summary>
/// Валидатор на StudentCreateDto
/// </summary>
public class StudentCreateDtoValidator : AbstractValidator<StudentCreateDto>
{
    public StudentCreateDtoValidator()
    {
        RuleFor(dto => dto.FirstName)
            .PersonName(nameof(StudentCreateDto.FirstName));
        
        RuleFor(dto => dto.Surname)
            .PersonName(nameof(StudentCreateDto.Surname));
        
        RuleFor(dto => dto.Patronymic)
            .PersonName(nameof(StudentCreateDto.Patronymic));
        
        RuleFor(dto => dto.DateBirth)
            .Date(nameof(StudentCreateDto.DateBirth));
        
        RuleFor(dto => dto.Email)
            .Email(nameof(StudentCreateDto.Email));
        
        RuleFor(dto => dto.Phone)
            .Phone(nameof(StudentCreateDto.Phone));
        
        RuleFor(dto => dto.City)
            .Address(nameof(StudentCreateDto.City));
        
        RuleFor(dto => dto.Street)
            .Address(nameof(StudentCreateDto.Street));
        
        RuleFor(dto => dto.NumberHouse)
            .NumberHouse(nameof(StudentCreateDto.NumberHouse));
        
        RuleFor(dto => dto.Avatar)
            .Avatar(nameof(StudentCreateDto.Avatar));
    }
}