namespace EduHub.StudentService.Application.Services.Interfaces.UoW.Core;

/// <summary>
/// Являющийся родителем для всех реализаций UoW
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Сохраняет изменение в бд
    /// </summary>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>количество затронутых записей, в результате изменения бд</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    
    /// <summary>
    /// Метод, получающий репозитории исходя из дженерика
    /// </summary>
    /// <typeparam name="TRepository">отвечает за то, какой репозиторий вернуть</typeparam>
    /// <returns>возвращает определенный репозиторий</returns>
    TRepository GetRepository<TRepository>();
}