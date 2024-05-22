using EduHub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Interfaces;

public interface ICourseService: IBaseService<Course>
{
    Task<List<Course>> GetListCourses(CancellationToken cancellationToken);
}