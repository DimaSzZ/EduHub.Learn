using EduHub.StudentService.Application.Services.Interfaces.Repositories.Core;
using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Application.Services.Interfaces.UoW.Core;

/// <summary>
/// Базовый репозиторий, являющийся родителем для всех реализаций UoW
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Сохраняет изменение в бд
    /// </summary>
    /// <param name="cancellationToken">тоен отмены</param>
    /// <returns>количество затронутых записей, в результате изменения бд</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    
    /// <summary>
    /// Метод, получающий репозитории исходя из дженерика
    /// </summary>
    /// <typeparam name="TRepository">отвечает за то, какой репозиторий вернуть</typeparam>
    /// <returns>возвращает определенный репозиторий</returns>
    IBaseRepository<TRepository> GetRepository<TRepository>() where  TRepository : BaseEntity;
}