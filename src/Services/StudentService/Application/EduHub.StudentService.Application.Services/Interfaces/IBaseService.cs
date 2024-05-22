using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Application.Services.Interfaces;

public interface IBaseService<T> where T : BaseEntity
{
    Task Add(T entity, CancellationToken cancellationToken);
    Task Update(T entity, CancellationToken cancellationToken);
    Task<List<T>> ReadAll(CancellationToken cancellationToken);
    Task Delete(Guid id,CancellationToken cancellationToken);
}