using EduHub.StudentService.Application.Services.Interfaces.Repositories.Core;
using EduHub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Interfaces.Repositories;

/// <summary>
/// Репозиторий, отвечающий за работу с Enrollment
/// </summary>
public interface IEnrollmentRepository : IBaseRepository<Enrollment>
{
    /// <summary>
    /// Получегие списка зачислений студента по его id
    /// </summary>
    /// <param name="studentId">id студента</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>олучегие списка зачислений студента по его id</returns>
    Task<IList<Enrollment>> GetListByStudentIdAsync(Guid studentId, CancellationToken cancellationToken);
}