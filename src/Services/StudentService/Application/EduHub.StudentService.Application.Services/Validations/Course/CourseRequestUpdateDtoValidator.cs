using EduHub.StudentService.Application.Services.Dto.Course;
using EduHub.StudentService.Application.Services.Exceptions.Primitives;
using EduHub.StudentService.Application.Services.Exceptions.Regular;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Course;

public class CourseRequestUpdateDtoValidator : AbstractValidator<CourseRequestUpdateDto>
{
    public CourseRequestUpdateDtoValidator()
    {
        RuleFor(dto => dto.Id)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(CourseRequestUpdateDto)));
        
        RuleFor(dto => dto.Name)
            .Matches(RegexPatterns.NamePattern).WithMessage(string.Format(ErrorMessages.BadName, nameof(CourseRequestUpdateDto.Name)))
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(CourseRequestUpdateDto.Name)))
            .MaximumLength(50).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(CourseRequestUpdateDto.Name)));
        
        RuleFor(dto => dto.EducatorId)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(CourseRequestUpdateDto.Name)));
    }
}