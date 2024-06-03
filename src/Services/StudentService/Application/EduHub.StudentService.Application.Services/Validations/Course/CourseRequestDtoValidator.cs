using EduHub.StudentService.Application.Services.Dto.Course;
using EduHub.StudentService.Application.Services.Exceptions.Primitives;
using EduHub.StudentService.Application.Services.Exceptions.Regular;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations.Course;

public class CourseRequestDtoValidator : AbstractValidator<CourseRequestDto>
{
    public CourseRequestDtoValidator() 
    {
        RuleFor(dto => dto.Name)
            .Matches(RegexPatterns.NamePattern).WithMessage(string.Format(ErrorMessages.BadName, nameof(CourseRequestDto.Name)))
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(CourseRequestDto.Name)))
            .MaximumLength(50);
        
        RuleFor(dto => dto.EducatorId)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(CourseRequestDto.Name)));
    }
}
