using Ardalis.GuardClauses;
using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Domain.ValueObjects;

/// <summary>
/// Сущность, которая используется для установки номера в моделях и для системного валидирования
/// </summary>
public class Phone : BaseValueObject
{
    /// <summary>
    /// Устанавливаем номер
    /// </summary>
    /// <param name="value">Номер телефона</param>
    public Phone(string value)
    {
        Value = Guard.Against.NullOrEmpty(value);
    }
    
    private Phone()
    {
    }
    
    /// <summary>
    /// Номер телефона 
    /// </summary>
    public string Value { get; }
}