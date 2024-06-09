using EduHub.StudentService.Application.Services.Dto.Student;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Student;

/// <summary>
/// Валидатор на StudentUpdateDto
/// </summary>
public class StudentUpdateDtoValidator : AbstractValidator<StudentUpdateDto>
{
    public StudentUpdateDtoValidator()
    {
        RuleFor(dto => dto.Id)
            .Id(nameof(StudentUpdateDto.Id));
        
        RuleFor(dto => dto.FirstName)
            .PersonName(nameof(StudentUpdateDto.FirstName));
        
        RuleFor(dto => dto.Surname)
            .PersonName(nameof(StudentUpdateDto.Surname));
        
        RuleFor(dto => dto.Patronymic)
            .PersonName(nameof(StudentUpdateDto.Patronymic));
        
        RuleFor(dto => dto.DateBirth)
            .Date(nameof(StudentUpdateDto.DateBirth));
        
        RuleFor(dto => dto.Email)
            .Email(nameof(StudentUpdateDto.Email));
        
        RuleFor(dto => dto.Phone)
            .Phone(nameof(StudentUpdateDto.Phone));
        
        RuleFor(dto => dto.City)
            .Address(nameof(StudentUpdateDto.City));
        
        RuleFor(dto => dto.Street)
            .Address(nameof(StudentUpdateDto.Street));
        
        RuleFor(dto => dto.NumberHouse)
            .NumberHouse(nameof(StudentUpdateDto.NumberHouse));
        
        RuleFor(dto => dto.Avatar)
            .Avatar(nameof(StudentUpdateDto.Avatar));
    }
}