namespace EduHub.StudentService.Application.Services.Dto.Course;

/// <summary>
/// Дто на обновление курса
/// </summary>
/// <param name="Id">Id курса</param>
/// <param name="Name">Имя</param>
/// <param name="Description">Описание</param>
/// <param name="EducatorId">Id преподавателя</param>
public record CourseUpdateDto(Guid Id, string Name, string Description, Guid EducatorId);