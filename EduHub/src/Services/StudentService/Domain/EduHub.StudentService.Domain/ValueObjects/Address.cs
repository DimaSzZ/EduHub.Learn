using Ardalis.GuardClauses;
using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Domain.ValueObjects;

public class Address : BaseValueObject
{
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
    public string City { get; }
    
    public string Street { get; }
    
    public int NumberHouse { get; }
}