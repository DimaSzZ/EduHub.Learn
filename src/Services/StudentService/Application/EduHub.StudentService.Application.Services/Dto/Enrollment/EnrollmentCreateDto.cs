namespace EduHub.StudentService.Application.Services.Dto.Enrollment;

/// <summary>
/// Дто на создание зачисления
/// </summary>
/// <param name="EnrollmentDate">дата зачисления</param>
/// <param name="StudentId">Id студента</param>
/// <param name="CourseId">Id курса</param>
public record EnrollmentCreateDto(DateOnly EnrollmentDate, Guid StudentId, Guid CourseId);