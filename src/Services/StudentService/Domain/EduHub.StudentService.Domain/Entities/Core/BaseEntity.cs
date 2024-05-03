using Ardalis.GuardClauses;

namespace EduHub.StudentService.Domain.Entities.Core;

/// <summary>
/// Является родителем для все моделей
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Идентификатор,который есть у каждой модели
    /// </summary>
    public Guid Id { get; private set; }
    
    protected void SetId(Guid id)
    {
        Id = Guard.Against.NullOrEmpty(id, nameof(id));
    }
}