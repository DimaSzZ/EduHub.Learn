namespace Unit.Tests.Enrollments;

public class EnrollmentNegativeTests
{
    public static readonly IEnumerable<object[]> EnrollmentProperties = GetEnrollmentProperties();
    private static readonly Faker Faker = new Faker();
    private static readonly DateOnly MinDate = new DateOnly(1900, 1, 1);
    
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
        enrollment.Should().Throw<Exception>();
    }
    
    private static IEnumerable<object[]> GetEnrollmentProperties()
    {
        return new List<object[]>
        {
            new object[] {
                Guid.Empty,  Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
                ,Guid.NewGuid(), Guid.NewGuid()},
            
            new object[] {
                Guid.Empty,  default, Guid.NewGuid(), Guid.NewGuid()},
            
            new object[] {
                Guid.NewGuid(), Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
                Guid.Empty, Guid.NewGuid()},
            
            new object[] {
                Guid.NewGuid(), Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
                Guid.NewGuid(), Guid.Empty},
        };
    }
}