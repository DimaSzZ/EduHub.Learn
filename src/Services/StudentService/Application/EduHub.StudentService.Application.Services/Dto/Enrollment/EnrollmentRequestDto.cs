namespace EduHub.StudentService.Application.Services.Dto.Enrollment;

public record EnrollmentRequestDto(DateOnly EnrollmentDate, Guid StudentId, Guid CourseId);