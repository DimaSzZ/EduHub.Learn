using Ardalis.GuardClauses;
using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Domain.ValueObjects;

/// <summary>
/// Сущность, которая используется для установки адресса в моделях и для системного валидирования
/// </summary>
public class Address : BaseValueObject
{
    /// <summary>
    /// Принимает неочищенные данные
    /// </summary>
    /// <param name="city"></param>
    /// <param name="street"></param>
    /// <param name="numberHouse"></param>
    public Address(string city, string street, int numberHouse)
    {
        City = city;
        Street = street;
        NumberHouse = numberHouse;
    }

    /// <summary>
    /// Производит валидацию данных
    /// </summary>
    /// <param name="address"></param>
    /// <returns></returns>
    public (string, string, int) ValidateAddress(Address address)
    {
        Guard.Against.NullOrEmpty(address.City, nameof(address.City));
        Guard.Against.NullOrEmpty(address.Street, nameof(address.Street));
        Guard.Against.Null(address.NumberHouse, nameof(address.NumberHouse));
        
        Guard.Against.OutOfRange(address.City.Length, nameof(address.City), 4, 100);
        Guard.Against.OutOfRange(address.Street.Length, nameof(address.Street), 4, 100);
        Guard.Against.OutOfRange(address.NumberHouse, nameof(address.NumberHouse), 1, 20000);

        return (address.City,address.Street,address.NumberHouse);
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