using System.Collections;

namespace Unit.Infrastructure.TestedData;

// Класс, реализующий IEnumerable<object[]> для предоставления данных для тестов
public class TestStudentDataClass : IEnumerable<object[]>
{
    private readonly Faker _faker = new Faker(); // Используем библиотеку Faker для генерации случайных данных
    private readonly DateOnly _minBirthDate = new DateOnly(1900, 1, 1); // Минимальная дата для генерации случайных дат рождения
    
    // Реализация метода GetEnumerator для предоставления данных для тестов
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            _faker.Random.Guid(), // Генерация случайного GUID для id
            _faker.Random.String(), // Генерация случайной строки для avatar
            new FullName(_faker.Name.FirstName(), _faker.Name.LastName(), _faker.Name.LastName()), // Генерация случайного полного имени
            EnumGenerator.GetRandomNonDefaultGender(), // Получение случайного значения пола, отличного от значения по умолчанию
            _faker.Date.BetweenDateOnly(_minBirthDate,
                new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)), // Генерация случайной даты между минимальной датой и текущей датой
            new Email(_faker.Internet.Email()), // Генерация случайного email
            new Phone(_faker.Phone.PhoneNumber()), // Генерация случайного номера телефона
            new Address(_faker.Address.City(), _faker.Address.StreetName(), int.Parse(_faker.Address.BuildingNumber())) // Генерация случайного адреса
        };
    }
    
    // Реализация интерфейса IEnumerable
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}