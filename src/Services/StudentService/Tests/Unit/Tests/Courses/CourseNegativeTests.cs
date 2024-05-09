namespace Unit.Tests.Courses;

public class CourseNegativeTests
{
    public static readonly IEnumerable<object[]> CourseProperties = GetCourseProperties();
    private static readonly Faker Faker = new Faker();
    
    [Theory]
    [MemberData(nameof(CourseProperties))]
    public void SetEnrollment_WithNullData_ShouldBeInvalid(
        Guid id,
        string name,
        string description,
        Guid enrollmentId)
    {
        var course = () => new Course(id, name, description, enrollmentId);
        course.Should().Throw<Exception>();
    }
    
    [Theory]
    [MemberData(nameof(CourseProperties))]
    public void UpdateEnrollment_WithNullData_ShouldBeInvalid(
        Guid id,
        string name,
        string description,
        Guid enrollmentId)
    {
        var course = () => new Course(id, name, description, enrollmentId).Update(name,description,enrollmentId);
        course.Should().Throw<Exception>();
    }
    
    private static IEnumerable<object[]> GetCourseProperties()
    {
        return new List<object[]>
        {
            new object[] {
                Guid.Empty,Faker.Random.String(),Faker.Random.String(), Guid.NewGuid()},
            
            new object[] {
                Guid.NewGuid(),null,Faker.Random.String(), Guid.NewGuid()},
            
            new object[] {
                Guid.NewGuid(),Faker.Random.String(),null, Guid.NewGuid()},
            
            new object[] {
                Guid.NewGuid(),Faker.Random.String(),Faker.Random.String(), Guid.Empty},
        };
    }
}