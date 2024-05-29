namespace EduHub.StudentService.Application.Services.Dto.Course;

public record CourseResponseDto(Guid Id, string Name, string Description, Guid EducatorId);
