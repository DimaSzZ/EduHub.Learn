using EduHub.StudentService.Application.Services.Dto.Educator;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Educator;

/// <summary>
/// Валидатор на EducatorCreateDto
/// </summary>
public class EducatorCreateDtoValidator : AbstractValidator<EducatorCreateDto>
{
    public EducatorCreateDtoValidator()
    {
        RuleFor(dto => dto.FirstName)
            .PersonName(nameof(EducatorCreateDto.FirstName));
        
        RuleFor(dto => dto.Surname)
            .PersonName(nameof(EducatorCreateDto.Surname));
        
        RuleFor(dto => dto.Patronymic)
            .PersonName(nameof(EducatorCreateDto.Patronymic));
        
        RuleFor(dto => dto.Gender)
            .Gender(nameof(EducatorCreateDto.Gender));
        
        RuleFor(dto => dto.DateEmployment)
            .Date(nameof(EducatorCreateDto.DateEmployment));
        
        RuleFor(dto => dto.Phone)
            .Phone(nameof(EducatorCreateDto.Phone));
        
        RuleFor(dto => dto.YearsExperience)
            .WorkExperience(nameof(EducatorCreateDto.YearsExperience));
    }
}