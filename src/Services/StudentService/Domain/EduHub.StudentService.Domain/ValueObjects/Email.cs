using Ardalis.GuardClauses;
using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Domain.ValueObjects;

/// <summary>
/// ущность, которая используется для установки E-Mail в моделях и для системного валидирования
/// </summary>
public class Email : BaseValueObject
{
    /// <summary>
    /// конструктор которые принимает почтовый ящик
    /// </summary>
    /// <param name="value"></param>
    public Email(string value)
    {
        Value = Guard.Against.NullOrEmpty(value);
    }
    
    public Email()
    {
    }
    
    public string Value { get; }
}