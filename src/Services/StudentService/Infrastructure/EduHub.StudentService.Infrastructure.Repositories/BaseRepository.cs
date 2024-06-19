using Ardalis.GuardClauses;
using EduHub.StudentService.Application.Services.Interfaces.Repositories.Core;
using EduHub.StudentService.Domain.Entities.Core;
using Microsoft.EntityFrameworkCore;

namespace EduHub.StudentService.Infrastructure.Repositories;

/// <summary>
/// Реализация базового репозитория, являющегося родителем для всех репозиториев
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    /// Контекст бд
    /// </summary>
    protected readonly DbContext _context;
    
    public BaseRepository(DbContext context)
    {
        _context = context;
    }
    
    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
        return entity;
    }
    
    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Update(entity);
        return await Task.FromResult(entity);
    }
    
    public async Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<TEntity>().ToListAsync(cancellationToken);
    }
    
    public async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Remove(entity);
        return await Task.FromResult(entity);
    }
    
    public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.Set<TEntity>().FindAsync(new object[] {id}, cancellationToken);
        
        Guard.Against.Null(entity);
        
        return entity;
    }
    
    public async Task<bool> ExistAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<TEntity>().AnyAsync(e => e.Id == id, cancellationToken);
    }
}