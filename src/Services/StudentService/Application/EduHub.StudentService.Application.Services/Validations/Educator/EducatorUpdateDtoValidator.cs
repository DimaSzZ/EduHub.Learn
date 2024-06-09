using EduHub.StudentService.Application.Services.Dto.Educator;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Educator;

/// <summary>
/// Валидатор на EducatorUpdateDto
/// </summary>
public class EducatorUpdateDtoValidator : AbstractValidator<EducatorUpdateDto>
{
    public EducatorUpdateDtoValidator()
    {
        RuleFor(dto => dto.Id)
            .Id(nameof(EducatorUpdateDto.Id));
        
        RuleFor(dto => dto.FirstName)
            .PersonName(nameof(EducatorUpdateDto.FirstName));
        
        RuleFor(dto => dto.Surname)
            .PersonName(nameof(EducatorUpdateDto.Surname));
        
        RuleFor(dto => dto.Patronymic)
            .PersonName(nameof(EducatorUpdateDto.Patronymic));
        
        RuleFor(dto => dto.Gender)
            .Gender(nameof(EducatorUpdateDto.Gender));
        
        RuleFor(dto => dto.DateEmployment)
            .Date(nameof(EducatorUpdateDto.DateEmployment));
        
        RuleFor(dto => dto.Phone)
            .Phone(nameof(EducatorUpdateDto.Phone));
        
        RuleFor(dto => dto.YearsExperience)
            .WorkExperience(nameof(EducatorUpdateDto.YearsExperience));
    }
}