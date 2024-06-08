using EduHub.StudentService.Application.Services.Exceptions.Base;
using EduHub.StudentService.Application.Services.Primitives;
using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Application.Services.Exceptions;

/// <summary>
/// Реализация конфликтного исключения
/// </summary>
/// <typeparam name="TEntity">Тип объекта, которого не удалось найти</typeparam>
public class EntityConflictException<TEntity> : BaseConflictException where TEntity : BaseEntity
{
    /// <summary>
    /// Конструктор, выбрасывающий исключение
    /// </summary>
    /// <param name="paramName ">конфликтное название поля</param>
    /// <param name="value">конфликтный объект</param>
    public EntityConflictException(string paramName, object value) : base(string.Format(ErrorMessages.Conflict, typeof(TEntity).Name, paramName, value))
    {
    }
}