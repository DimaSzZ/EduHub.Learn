using System.Collections; 

namespace Unit.Tests.Educators
{
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
                GetRandomNonDefaultGender(), // Получение случайного пола, отличного от значения по умолчанию
                new Phone(_faker.Phone.PhoneNumber()), // Генерация случайного телефонного номера
                _faker.Random.Byte(0, 60), // Генерация случайного числа типа byte для опыта работы
                _faker.Date.BetweenDateOnly(_minBirthDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)) // Генерация случайной даты трудоустройства
            };
        }
        
        // Метод для генерации случайного пола, отличного от значения по умолчанию
        private Gender GetRandomNonDefaultGender()
        {
            var genders = Enum.GetValues(typeof(Gender)).Cast<Gender>()
                .Where(g => g != Gender.Default).ToArray();
            return _faker.Random.ArrayElement(genders);
        }
        
        // Реализация неявного метода IEnumerable.GetEnumerator
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    // Класс для тестирования позитивных сценариев для объекта Educator
    public class EducatorPositiveTests
    {
        // Тест на создание объекта Educator с валидными данными
        [Theory]
        [ClassData(typeof(TestEducatorDataClass))]
        public void SetEducator_WithValidData_ShouldBeValid(
            Guid id,
            FullName fullName,
            Gender gender,
            Phone phone,
            int workExp,
            DateOnly dateEmployment)
        {
            // Создание экземпляра Educator с валидными данными
            var educator = new Educator(id, fullName, gender, phone, workExp, dateEmployment);
            
            // Проверка корректности создания объекта
            educator.Id.Should().NotBeEmpty(); // Проверка, что Id не пустой
            educator.FullName.Should().NotBeNull(); // Проверка, что FullName не null
            educator.Gender.Should().NotBe(Gender.Default); // Проверка, что Gender не равен значению по умолчанию
            educator.YearsExperience.Should().BeGreaterThan(-1); // Проверка, что YearsExperience не отрицательный
            educator.DateEmployment.Should().NotBe(default); // Проверка, что DateEmployment не равен значению по умолчанию
            educator.Phone.Should().NotBeNull().And.BeOfType<Phone>(); // Проверка, что Phone не null и имеет тип Phone
        }
    }
}
