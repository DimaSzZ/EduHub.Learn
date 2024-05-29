using EduHub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Interfaces;

public interface ICourseRepository: IBaseRepository<Course>
{
    Task<Course> GetCourseById(Guid id, CancellationToken cancellationToken);
}