using Unit.Infrastructure;

namespace Unit.Tests.Courses;

public class CourseNegativeTests
{
    public static readonly IEnumerable<object[]> CourseProperties = TestedClass.GetStudentProperties();
    
    [Theory]
    [MemberData(nameof(CourseProperties))]
    public void SetEnrollment_WithNullData_ShouldBeInvalid(
        Guid id,
        string name,
        string description,
        Guid enrollmentId)
    {
        var course = () => new Course(id, name, description, enrollmentId);
        course.Should().Throw<ArgumentNullException>();
    }
    
    [Theory]
    [MemberData(nameof(CourseProperties))]
    public void UpdateEnrollment_WithNullData_ShouldBeInvalid(
        Guid id,
        string name,
        string description,
        Guid enrollmentId)
    {
        var course = () => new Course(id, name, description, enrollmentId).Update(name, description, enrollmentId);
        course.Should().Throw<ArgumentNullException>();
    }
}