using EduHub.StudentService.Application.Services.Dto.Enrollment;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Shared.Tests.Infrastructure.TestedData;
using EduHub.StudentService.Tests.Integrations.Fixture;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace EduHub.StudentService.Tests.Integrations.Tests.EnrollmentService;

[Collection(nameof(InfrastructureCollection))]
public class EnrollmentServicePositiveTests 
{
    private readonly InfrastructureFixture _fixture;
    private readonly IEnrollmentService _enrollmentService;
    private readonly IEnrollmentRepository _enrollmentRepository;
    
    public EnrollmentServicePositiveTests(InfrastructureFixture fixture)
    {
        _fixture = fixture;
        _enrollmentService = fixture.ServiceProvider.GetService<IEnrollmentService>();
        _enrollmentRepository = fixture.ServiceProvider.GetService<IEnrollmentRepository>();
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
        // Arrange
        var educator = await GenerateEntity.GenerateEducator(_fixture);
        var course = await GenerateEntity.GenerateCourse(_fixture, educator.Id);
        var student = await GenerateEntity.GenerateStudent(_fixture);
        var enrollment = new EnrollmentUpsertDto(date, student.Id, course.Id);
        
        // Act
        var result = await _enrollmentService.AddAsync(enrollment, CancellationToken.None);
        
        // Assert
        result.Should().NotBeNull();
        result.EnrollmentDate.Should().Be(date);
        result.StudentId.Should().Be(student.Id);
        result.CourseId.Should().Be(course.Id);
    }
    
    [Fact]
    public async Task GetStudentEnrollmentsAsync_ValidEnrollment()
    {
        // Arrange
        var educator = await GenerateEntity.GenerateEducator(_fixture);
        var course = await GenerateEntity.GenerateCourse(_fixture, educator.Id);
        var student = await GenerateEntity.GenerateStudent(_fixture);
        var enrollment = await GenerateEntity.GenerateEnrollment(_fixture, student.Id, course.Id);
        
        // Act
        var result = await _enrollmentService.GetStudentEnrollmentsAsync(student.Id, CancellationToken.None);
        
        // Assert
        result.Should().NotBeNull();
        result.Should().ContainSingle(e => e.Id == enrollment.Id);
    }
    
    [Fact]
    public async Task GetListEnrollmentAsync_ValidEnrollment()
    {
        // Arrange
        var educator = await GenerateEntity.GenerateEducator(_fixture);
        var course = await GenerateEntity.GenerateCourse(_fixture, educator.Id);
        var student = await GenerateEntity.GenerateStudent(_fixture);
        await GenerateEntity.GenerateEnrollment(_fixture, student.Id, course.Id);
        
        // Act
        var result = await _enrollmentService.GetListEnrollmentsAsync(CancellationToken.None);
        
        // Assert
        result.Should().NotBeNull();
        result.Should().NotBeEmpty();
    }
    
    [Fact]
    public async Task DeleteEnrollmentAsync_ValidEnrollment()
    {
        // Arrange
        var educator = await GenerateEntity.GenerateEducator(_fixture);
        var course = await GenerateEntity.GenerateCourse(_fixture, educator.Id);
        var student = await GenerateEntity.GenerateStudent(_fixture);
        var enrollment = await GenerateEntity.GenerateEnrollment(_fixture, student.Id, course.Id);
        
        // Act
        await _enrollmentService.DeleteAsync(enrollment.Id, CancellationToken.None);
        
        // Assert
        var exists = await _enrollmentRepository.ExistAsync(enrollment.Id);
        exists.Should().BeFalse();
    }
}