namespace EduHub.StudentService.Application.Services.Dto.Enrollment;

public record EnrollmentResponseDto(Guid Id, DateOnly EnrollmentDate, Guid StudentId, Guid CourseId);