using System.Collections; // Подключаем пространство имен для использования интерфейса IEnumerable

namespace Unit.Tests.Enrollments
{
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

    public class EnrollmentPositiveTests
    {
        // Теоретический тест, использующий данные из класса TestEnrollmentDataClass
        [Theory]
        [ClassData(typeof(TestEnrollmentDataClass))]
        public void SetEnrollment_WithValidData_ShouldBeValid(
            Guid id,
            DateOnly enrollmentDate,
            Guid studentId,
            Guid courseId)
        {
            // Создаем объект Enrollment с переданными параметрами
            var enrollment = new Enrollment(id, enrollmentDate, studentId, courseId);

            // Проверяем, что все свойства объекта заданы правильно
            enrollment.Id.Should().NotBeEmpty(); // Id не должен быть пустым
            enrollment.EnrollmentDate.Should().NotBe(default); // Дата зачисления не должна быть значением по умолчанию
            enrollment.StudentId.Should().NotBeEmpty(); // studentId не должен быть пустым
            enrollment.CourseId.Should().NotBeEmpty(); // courseId не должен быть пустым
        }

        // Теоретический тест, использующий данные из класса TestEnrollmentDataClass для проверки эквивалентности объектов
        [Theory]
        [ClassData(typeof(TestEnrollmentDataClass))]
        public void SetEnrollment_WithValidData_ShouldBeEquivalent(
            Guid id,
            DateOnly enrollmentDate,
            Guid studentId,
            Guid courseId)
        {
            // Создаем два объекта Enrollment с одинаковыми параметрами
            var enrollment = new Enrollment(id, enrollmentDate, studentId, courseId);
            var enrollment2 = new Enrollment(id, enrollmentDate, studentId, courseId);

            // Проверяем, что оба объекта эквивалентны
            enrollment.Should().BeEquivalentTo(enrollment2);
        }
    }
}
