using Unit.Infrastructure;

namespace Unit.Tests.Students;

public class StudentNegativeTests
{
    public static readonly IEnumerable<object[]> StudentProperties = TestedClass.GetStudentProperties();
        
    [Theory]
    [MemberData(nameof(StudentProperties))]
    public void SetStudent_WithNullData_ShouldBeInvalid(
        Guid id,
        string avatar,
        FullName fullName,
        Gender gender,
        DateOnly dateBirth,
        Email email,
        Phone phone,
        Address address)
    {
        var student = () => new Student(id,avatar,fullName,gender,dateBirth,email,phone,address);
        student.Should().Throw<ArgumentException>();
    }
}