using Ardalis.GuardClauses;

namespace EduHub.StudentService.Domain.Entities.Core;

public abstract class BaseEntity
{
    public Guid IdDb { get; private set; }

    public void SetIdDb(Guid idDb)
    {
        IdDb = Guard.Against.NullOrEmpty(idDb, nameof(idDb));
    }
}