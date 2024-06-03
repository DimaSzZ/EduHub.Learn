using EduHub.StudentService.Application.Services.Interfaces.Repositories.Core;
using EduHub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Interfaces.Repositories;

public interface IEnrollmentRepository : IBaseRepository<Enrollment>
{
    Task<IList<Enrollment>> GetListByStudentIdAsync(Guid studentId, CancellationToken cancellationToken);
}