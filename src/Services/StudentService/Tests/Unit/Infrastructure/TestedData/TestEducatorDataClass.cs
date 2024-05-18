using System.Collections;

namespace Unit.Infrastructure.TestedData;

// Класс для предоставления данных для тестов EducatorPositiveTests
public class TestEducatorDataClass : IEnumerable<object[]>
{
    private readonly Faker _faker = new Faker(); // Создаем экземпляр Faker для генерации случайных данных
    private readonly DateOnly _minBirthDate = new DateOnly(1900, 1, 1); // Минимальная дата рождения для генерации
    
    // Метод для предоставления данных для тестов
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            _faker.Random.Guid(), // Генерация случайного GUID для идентификатора
            new FullName(_faker.Name.FirstName(), _faker.Name.LastName(), _faker.Name.LastName()), // Генерация случайного полного имени
            EnumGenerator.GetRandomNonDefaultGender(), // Получение случайного пола, отличного от значения по умолчанию
            new Phone(_faker.Phone.PhoneNumber()), // Генерация случайного телефонного номера
            _faker.Random.Byte(0, 60), // Генерация случайного числа типа byte для опыта работы
            _faker.Date.BetweenDateOnly(_minBirthDate,
                new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)) // Генерация случайной даты трудоустройства
        };
    }
    
    // Реализация неявного метода IEnumerable.GetEnumerator
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}