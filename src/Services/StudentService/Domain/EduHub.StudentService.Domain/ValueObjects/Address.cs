using Ardalis.GuardClauses;
using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Domain.ValueObjects;

/// <summary>
/// Сущность, которая используется для установки адресса в моделях и для системного валидирования
/// </summary>
public class Address : BaseValueObject
{
    /// <summary>
    /// Принимает данные
    /// </summary>
    /// <param name="city">название города</param>
    /// <param name="street">название улицы</param>
    /// <param name="numberHouse">номер дома</param>
    public Address(string city, string street, int numberHouse)
    {
        City = Guard.Against.NullOrEmpty(city);
        Street = Guard.Against.NullOrEmpty(street);
        NumberHouse = Guard.Against.Null(numberHouse);
    }
    
    public Address()
    {
    }
    
    /// <summary>
    /// Название города
    /// </summary>
    public string City { get; }
    
    /// <summary>
    /// Название улыцы
    /// </summary>
    public string Street { get; }
    
    /// <summary>
    /// Номер дома
    /// </summary>
    public int NumberHouse { get; }
}