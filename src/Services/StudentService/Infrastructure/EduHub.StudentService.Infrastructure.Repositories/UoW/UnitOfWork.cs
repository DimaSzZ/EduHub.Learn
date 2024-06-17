using Ardalis.GuardClauses;
using EduHub.StudentService.Application.Services.Interfaces.UoW.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EduHub.StudentService.Infrastructure.Repositories.UoW;

public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
{
    private readonly TContext _context;
    
    public UnitOfWork(TContext context)
    {
        _context = Guard.Against.Null(context);
    }
    
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
    
    public TRepository GetRepository<TRepository>()
    {
        return (TRepository) _context.GetService(typeof(TRepository));
    }
    
    public TContext Context => _context;
}