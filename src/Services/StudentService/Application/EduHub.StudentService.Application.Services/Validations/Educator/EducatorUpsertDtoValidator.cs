using EduHub.StudentService.Application.Services.Dto.Educator;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Educator;

/// <summary>
/// Валидатор на EducatorCreateDto
/// </summary>
public class EducatorUpsertDtoValidator : AbstractValidator<EducatorUpsertDto>
{
    public EducatorUpsertDtoValidator()
    {
        RuleFor(dto => dto.FirstName)
            .PersonName(nameof(EducatorUpsertDto.FirstName));
        
        RuleFor(dto => dto.Surname)
            .PersonName(nameof(EducatorUpsertDto.Surname));
        
        RuleFor(dto => dto.Patronymic)
            .PersonName(nameof(EducatorUpsertDto.Patronymic));
        
        RuleFor(dto => dto.Gender)
            .Gender(nameof(EducatorUpsertDto.Gender));
        
        RuleFor(dto => dto.DateEmployment)
            .Date(nameof(EducatorUpsertDto.DateEmployment));
        
        RuleFor(dto => dto.Phone)
            .Phone(nameof(EducatorUpsertDto.Phone));
        
        RuleFor(dto => dto.YearsExperience)
            .WorkExperience(nameof(EducatorUpsertDto.YearsExperience));
    }
}