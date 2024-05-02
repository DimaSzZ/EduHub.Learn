using Ardalis.GuardClauses;
using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Domain.ValueObjects;

/// <summary>
/// Сущность, которая используется для установки номера в моделях и для системного валидирования
/// </summary>
public class Phone : BaseValueObject
{
    /// <summary>
    /// Устанавливаем неочищенный номер
    /// </summary>
    /// <param name="phoneNumber"></param>
    public Phone(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }

    /// <summary>
    /// Вадируем номер
    /// </summary>
    /// <param name="phone"></param>
    /// <returns></returns>
    public string ValidateFullName(Phone phone)
    {
        Guard.Against.NullOrEmpty(phone.PhoneNumber,nameof(phone.PhoneNumber));
        return phone.PhoneNumber;
    }
    /// <summary>
    /// Номер телефона (не очищенный)
    /// </summary>
    public string PhoneNumber { get; }
}