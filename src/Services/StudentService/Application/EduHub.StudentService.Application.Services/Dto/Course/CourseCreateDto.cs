namespace EduHub.StudentService.Application.Services.Dto.Course;

/// <summary>
/// Дто на создание курса
/// </summary>
/// <param name="Name">Имя</param>
/// <param name="Description">Описание</param>
/// <param name="EducatorId">Id преподавателя</param>
public record CourseCreateDto(string Name, string Description, Guid EducatorId);