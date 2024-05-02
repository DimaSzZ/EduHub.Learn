using Ardalis.GuardClauses;
using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Domain.ValueObjects;

/// <summary>
/// ущность, которая используется для установки E-Mail в моделях и для системного валидирования
/// </summary>
public class Email : BaseValueObject
{
    public Email(string emailValue)
    {
        EmailValue = emailValue;
    }
    
    /// <summary>
    /// Свойство для валидации E-mail
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public Email ValidateEmail()
    {
        Guard.Against.NullOrEmpty(EmailValue, nameof(ValidateEmail));
        return this;
    }
    
    public string EmailValue { get; }
}