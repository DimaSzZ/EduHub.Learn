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
    /// <param name="emailValue"></param>
    public Email(string emailValue)
    {
        Value = Guard.Against.NullOrEmpty(emailValue);;
    }
    
    public string Value { get; }
}