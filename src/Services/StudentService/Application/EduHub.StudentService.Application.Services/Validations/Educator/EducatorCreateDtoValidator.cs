using EduHub.StudentService.Application.Services.Dto.Educator;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Educator;

/// <summary>
/// Вадитаор на EducatorCreateDto
/// </summary>
public class EducatorCreateDtoValidator : AbstractValidator<EducatorCreateDto>
{
    public EducatorCreateDtoValidator()
    {
        RuleFor(dto => dto.FirstName)
            .PersonName();
        
        RuleFor(dto => dto.Surname)
            .PersonName();
        
        RuleFor(dto => dto.Patronymic)
            .PersonName();
        
        RuleFor(dto => dto.Gender)
            .Gender();
        
        RuleFor(dto => dto.DateEmployment)
            .Date();
        
        RuleFor(dto => dto.Phone)
            .Phone();
        
        RuleFor(dto => dto.WorkExperience)
            .WorkExperience();
    }
}