using System.Collections;

namespace Unit.Infrastructure.TestedData;

// Класс, реализующий IEnumerable<object[]> для предоставления данных для тестов
public class TestEnrollmentDataClass : IEnumerable<object[]>
{
    private readonly Faker _faker = new Faker(); // Используем библиотеку Faker для генерации случайных данных
    private readonly DateOnly _minDate = new DateOnly(1900, 1, 1); // Минимальная дата для генерации случайных дат
    
    // Реализация метода GetEnumerator для предоставления данных для тестов
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            _faker.Random.Guid(), // Генерация случайного GUID для id
            _faker.Date.BetweenDateOnly(_minDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)), // Генерация случайной даты между минимальной датой и текущей датой
            _faker.Random.Guid(), // Генерация случайного GUID для studentId
            _faker.Random.Guid() // Генерация случайного GUID для courseId
        };
    }
    
    // Реализация интерфейса IEnumerable
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}