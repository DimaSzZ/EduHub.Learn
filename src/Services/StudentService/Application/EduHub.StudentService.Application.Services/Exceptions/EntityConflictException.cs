using EduHub.StudentService.Application.Services.Exceptions.Base;
using EduHub.StudentService.Application.Services.Exceptions.Primitives;
using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Application.Services.Exceptions;

public class EntityConflictException<TEntity> : BaseConflictException where TEntity : BaseEntity
{
    public EntityConflictException(Guid resourceId) : base(string.Format(ErrorMessages.Conflict, typeof(TEntity).Name, resourceId))
    {
    }
}