using EduHub.StudentService.Application.Services.Interfaces;
using EduHub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Repositories.BaseServices;

public class StudentService : BaseService<Student>, IStudentService
{
    public Task<List<Student>> GetListStudents(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}