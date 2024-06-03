using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Application.Services.Interfaces.Repositories.Core;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}