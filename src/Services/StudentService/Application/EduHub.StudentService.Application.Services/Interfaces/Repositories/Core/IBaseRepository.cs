using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Application.Services.Interfaces.Repositories.Core;

/// <summary>
/// Базовый репозиторий, содержащий базовые методы для доступа к базе данных
/// </summary>
/// <typeparam name="TEntity">Класс к которому будем обращаться</typeparam>
public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    /// Асинхронное добавление объекта бд
    /// </summary>
    /// <param name="entity">объект бд</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращение объекта entity</returns>
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
    
    /// <summary>
    /// Асинхронное обновление объекта бд
    /// </summary>
    /// <param name="entity">объект бд</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращение объекта entity</returns>
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    
    /// <summary>
    /// Асинхронное получение всех объектов бд
    /// </summary>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>Возвращение всех объектов бд</returns>
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
        
    /// <summary>
    /// Асинхронное удаление объекта бд
    /// </summary>
    /// <param name="entity">объект бд</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращение удаленного объекта entity</returns>
    Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получение объекта по Id
    /// </summary>
    /// <param name="id">уникальный id объекта</param>
    /// <param name="cancellationToken">токен отмены</param>
    /// <returns>возвращение объекта, полученного по id</returns>
    Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}