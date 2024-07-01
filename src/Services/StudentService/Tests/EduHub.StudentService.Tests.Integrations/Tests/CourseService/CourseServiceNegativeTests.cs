using EduHub.StudentService.Application.Services.Dto.Course;
using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Shared.Tests.Infrastructure.TestedData;
using EduHub.StudentService.Tests.Integrations.Fixture;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace EduHub.StudentService.Tests.Integrations.Tests.CourseService;

using Domain.Entities;

public class CourseServiceNegativeTests : IClassFixture<InfrastructureFixture>
{
    private readonly InfrastructureFixture _infrastructure;
    private readonly ICourseService _courseService;
    
    public CourseServiceNegativeTests(InfrastructureFixture infrastructure)
    {
        _infrastructure = infrastructure;
        _courseService = _infrastructure.ServiceProvider.GetService<ICourseService>();
    }
    
    [Theory]
    [ClassData(typeof(TestCourseDataClass))]
    public async Task UpdateAsync_NonExistentCourse_ThrowsException(
        Guid id,
        string name,
        string description,
        Guid educatorId
    )
    {
        // Arrange
        var educator = await GenerateEntity.GenerateEducator(_infrastructure);
        await GenerateEntity.GenerateCourse(_infrastructure, educator.Id);
        var courseDto = new CourseUpsertDto(name, description, educator.Id);
        
        // Act
        var act = () => _courseService.UpdateAsync(id, courseDto, CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<EntityNotFoundException<Course>>();
    }
    
    [Fact]
    public async Task DeleteAsync_NonExistentId_ThrowsException()
    {
        //Arrange
        var guid = Guid.NewGuid();
        
        // Act
        var act = () => _courseService.DeleteAsync(guid, CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<EntityNotFoundException<Course>>();
    }
    
    [Fact]
    public async Task GetByIdAsync_NonExistentId_ThrowsException()
    {
        //Arrange
        var guid = Guid.NewGuid();
        
        // Act
        var act = () => _courseService.GetByIdAsync(guid, CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<EntityNotFoundException<Course>>();
    }
}