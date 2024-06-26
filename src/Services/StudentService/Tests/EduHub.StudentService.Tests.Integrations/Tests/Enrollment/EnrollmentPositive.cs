using EduHub.StudentService.Application.Services.Dto.Enrollment;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Shared.Tests.Infrastructure.TestedData;
using EduHub.StudentService.Tests.Integrations.Fixture;
using Microsoft.Extensions.DependencyInjection;

namespace EduHub.StudentService.Tests.Integrations.Tests.Enrollment;

public class EnrollmentPositive : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _database;
    private readonly IEnrollmentService _enrollmentService;
    private readonly IEnrollmentRepository _enrollmentRepository;
    
    public EnrollmentPositive(DatabaseFixture database)
    {
        _database = database;
        _enrollmentService = database.ServiceProvider.GetService<IEnrollmentService>();
        _enrollmentRepository = database.ServiceProvider.GetService<IEnrollmentRepository>();
    }
    
    [Theory]
    [ClassData(typeof(TestEnrollmentDataClass))]
    public async Task AddAsync_ValidEnrollment(
        Guid id,
        DateOnly date,
        Guid StudentId,
        Guid CourseId
    )
    {
        //Arrange
        var educator = await GenerateEntity.GenerateEducator(_database);
        var course = await GenerateEntity.GenerateCourse(_database, educator.Id);
        var student = await GenerateEntity.GenerateStudent(_database);
        var enrollment = new EnrollmentCreateDto(date, student.Id, course.Id);
        
        //Act
        var result = await _enrollmentService.AddAsync(enrollment, CancellationToken.None);
        
        //Assert
        Assert.NotNull(result);
        Assert.Equal(date, result.EnrollmentDate);
        Assert.Equal(student.Id, result.StudentId);
        Assert.Equal(course.Id, result.CourseId);
    }
    
    [Fact]
    public async Task GetStudentEnrollmentsAsync_ValidEnrollment()
    {
        //Arrange
        var educator = await GenerateEntity.GenerateEducator(_database);
        var course = await GenerateEntity.GenerateCourse(_database, educator.Id);
        var student = await GenerateEntity.GenerateStudent(_database);
        var enrollment = await GenerateEntity.GenerateEnrollment(_database, student.Id, course.Id);
        
        //Act
        var result = await _enrollmentService.GetStudentEnrollmentsAsync(enrollment.Id, CancellationToken.None);
        
        //Assert
        Assert.NotNull(result);
    }
    
    [Fact]
    public async Task GetListEnrollmentAsync_ValidEnrollment()
    {
        //Arrange
        var educator = await GenerateEntity.GenerateEducator(_database);
        var course = await GenerateEntity.GenerateCourse(_database, educator.Id);
        var student = await GenerateEntity.GenerateStudent(_database);
        await GenerateEntity.GenerateEnrollment(_database, student.Id, course.Id);
        
        //Act
        var result = await _enrollmentService.GetListEnrollmentsAsync(CancellationToken.None);
        
        //Assert
        Assert.NotNull(result);
    }
    
    [Fact]
    public async Task DeleteEnrollmentAsync_ValidEnrollment()
    {
        //Arrange
        var educator = await GenerateEntity.GenerateEducator(_database);
        var course = await GenerateEntity.GenerateCourse(_database, educator.Id);
        var student = await GenerateEntity.GenerateStudent(_database);
        var enrollment = await GenerateEntity.GenerateEnrollment(_database, student.Id, course.Id);
        
        //Act
        await _enrollmentService.DeleteAsync(enrollment.Id, CancellationToken.None);
        
        //Asssert
        Assert.False(await _enrollmentRepository.ExistAsync(enrollment.Id));
    }
}