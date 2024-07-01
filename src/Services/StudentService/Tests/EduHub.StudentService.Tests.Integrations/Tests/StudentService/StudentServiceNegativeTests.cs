using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Shared.Tests.Infrastructure.TestedData;
using EduHub.StudentService.Tests.Integrations.Fixture;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace EduHub.StudentService.Tests.Integrations.Tests.StudentService;

using Domain.Entities;

public class StudentServiceNegativeTests : IClassFixture<InfrastructureFixture>
{
    private readonly InfrastructureFixture _infrastructure;
    private readonly IStudentService _studentService;
    private readonly TestStudentDataClass _studentGenerate;
    
    public StudentServiceNegativeTests(InfrastructureFixture infrastructure)
    {
        _infrastructure = infrastructure;
        _studentService = _infrastructure.ServiceProvider.GetRequiredService<IStudentService>();
        _studentGenerate = new TestStudentDataClass();
    }
    
    [Fact]
    public async Task UpdateAsync_NotFound()
    {
        // Arrange
        var studentUpdateDto = _studentGenerate.GetUpsertDto();
        
        // Act
        Func<Task> act = async () => await _studentService.UpdateAsync(Guid.NewGuid(), studentUpdateDto, CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<EntityNotFoundException<Student>>();
    }
    
    [Fact]
    public async Task DeleteAsync_NotFound()
    {
        // Arrange & Act
        Func<Task> act = async () => await _studentService.DeleteAsync(Guid.NewGuid(), CancellationToken.None);
        
        // Assert
        await act.Should().ThrowAsync<EntityNotFoundException<Student>>();
    }
}