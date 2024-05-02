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
    public Address ValidateAddress()
    {
        Guard.Against.NullOrEmpty(City, nameof(City));
        Guard.Against.NullOrEmpty(Street, nameof(Street));
        Guard.Against.Null(NumberHouse, nameof(NumberHouse));
        
        return this;
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