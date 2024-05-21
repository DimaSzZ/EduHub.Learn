using System.Collections;

namespace Unit.Infrastructure.TestedData;

/// <summary>
/// Класс генератор для позитивных тестов Course
/// </summary>
public class TestCourseDataClass : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var faker = new Faker(); 
        yield return new object[]
        {
            faker.Random.Guid(), 
            faker.Random.String2(10), 
            faker.Random.String2(10), 
            faker.Random.Guid() 
        };
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}