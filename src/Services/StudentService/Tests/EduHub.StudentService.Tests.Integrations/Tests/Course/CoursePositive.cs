using EduHub.StudentService.Application.Services.Dto.Course;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Shared.Tests.Infrastructure.TestedData;
using EduHub.StudentService.Tests.Integrations.Fixture;
using Microsoft.Extensions.DependencyInjection;

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
            var courseDto = new CourseCreateDto(name, description, educatorResp.Id);
            
            // Act
            var result = await _courseService.AddAsync(courseDto, CancellationToken.None);
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal(courseDto.Name, result.Name);
            Assert.Equal(courseDto.Description, result.Description);
            Assert.Equal(courseDto.EducatorId, result.EducatorId);
        }
        
        [Fact]
        public async Task UpdateAsync_ValidCourse_ReturnsCourseResponseDto()
        {
            // Arrange
            var educatorResp = await GenerateEntity.GenerateEducator(_database);
                        var courseResp = await GenerateEntity.GenerateCourse(_database, educatorResp.Id);
            
            var updateDto = new CourseUpdateDto(courseResp.Id, courseResp.Name, courseResp.Description, courseResp.EducatorId);
            
            // Act
            var result = await _courseService.UpdateAsync(updateDto, CancellationToken.None);
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal(courseResp.Id, result.Id);
            Assert.Equal(courseResp.Name, result.Name);
            Assert.Equal(courseResp.Description, result.Description);
            Assert.Equal(courseResp.EducatorId, result.EducatorId);
        }
        
        [Fact]
        public async Task DeleteCourseAsync_ValidCourse_ReturnsCourseResponseDto()
        {
            //Arrange
            var educatorResp = await GenerateEntity.GenerateEducator(_database);
            var courseResp = await GenerateEntity.GenerateCourse(_database, educatorResp.Id);
            
            //Act
            await _courseService.DeleteAsync(courseResp.Id, CancellationToken.None);
            
            //Arrange
            Assert.False(await _courseRepository.ExistAsync(courseResp.Id, CancellationToken.None));
        }
        
        [Fact]
        public async Task GetListAsync_ValidCourse_ReturnsCourseResponseDto()
        {
            // Arrange
            var educatorResp = await GenerateEntity.GenerateEducator(_database);
            var courseResp = await GenerateEntity.GenerateCourse(_database, educatorResp.Id);
            
            // Act
            var result = await _courseService.GetListAsync(CancellationToken.None);
            
            // Assert
            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task GetByIdAsync_Valid()
        {
            // Arrange
            var educatorResp = await GenerateEntity.GenerateEducator(_database);
            var courseResp = await GenerateEntity.GenerateCourse(_database, educatorResp.Id);
            
            //Act
            var result = await _courseService.GetByIdAsync(courseResp.Id, CancellationToken.None);
            
            //Assert
            Assert.NotNull(result);
        }
    }
}