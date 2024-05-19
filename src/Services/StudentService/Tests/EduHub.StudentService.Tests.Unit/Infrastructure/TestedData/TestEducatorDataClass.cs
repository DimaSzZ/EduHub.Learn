using System.Collections;

namespace Unit.Infrastructure.TestedData;

/// <summary>
/// Класс генератор для позитивных тестов Educator
/// </summary>
public class TestEducatorDataClass : IEnumerable<object[]>
{
    private readonly Faker _faker = new Faker(); 
    private readonly DateOnly _minBirthDate = new DateOnly(1900, 1, 1); 
    
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            _faker.Random.Guid(), 
            new FullName(_faker.Name.FirstName(), _faker.Name.LastName(), _faker.Name.LastName()), 
            EnumGenerator.GetRandomNonDefaultGender(), 
            new Phone(_faker.Phone.PhoneNumber()),
            _faker.Random.Byte(0, 60), 
            _faker.Date.BetweenDateOnly(_minBirthDate,
                new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
        };
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}