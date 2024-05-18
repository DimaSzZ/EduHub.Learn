using System.Collections;

namespace Unit.Infrastructure.TestedData;

// Класс, реализующий IEnumerable<object[]> для предоставления данных для тестов
public class TestCourseDataClass : IEnumerable<object[]>
{
    // Реализация метода GetEnumerator для предоставления данных для тестов
    public IEnumerator<object[]> GetEnumerator()
    {
        var faker = new Faker(); // Используем библиотеку Faker для генерации случайных данных
        yield return new object[]
        {
            faker.Random.Guid(), // Генерация случайного GUID для id
            faker.Random.String2(10), // Генерация случайной строки длиной 10 символов для name
            faker.Random.String2(10), // Генерация случайной строки длиной 10 символов для description
            faker.Random.Guid() // Генерация случайного GUID для educatorId
        };
    }
    
    // Реализация неявного метода IEnumerable.GetEnumerator
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}