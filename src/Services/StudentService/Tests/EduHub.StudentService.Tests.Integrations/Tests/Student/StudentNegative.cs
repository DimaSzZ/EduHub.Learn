using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Shared.Tests.Infrastructure.TestedData;
using EduHub.StudentService.Tests.Integrations.Fixture;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace EduHub.StudentService.Tests.Integrations.Tests.Student;

public class StudentNegative : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _database;
    private readonly TestStudentDataClass _studentGenerate;
    private readonly IStudentService _studentService;
    
    public StudentNegative(DatabaseFixture database)
    {
        _database = database;
        _studentService = _database.ServiceProvider.GetRequiredService<IStudentService>();
        _studentGenerate = new TestStudentDataClass();
    }
    
    [Fact]
    public async Task UpdateAsync_NotFound()
    {
        //Arrange
        var studentUpdateDto = _studentGenerate.GetUpdateDto();
        
        //Act
        var result = async () => await _studentService.UpdateAsync(studentUpdateDto, CancellationToken.None);
        
        //Assertation
        await result.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Student>>();
    }
    
    [Fact]
    public async Task DeleteAsync_NotFound()
    {
        //Arrange & Act
        var result = async () => await _studentService.DeleteAsync(Guid.NewGuid(), CancellationToken.None);
        
        //Assertation
        await result.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Student>>();
    }
}