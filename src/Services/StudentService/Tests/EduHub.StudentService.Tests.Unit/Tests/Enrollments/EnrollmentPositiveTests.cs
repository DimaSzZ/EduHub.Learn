using Unit.Infrastructure.TestedData;

namespace Unit.Tests.Enrollments
{
    public class EnrollmentPositiveTests
    {
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
