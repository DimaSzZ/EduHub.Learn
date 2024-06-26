using EduHub.StudentService.Application.Services.Dto.Course;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Tests.Integrations.Fixture;
using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Shared.Tests.Infrastructure;
using EduHub.StudentService.Shared.Tests.Infrastructure.TestedData;
using Microsoft.Extensions.DependencyInjection;

namespace EduHub.StudentService.Tests.Integrations.Tests.Course;

public class CourseNegative : IClassFixture<DatabaseFixture>
{
    public static readonly IEnumerable<object[]> CourseProperties = TestedClass.GetCourseProperties();
    
    private DatabaseFixture _database;
    private ICourseService _courseService;
    
    public CourseNegative(DatabaseFixture database)
    {
        _database = database;
        _courseService = _database.ServiceProvider.GetService<ICourseService>();
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
        var educator = await GenerateEntity.GenerateEducator(_database);
        await GenerateEntity.GenerateCourse(_database,educator.Id);
        var courseDto = new CourseUpdateDto(id, name, description, educator.Id);
        
        // Act & Assert
        await Assert.ThrowsAsync<EntityNotFoundException<Domain.Entities.Course>>(() => _courseService.UpdateAsync(courseDto, CancellationToken.None));
    }
    
    [Fact]
    public async Task DeleteAsync_NonExistentId_ThrowsException()
    {
        //Arrange
        var guid = Guid.NewGuid();
        // Act & Assert
        await Assert.ThrowsAsync<EntityNotFoundException<Domain.Entities.Course>>(() => _courseService.DeleteAsync(guid, CancellationToken.None));
    }
    
    [Fact]
    public async Task GetByIdAsync_NonExistentId_ThrowsException()
    {
        //Arrange
        var guid = Guid.NewGuid();
        // Act & Assert
        await Assert.ThrowsAsync<EntityNotFoundException<Domain.Entities.Course>>(() => _courseService.GetByIdAsync(guid, CancellationToken.None));
    }
}