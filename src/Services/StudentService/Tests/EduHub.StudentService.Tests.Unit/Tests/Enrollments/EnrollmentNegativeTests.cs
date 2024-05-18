using Unit.Infrastructure;

namespace Unit.Tests.Enrollments
{
    public class EnrollmentNegativeTests
    {
        public static readonly IEnumerable<object[]> EnrollmentProperties = TestedClass.GetEnrollmentProperties();
        
        [Theory]
        [MemberData(nameof(EnrollmentProperties))]
        public void SetEnrollment_WithNullData_ShouldBeInvalid(
            Guid id,
            DateOnly enrollmentDate,
            Guid studentId,
            Guid courseId
        )
        {
            // Arrange: Подготовка данных (данные передаются через параметризованный тест)
            
            // Act: Лямбда-выражение для создания объекта Enrollment с нулевыми данными
            var enrollment = () => new Enrollment(id, enrollmentDate, studentId, courseId);
            
            // Assert: Проверка, что при создании объекта Enrollment с нулевыми данными выбрасывается исключение ArgumentException
            enrollment.Should().Throw<ArgumentException>();
        }
    }
}