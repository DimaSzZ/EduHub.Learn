using System.Collections;

namespace Unit.Infrastructure.TestedData;

/// <summary>
/// Класс генератор для позитивных тестов Enrollment
/// </summary>
public class TestEnrollmentDataClass : IEnumerable<object[]>
{
    private readonly Faker _faker = new Faker(); 
    private readonly DateOnly _minDate = new DateOnly(1900, 1, 1); 
    
    // Реализация метода GetEnumerator для предоставления данных для тестов
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            _faker.Random.Guid(),
            _faker.Date.BetweenDateOnly(_minDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)), 
            _faker.Random.Guid(), 
            _faker.Random.Guid() 
        };
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}