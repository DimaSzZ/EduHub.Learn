using EduHub.StudentService.Application.Services.Dto.Student;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Student;

/// <summary>
/// Валидатор на StudentCreateDto
/// </summary>
public class StudentUpsertDtoValidator : AbstractValidator<StudentUpsertDto>
{
    public StudentUpsertDtoValidator()
    {
        RuleFor(dto => dto.FirstName)
            .PersonName(nameof(StudentUpsertDto.FirstName));
        
        RuleFor(dto => dto.Surname)
            .PersonName(nameof(StudentUpsertDto.Surname));
        
        RuleFor(dto => dto.Patronymic)
            .PersonName(nameof(StudentUpsertDto.Patronymic));
        
        RuleFor(dto => dto.DateBirth)
            .Date(nameof(StudentUpsertDto.DateBirth));
        
        RuleFor(dto => dto.Email)
            .Email(nameof(StudentUpsertDto.Email));
        
        RuleFor(dto => dto.Phone)
            .Phone(nameof(StudentUpsertDto.Phone));
        
        RuleFor(dto => dto.City)
            .Address(nameof(StudentUpsertDto.City));
        
        RuleFor(dto => dto.Street)
            .Address(nameof(StudentUpsertDto.Street));
        
        RuleFor(dto => dto.NumberHouse)
            .NumberHouse(nameof(StudentUpsertDto.NumberHouse));
        
        RuleFor(dto => dto.Avatar)
            .Avatar(nameof(StudentUpsertDto.Avatar));
    }
}