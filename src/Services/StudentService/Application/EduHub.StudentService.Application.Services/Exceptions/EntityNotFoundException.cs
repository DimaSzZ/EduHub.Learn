using EduHub.StudentService.Application.Services.Exceptions.Base;
using EduHub.StudentService.Application.Services.Primitives;
using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Application.Services.Exceptions;

/// <summary>
/// Реализация 404 исключения
/// </summary>
/// <typeparam name="TEntity">Тип объекта, которого не удалось найти</typeparam>
public class EntityNotFoundException<TEntity> : BaseNotFoundException where TEntity : BaseEntity
{
    /// <summary>
    /// Конструктор, выбрасывающий исключение
    /// </summary>
    /// <param name="paramName ">не найденное название поля</param>
    /// <param name="value">не найденный объект объект</param>
    public EntityNotFoundException(string paramName, object value) : base(string.Format(ErrorMessages.NotFound, typeof(TEntity).Name, paramName, value))
    {
    }
}