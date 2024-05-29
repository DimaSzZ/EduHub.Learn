namespace EduHub.StudentService.Application.Services.Dto.Course;

public record CourseRequestDto(string Name, string Description, Guid EducatorId);
