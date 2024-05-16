using Unit.Infrastructure;

namespace Unit.Tests.Enrollments;

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
        var enrollment = () => new Enrollment(id, enrollmentDate, studentId, courseId);
        enrollment.Should().Throw<ArgumentException>();
    }
}