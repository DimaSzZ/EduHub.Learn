using EduHub.StudentService.Application.Services.Interfaces;
using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Application.Services.Repositories;

public abstract class BaseService<T> : IBaseService<T> where T: BaseEntity
{
    public virtual Task Add(T entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    
    public virtual Task Update(T entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    
    public virtual Task<List<T>> ReadAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    
    public virtual Task Delete(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}