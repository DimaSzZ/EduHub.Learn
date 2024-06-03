namespace EduHub.StudentService.Application.Services.Dto.Course;

public record CourseRequestUpdateDto(Guid Id, string Name, string Description, Guid EducatorId);