using EduHub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Interfaces;

public interface IStudentService : IBaseService<Student>
{
    Task<List<Student>> GetListStudents(CancellationToken cancellationToken);
}