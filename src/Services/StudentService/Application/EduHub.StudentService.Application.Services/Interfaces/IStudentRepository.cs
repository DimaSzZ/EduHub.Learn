using EduHub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Interfaces;

public interface IStudentRepository : IBaseRepository<Student>
{
    Task<Student> GetStudentById(Guid id, CancellationToken cancellationToken);
}