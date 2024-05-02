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
    public string ValidateEmail(Email email)
    {
        Guard.Against.NullOrEmpty(email.EmailValue,nameof(email.ValidateEmail));
        return email.EmailValue;
    }
    
    public string EmailValue { get; }
}