using Ardalis.GuardClauses;
using EduHub.StudentService.Application.Services.Interfaces.Repositories.Core;
using EduHub.StudentService.Domain.Entities.Core;
using EduHub.StudentService.Infrastructure.Repositories.UoW;
using Microsoft.EntityFrameworkCore;

namespace EduHub.StudentService.Infrastructure.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly StudentUnitOfWork _studentUnitOfWork;
    protected readonly DbSet<TEntity> _dbSet;
    
    public BaseRepository(StudentUnitOfWork studentUnitOfWork)
    {
        _studentUnitOfWork = Guard.Against.Null(studentUnitOfWork);
        _dbSet = _studentUnitOfWork.Context.Set<TEntity>();
    }
    
    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        return entity;
    }
    
    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
         _dbSet.Update(entity);
         return await Task.FromResult(entity);
    }
    
    public async Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
       return await _dbSet.ToListAsync(cancellationToken);
    }
    
    public async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Remove(entity);
        return await Task.FromResult(entity);
    }
    
    public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
    }
    
    public async Task<bool> ExistAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AnyAsync(e => e.Id == id, cancellationToken);
    }
}