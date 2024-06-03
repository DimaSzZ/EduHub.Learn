using EduHub.StudentService.Application.Services.Exceptions.Base;
using EduHub.StudentService.Application.Services.Exceptions.Primitives;
using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Application.Services.Exceptions;

public class EntityNotFoundException<TEntity> : BaseNotFoundException where TEntity : BaseEntity
{
    public EntityNotFoundException() :  base(string.Format(ErrorMessages.NotFound, typeof(TEntity).Name))
    {
    }
}