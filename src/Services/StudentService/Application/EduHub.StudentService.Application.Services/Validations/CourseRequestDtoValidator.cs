using EduHub.StudentService.Application.Services.Dto.Course;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations;

public class CourseRequestDtoValidator : AbstractValidator<CourseRequestDto>
{
    public CourseRequestDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .MaximumLength(50);
    }
}