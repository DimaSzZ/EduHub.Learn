using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Application.Services.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T> Add(T entity, CancellationToken cancellationToken);
    Task<T> Update(T entity, CancellationToken cancellationToken);
    
    Task<List<T>> GetAllEntities(CancellationToken cancellationToken);
    Task<T> Delete(Guid id,CancellationToken cancellationToken);
}