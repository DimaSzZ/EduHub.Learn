using System.Collections;

namespace Unit.Tests.Enrollments;

public class TestEnrollmentDataClass : IEnumerable<object[]>
{
    private readonly Faker _faker = new Faker();
    private readonly DateOnly _minDate = new DateOnly(1900, 1, 1);
    
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            _faker.Random.Guid(),
            _faker.Date.BetweenDateOnly(_minDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
            _faker.Random.Guid(),
            _faker.Random.Guid()
        };
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

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
        var enrollment = new Enrollment(id, enrollmentDate, studentId, courseId);
        
        enrollment.Id.Should().NotBeEmpty();
        enrollment.EnrollmentDate.Should().BeAfter(enrollmentDate);
        enrollment.StudentId.Should().NotBeEmpty();
        enrollment.CourseId.Should().NotBeEmpty();
    }
    
    [Theory]
    [ClassData(typeof(TestEnrollmentDataClass))]
    public void SetEnrollment_WithValidData_ShouldBeEquivalent(
        Guid id,
        DateOnly enrollmentDate,
        Guid studentId,
        Guid courseId)
    {
        var enrollment = new Enrollment(id, enrollmentDate, studentId, courseId);
        var enrollment2 = new Enrollment(id, enrollmentDate, studentId, courseId);
        
        enrollment.Should().BeEquivalentTo(enrollment2);
    }
}