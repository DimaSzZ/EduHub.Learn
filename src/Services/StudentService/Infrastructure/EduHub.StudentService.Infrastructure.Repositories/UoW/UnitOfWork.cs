using Ardalis.GuardClauses;
using EduHub.StudentService.Application.Services.Interfaces.UoW.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EduHub.StudentService.Infrastructure.Repositories.UoW;

/// <summary>
/// Реализация базового UoW
/// </summary>
/// <typeparam name="TContext">Потенциальный DB контекст</typeparam>
public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
{
    private readonly TContext _context;
    
    public UnitOfWork(TContext context)
    {
        _context = Guard.Against.Null(context);
    }
    
    /// <summary>
    /// Сохранение состояния бд
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Возвращает число измененных записей в DB</returns>
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
    
    /// <summary>
    /// Высвобождает память
    /// </summary>
    public void Dispose()
    {
        _context.Dispose();
    }
    
    /// <summary>
    /// Получение репозитория по его типу
    /// </summary>
    /// <typeparam name="TRepository">Тип репозитория</typeparam>
    /// <returns>Нужный нам репозиторий</returns>
    public TRepository GetRepository<TRepository>()
    {
        return (TRepository) _context.GetService(typeof(TRepository));
    }
    
    public TContext Context => _context;
}