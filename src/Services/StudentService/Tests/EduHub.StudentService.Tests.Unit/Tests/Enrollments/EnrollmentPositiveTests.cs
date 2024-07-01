

using EduHub.StudentService.Shared.Tests.Infrastructure.TestedData;

namespace Unit.Tests.Enrollments
{
    /// <summary>
    /// Позитивные тесты для сущностей Enrollment
    /// </summary>
    public class EnrollmentPositiveTests
    {
        /// <summary>
        /// Тест исключений при создании Enrollment
        /// </summary>
        /// <param name="id">Валидность id</param>
        /// <param name="enrollmentDate">Валидность даты зачисления</param>
        /// <param name="studentId">Валидность id студента</param>
        /// <param name="courseId">Валидность id курса</param>
        [Theory]
        [ClassData(typeof(TestEnrollmentDataClass))]
        public void SetEnrollment_WithValidData_ShouldBeValid(
            Guid id,
            DateOnly enrollmentDate,
            Guid studentId,
            Guid courseId)
        {
            // Arrange: Подготовка данных
            // Данные передаются через параметризованный тест, данные уже подготовлены
            
            // Act: Создание объекта Enrollment с переданными параметрами
            var enrollment = new Enrollment(id, enrollmentDate, studentId, courseId);
            
            // Assert: Проверка, что все свойства объекта заданы правильно
            enrollment.Id.Should().NotBeEmpty(); // Id не должен быть пустым
            enrollment.EnrollmentDate.Should().NotBe(default); // Дата зачисления не должна быть значением по умолчанию
            enrollment.StudentId.Should().NotBeEmpty(); // studentId не должен быть пустым
            enrollment.CourseId.Should().NotBeEmpty(); // courseId не должен быть пустым
        }
        
        /// <summary>
        /// Тест исключения на эквивалетность 2 одинаковых Enrollment
        /// </summary>
        /// <param name="id">Валидность Id</param>
        /// <param name="enrollmentDate">Валидность зачисления</param>
        /// <param name="studentId">Валидность id студента</param>
        /// <param name="courseId">Валидность id курса</param>
        [Theory]
        [ClassData(typeof(TestEnrollmentDataClass))]
        public void SetEnrollment_WithValidData_ShouldBeEquivalent(
            Guid id,
            DateOnly enrollmentDate,
            Guid studentId,
            Guid courseId)
        {
            // Arrange: Подготовка данных
            // Данные передаются через параметризованный тест, данные уже подготовлены
            
            // Act: Создание двух объектов Enrollment с одинаковыми параметрами
            var enrollment = new Enrollment(id, enrollmentDate, studentId, courseId);
            var enrollment2 = new Enrollment(id, enrollmentDate, studentId, courseId);
            
            // Assert: Проверка, что оба объекта эквивалентны
            enrollment.Should().BeEquivalentTo(enrollment2);
        }
    }
}
