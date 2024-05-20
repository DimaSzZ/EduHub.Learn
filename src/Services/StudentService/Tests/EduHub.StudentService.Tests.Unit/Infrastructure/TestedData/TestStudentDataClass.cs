using System.Collections;

namespace Unit.Infrastructure.TestedData;

/// <summary>
/// Класс генератор для позитивных тестов Student
/// </summary>
public class TestStudentDataClass : IEnumerable<object[]>
{
    private readonly Faker _faker = new Faker(); 
    private readonly DateOnly _minBirthDate = new DateOnly(1900, 1, 1); 
    
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            _faker.Random.Guid(), 
            _faker.Random.String(), 
            new FullName(_faker.Name.FirstName(), _faker.Name.LastName(), _faker.Name.LastName()),
            EnumGenerator.GetGender(), 
            _faker.Date.BetweenDateOnly(_minBirthDate,
                new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)), 
            new Email(_faker.Internet.Email()), 
            new Phone(_faker.Phone.PhoneNumber()), 
            new Address(_faker.Address.City(), _faker.Address.StreetName(), int.Parse(_faker.Address.BuildingNumber())) 
        };
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}