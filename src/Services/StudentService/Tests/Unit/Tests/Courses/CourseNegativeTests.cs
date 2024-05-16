using Unit.Infrastructure;

namespace Unit.Tests.Courses;

public class CourseNegativeTests
{
    public static readonly IEnumerable<object[]> CourseProperties = TestedClass.GetCourseProperties();
    
    [Theory]
    [MemberData(nameof(CourseProperties))]
    public void SetEnrollment_WithNullData_ShouldBeInvalid(
        Guid id,
        string name,
        string description,
        Guid educatorId)
    {
        var course = () => new Course(id, name, description, educatorId);
        course.Should().Throw<ArgumentException>();
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
        course.Should().Throw<ArgumentException>();
    }
}