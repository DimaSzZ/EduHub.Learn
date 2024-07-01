using EduHub.StudentService.Application.Services.Dto.Course;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Shared.Tests.Infrastructure.TestedData;
using EduHub.StudentService.Tests.Integrations.Fixture;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;

namespace EduHub.StudentService.Tests.Integrations.Tests.Course
{
    public class CourseTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _database;
        private readonly ICourseService _courseService;
        private readonly ICourseRepository _courseRepository;
        
        public CourseTests(DatabaseFixture database)
        {
            _database = database;
            _courseService = _database.ServiceProvider.GetService<ICourseService>();
            _courseRepository = _database.ServiceProvider.GetService<ICourseRepository>();
        }
        
        [Theory]
        [ClassData(typeof(TestCourseDataClass))]
        public async Task AddAsync_ValidCourse_ReturnsCourseResponseDto(
            Guid id,
            string name,
            string description,
            Guid educatorId)
        {
            // Arrange
            var educatorResp = await GenerateEntity.GenerateEducator(_database);
            var courseDto = new CourseUpsertDto(name, description, educatorResp.Id);
            
            // Act
            var result = await _courseService.AddAsync(courseDto, CancellationToken.None);
            
            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(courseDto.Name);
            result.Description.Should().Be(courseDto.Description);
            result.EducatorId.Should().Be(courseDto.EducatorId);
        }
        
        [Fact]
        public async Task UpdateAsync_ValidCourse_ReturnsCourseResponseDto()
        {
            // Arrange
            var educatorResp = await GenerateEntity.GenerateEducator(_database);
            var courseResp = await GenerateEntity.GenerateCourse(_database, educatorResp.Id);
            
            var updateDto = new CourseUpsertDto(courseResp.Name, courseResp.Description, courseResp.EducatorId);
            
            // Act
            var result = await _courseService.UpdateAsync(courseResp.Id, updateDto, CancellationToken.None);
            
            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(courseResp.Id);
            result.Name.Should().Be(courseResp.Name);
            result.Description.Should().Be(courseResp.Description);
            result.EducatorId.Should().Be(courseResp.EducatorId);
        }
        
        [Fact]
        public async Task DeleteCourseAsync_ValidCourse_ReturnsCourseResponseDto()
        {
            //Arrange
            var educatorResp = await GenerateEntity.GenerateEducator(_database);
            var courseResp = await GenerateEntity.GenerateCourse(_database, educatorResp.Id);
            
            //Act
            await _courseService.DeleteAsync(courseResp.Id, CancellationToken.None);
            
            //Assert
            var exists = await _courseRepository.ExistAsync(courseResp.Id, CancellationToken.None);
            exists.Should().BeFalse();
        }
        
        [Fact]
        public async Task GetListAsync_ValidCourse_ReturnsCourseResponseDto()
        {
            // Arrange
            var educatorResp = await GenerateEntity.GenerateEducator(_database);
            await GenerateEntity.GenerateCourse(_database, educatorResp.Id);
            
            // Act
            var result = await _courseService.GetListAsync(CancellationToken.None);
            
            // Assert
            result.Should().NotBeNull();
        }
        
        [Fact]
        public async Task GetByIdAsync_Valid()
        {
            // Arrange
            var educatorResp = await GenerateEntity.GenerateEducator(_database);
            var courseResp = await GenerateEntity.GenerateCourse(_database, educatorResp.Id);
            
            // Act
            var result = await _courseService.GetByIdAsync(courseResp.Id, CancellationToken.None);
            
            // Assert
            result.Should().NotBeNull();
        }
    }
}
