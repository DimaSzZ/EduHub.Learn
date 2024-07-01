using EduHub.StudentService.Application.Services.Dto.Course;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Shared.Tests.Infrastructure.TestedData;
using EduHub.StudentService.Tests.Integrations.Fixture;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Extensions.DependencyInjection;

namespace EduHub.StudentService.Tests.Integrations.Tests.CourseService
{
    public class CourseTests : IClassFixture<InfrastructureFixture>
    {
        private readonly InfrastructureFixture _infrastructure;
        private readonly ICourseService _courseService;
        private readonly ICourseRepository _courseRepository;
        
        public CourseTests(InfrastructureFixture infrastructure)
        {
            _infrastructure = infrastructure;
            _courseService = _infrastructure.ServiceProvider.GetService<ICourseService>();
            _courseRepository = _infrastructure.ServiceProvider.GetService<ICourseRepository>();
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
            var educatorResp = await GenerateEntity.GenerateEducator(_infrastructure);
            var courseDto = new CourseUpsertDto(name, description, educatorResp.Id);
            
            // Act
            var result = await _courseService.AddAsync(courseDto, CancellationToken.None);
            
            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.Should().BeEquivalentTo(courseDto, options => options.ExcludingMissingMembers());
            }
        }
        
        [Fact]
        public async Task UpdateAsync_ValidCourse_ReturnsCourseResponseDto()
        {
            // Arrange
            var educatorResp = await GenerateEntity.GenerateEducator(_infrastructure);
            var courseResp = await GenerateEntity.GenerateCourse(_infrastructure, educatorResp.Id);
            
            var updateDto = new CourseUpsertDto(courseResp.Name, courseResp.Description, courseResp.EducatorId);
            
            // Act
            var result = await _courseService.UpdateAsync(courseResp.Id, updateDto, CancellationToken.None);
            
            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.Should().BeEquivalentTo(updateDto, options => options.ExcludingMissingMembers());
            }
        }
        
        [Fact]
        public async Task DeleteCourseAsync_ValidCourse_ReturnsCourseResponseDto()
        {
            //Arrange
            var educatorResp = await GenerateEntity.GenerateEducator(_infrastructure);
            var courseResp = await GenerateEntity.GenerateCourse(_infrastructure, educatorResp.Id);
            
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
            var educatorResp = await GenerateEntity.GenerateEducator(_infrastructure);
            await GenerateEntity.GenerateCourse(_infrastructure, educatorResp.Id);
            
            // Act
            var result = await _courseService.GetListAsync(CancellationToken.None);
            
            // Assert
            result.Should().NotBeNull();
        }
        
        [Fact]
        public async Task GetByIdAsync_Valid()
        {
            // Arrange
            var educatorResp = await GenerateEntity.GenerateEducator(_infrastructure);
            var courseResp = await GenerateEntity.GenerateCourse(_infrastructure, educatorResp.Id);
            
            // Act
            var result = await _courseService.GetByIdAsync(courseResp.Id, CancellationToken.None);
            
            // Assert
            result.Should().NotBeNull();
        }
    }
}
