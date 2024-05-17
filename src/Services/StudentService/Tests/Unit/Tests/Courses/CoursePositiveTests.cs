using System.Collections; 

namespace Unit.Tests.Courses
{
    // Класс, реализующий IEnumerable<object[]> для предоставления данных для тестов
    public class TestCourseDataClass : IEnumerable<object[]>
    {
        private readonly Faker _faker = new Faker(); // Используем библиотеку Faker для генерации случайных данных
        private readonly DateOnly _minBirthDate = new DateOnly(1900, 1, 1); // Минимальная дата для генерации случайных дат (не используется)

        // Реализация метода GetEnumerator для предоставления данных для тестов
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                _faker.Random.Guid(), // Генерация случайного GUID для id
                _faker.Random.String2(10), // Генерация случайной строки длиной 10 символов для name
                _faker.Random.String2(10), // Генерация случайной строки длиной 10 символов для description
                _faker.Random.Guid() // Генерация случайного GUID для educatorId
            };
        }

        // Реализация неявного метода IEnumerable.GetEnumerator
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class CoursePositiveTests
    {
        // Тест на создание курса с валидными данными
        [Theory]
        [ClassData(typeof(TestCourseDataClass))]
        public void SetCourse_WithValidData_ShouldBeValid(
            Guid id,
            string name,
            string description,
            Guid educatorId)
        {
            // Создание экземпляра Course с валидными данными
            var course = new Course(id, name, description, educatorId);
            
            // Проверка свойств на валидность
            course.Id.Should().NotBeEmpty();
            course.Name.Should().NotBeEmpty();
            course.Description.Should().NotBeEmpty();
            course.EducatorId.Should().NotBeEmpty();
        }

        // Тест на обновление курса с валидными данными
        [Theory]
        [ClassData(typeof(TestCourseDataClass))]
        public void UpdateCourse_WithValidData_ShouldBeValid(
            Guid id,
            string name,
            string description,
            Guid educatorId)
        {
            // Создание экземпляра Course с валидными данными
            var course = new Course(id, name, description, educatorId);
            
            // Обновление свойств Course
            course.Update(name, description, educatorId);
            
            // Проверка свойств на валидность после обновления
            course.Id.Should().NotBeEmpty();
            course.Name.Should().NotBeEmpty();
            course.Description.Should().NotBeEmpty();
            course.EducatorId.Should().NotBeEmpty();
        }

        // Тест на эквивалентность двух экземпляров Course с одинаковыми данными
        [Theory]
        [ClassData(typeof(TestCourseDataClass))]
        public void SetCourse_WithValidData_ShouldBeEquivalent(
            Guid id,
            string name,
            string description,
            Guid educatorId)
        {
            // Создание двух экземпляров Course с одинаковыми данными
            var course = new Course(id, name, description, educatorId);
            var course2 = new Course(id, name, description, educatorId);
            
            // Проверка на эквивалентность
            course.Should().BeEquivalentTo(course2);
        }

        // Тест на эквивалентность двух экземпляров Course после обновления с одинаковыми данными
        [Theory]
        [ClassData(typeof(TestCourseDataClass))]
        public void UpdateCourse_WithValidData_ShouldBeEquivalent(
            Guid id,
            string name,
            string description,
            Guid educatorId)
        {
            // Создание двух экземпляров Course с одинаковыми данными
            var course = new Course(id, name, description, educatorId);
            course.Update(name, description, educatorId); // Обновление свойств первого экземпляра
            var course2 = new Course(id, name, description, educatorId);
            course2.Update(name, description, educatorId); // Обновление свойств второго экземпляра
            
            // Проверка на эквивалентность после обновления
            course.Should().BeEquivalentTo(course2);
        }
    }
}
