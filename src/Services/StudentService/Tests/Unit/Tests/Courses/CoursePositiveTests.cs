using System.Collections;

namespace Unit.Tests.Courses;


public class TestCourseDataClass : IEnumerable<object[]>
{
    private readonly Faker _faker = new Faker();
    private readonly DateOnly _minBirthDate = new DateOnly(1900, 1, 1);
    
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            _faker.Random.Guid(),
            _faker.Random.String(),
            _faker.Random.String(),
            _faker.Random.Guid()
        };
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
public class CoursePositiveTests
{
    [Theory]
    [ClassData(typeof(TestCourseDataClass))]
    public void SetCourse_WithValidData_ShouldBeValid(
        Guid id,
        string name,
        string description,
        Guid educatorId)
    {
        var course = new Course(id,name,description,educatorId);
        
        course.Id.Should().NotBeEmpty();
        course.Name.Should().NotBeEmpty();
        course.Description.Should().NotBeEmpty();
        course.EducatorId.Should().NotBeEmpty();
    }
    
    [Theory]
    [ClassData(typeof(TestCourseDataClass))]
    public void UpdateCourse_WithValidData_ShouldBeValid(
        Guid id,
        string name,
        string description,
        Guid educatorId)
    {
        var course = new Course(id,name,description,educatorId);
        course.Update(name,description,educatorId);
        
        course.Id.Should().NotBeEmpty();
        course.Name.Should().NotBeEmpty();
        course.Description.Should().NotBeEmpty();
        course.EducatorId.Should().NotBeEmpty();
    }
    
    [Theory]
    [ClassData(typeof(TestCourseDataClass))]
    public void SetCourse_WithValidData_ShouldBeEquivalent(
        Guid id,
        string name,
        string description,
        Guid educatorId)
    {
        var course = new Course(id, name, description, educatorId);
        var course2 = new Course(id, name, description, educatorId);
        
        course.Should().BeEquivalentTo(course2);
    }
    
    [Theory]
    [ClassData(typeof(TestCourseDataClass))]
    public void UpdateCourse_WithValidData_ShouldBeEquivalent(
        Guid id,
        string name,
        string description,
        Guid educatorId)
    {
        var course = new Course(id, name, description, educatorId);
        course.Update(name,description,educatorId);
        var course2 = new Course(id, name, description, educatorId);
        course2.Update(name,description,educatorId);
        
        course.Should().BeEquivalentTo(course2);
    }
}