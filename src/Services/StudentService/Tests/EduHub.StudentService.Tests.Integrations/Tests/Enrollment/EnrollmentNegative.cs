using EduHub.StudentService.Application.Services.Dto.Enrollment;
using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Shared.Tests.Infrastructure.TestedData;
using EduHub.StudentService.Tests.Integrations.Fixture;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace EduHub.StudentService.Tests.Integrations.Tests.Enrollment;

public class EnrollmentNegative : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _database;
    private readonly IEnrollmentService _enrollmentService;
    
    public EnrollmentNegative(DatabaseFixture database)
    {
        _database = database;
        _enrollmentService = _database.ServiceProvider.GetService<IEnrollmentService>();
    }
    
    [Theory]
    [ClassData(typeof(TestEnrollmentDataClass))]
    public async Task AddAsyncEnrollment_NotFoundCourse(
        Guid id,
        DateOnly date,
        Guid StudentId,
        Guid CourseId)
    {
        //Arrange
        var educator = await GenerateEntity.GenerateEducator(_database);
        await GenerateEntity.GenerateCourse(_database, educator.Id);
        var student = await GenerateEntity.GenerateStudent(_database);
        var enrollment = new EnrollmentCreateDto(date, student.Id, Guid.NewGuid());
        
        //Act
        var resp = async () => await _enrollmentService.AddAsync(enrollment, CancellationToken.None);
        
        //Assert
        await resp.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Course>>();
    }
    
    [Theory]
    [ClassData(typeof(TestEnrollmentDataClass))]
    public async Task AddAsyncEnrollment_NotFoundStudent(
        Guid id,
        DateOnly date,
        Guid StudentId,
        Guid CourseId)
    {
        //Arrange
        var educator = await GenerateEntity.GenerateEducator(_database);
        var course = await GenerateEntity.GenerateCourse(_database, educator.Id);
        await GenerateEntity.GenerateStudent(_database);
        var enrollment = new EnrollmentCreateDto(date, Guid.NewGuid(), course.Id);
        
        //Act
        var resp = async () => await _enrollmentService.AddAsync(enrollment, CancellationToken.None);
        
        //Assert
        await resp.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Student>>();
    }
    
    [Fact]
    public async Task GetStudentEnrollmentsAsync_NotFound()
    {
        //Arrange & Act
        var resp = async () => await _enrollmentService.GetStudentEnrollmentsAsync(Guid.NewGuid(), CancellationToken.None);
        
        //Assert
        await resp.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Student>>();
    }
    
   [Fact]
    public async Task DeleteAsyncEnrollment_NotFoundStudent()
    {
        //Arrange & Act
        var resp = async () => await _enrollmentService.DeleteAsync(Guid.NewGuid(), CancellationToken.None);
        
        //Assert
        await resp.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Enrollment>>();
    }
}