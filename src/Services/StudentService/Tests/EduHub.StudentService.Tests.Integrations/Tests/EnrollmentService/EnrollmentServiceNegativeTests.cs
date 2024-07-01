using EduHub.StudentService.Application.Services.Dto.Enrollment;
using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Shared.Tests.Infrastructure.TestedData;
using EduHub.StudentService.Tests.Integrations.Fixture;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace EduHub.StudentService.Tests.Integrations.Tests.EnrollmentService;

public class EnrollmentServiceNegativeTests : IClassFixture<InfrastructureFixture>
{
    private readonly InfrastructureFixture _infrastructure;
    private readonly IEnrollmentService _enrollmentService;
    
    public EnrollmentServiceNegativeTests(InfrastructureFixture infrastructure)
    {
        _infrastructure = infrastructure;
        _enrollmentService = _infrastructure.ServiceProvider.GetService<IEnrollmentService>();
    }
    
    [Theory]
    [ClassData(typeof(TestEnrollmentDataClass))]
    public async Task AddAsyncEnrollment_NotFoundCourse(
        Guid id,
        DateOnly date,
        Guid StudentId,
        Guid CourseId)
    {
        // Arrange
        var educator = await GenerateEntity.GenerateEducator(_infrastructure);
        await GenerateEntity.GenerateCourse(_infrastructure, educator.Id);
        var student = await GenerateEntity.GenerateStudent(_infrastructure);
        var enrollment = new EnrollmentUpsertDto(date, student.Id, Guid.NewGuid());
        
        // Act
        Func<Task> act = async () => await _enrollmentService.AddAsync(enrollment, CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Enrollment>>();
    }
    
    [Theory]
    [ClassData(typeof(TestEnrollmentDataClass))]
    public async Task AddAsyncEnrollment_NotFoundStudent(
        Guid id,
        DateOnly date,
        Guid StudentId,
        Guid CourseId)
    {
        // Arrange
        var educator = await GenerateEntity.GenerateEducator(_infrastructure);
        var course = await GenerateEntity.GenerateCourse(_infrastructure, educator.Id);
        await GenerateEntity.GenerateStudent(_infrastructure);
        var enrollment = new EnrollmentUpsertDto(date, Guid.NewGuid(), course.Id);
        
        // Act
        Func<Task> act = async () => await _enrollmentService.AddAsync(enrollment, CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Student>>();
    }
    
    [Fact]
    public async Task GetStudentEnrollmentsAsync_NotFound()
    {
        // Arrange & Act
        Func<Task> act = async () => await _enrollmentService.GetStudentEnrollmentsAsync(Guid.NewGuid(), CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Student>>();
    }
    
    [Fact]
    public async Task DeleteAsyncEnrollment_NotFoundStudent()
    {
        // Arrange & Act
        Func<Task> act = async () => await _enrollmentService.DeleteAsync(Guid.NewGuid(), CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Enrollment>>();
    }
}