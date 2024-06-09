namespace EduHub.StudentService.Application.Services.Dto.Enrollment;

/// <summary>
/// Дто на возврат зачисления
/// </summary>
/// <param name="Id">Id зачисления</param>
/// <param name="EnrollmentDate">дата зачисления</param>
/// <param name="StudentId">Id студента</param>
/// <param name="CourseId">Id курса</param>
public record EnrollmentResponseDto(Guid Id, DateOnly EnrollmentDate, Guid StudentId, Guid CourseId);