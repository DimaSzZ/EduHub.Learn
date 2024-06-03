namespace EduHub.StudentService.Application.Services.Dto.Enrollment;

public record EnrollmentRequestUpdateDto(Guid Id, DateOnly EnrollmentDate, Guid StudentId, Guid CourseId);