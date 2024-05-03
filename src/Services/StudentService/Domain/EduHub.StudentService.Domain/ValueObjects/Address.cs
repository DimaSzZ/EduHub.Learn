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
        Guard.Against.NullOrEmpty(city);
        Guard.Against.NullOrEmpty(street);
        Guard.Against.Null(numberHouse);
        
        City = city;
        Street = street;
        NumberHouse = numberHouse;
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