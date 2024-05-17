using Unit.Infrastructure;

namespace Unit.Tests.Enrollments
{
    public class EnrollmentNegativeTests
    {
        // Определяем статическое поле, содержащее набор тестовых данных, полученных из класса TestedClass
        public static readonly IEnumerable<object[]> EnrollmentProperties = TestedClass.GetEnrollmentProperties();
        
        // Атрибут Theory указывает на теоретический тест, который будет запущен с несколькими наборами данных
        // MemberData атрибут указывает, что наборы данных для теста берутся из статического поля EnrollmentProperties
        [Theory]
        [MemberData(nameof(EnrollmentProperties))]
        public void SetEnrollment_WithNullData_ShouldBeInvalid(
            Guid id,
            DateOnly enrollmentDate,
            Guid studentId,
            Guid courseId
        )
        {
            var enrollment = () => new Enrollment(id, enrollmentDate, studentId, courseId);
            
            enrollment.Should().Throw<ArgumentException>();
        }
    }
}