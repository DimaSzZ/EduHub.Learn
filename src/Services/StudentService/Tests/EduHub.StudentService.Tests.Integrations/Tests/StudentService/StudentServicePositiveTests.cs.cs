using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Shared.Tests.Infrastructure.TestedData;
using EduHub.StudentService.Tests.Integrations.Fixture;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Extensions.DependencyInjection;

namespace EduHub.StudentService.Tests.Integrations.Tests.StudentService
{
    public class StudentPositive : IClassFixture<InfrastructureFixture>
    {
        private readonly InfrastructureFixture _infrastructure;
        private readonly IStudentService _studentService;
        private readonly IStudentRepository _studentRepository;
        private readonly TestStudentDataClass _studentGenerate;
        
        public StudentPositive(InfrastructureFixture infrastructure)
        {
            _infrastructure = infrastructure;
            _studentService = _infrastructure.ServiceProvider.GetRequiredService<IStudentService>();
            _studentRepository = _infrastructure.ServiceProvider.GetRequiredService<IStudentRepository>();
            _studentGenerate = new TestStudentDataClass();
        }
        
        [Fact]
        public async Task AddAsync_ValidStudent()
        {
            // Arrange
            var createDto = _studentGenerate.GetUpsertDto();
            
            // Act
            var result = await _studentService.AddAsync(createDto, CancellationToken.None);
            
            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.Should().BeEquivalentTo(createDto, options => options.ExcludingMissingMembers());
            }
        }
        
        [Fact]
        public async Task UpdateAsync_ValidStudent()
        {
            // Arrange
            var createStudent = await GenerateEntity.GenerateStudent(_infrastructure);
            var updateDto = _studentGenerate.GetUpsertDto();
            
            // Act
            var result = await _studentService.UpdateAsync(createStudent.Id, updateDto, CancellationToken.None);
            
            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.Should().BeEquivalentTo(updateDto, options => options.ExcludingMissingMembers());
            }
        }
        
        [Fact]
        public async Task DeleteAsync_ValidId()
        {
            // Arrange
            var student = await GenerateEntity.GenerateStudent(_infrastructure);
            
            // Act
            await _studentService.DeleteAsync(student.Id, CancellationToken.None);
            
            // Assert
            (await _studentRepository.ExistAsync(student.Id, CancellationToken.None)).Should().BeFalse();
        }
        
        [Fact]
        public async Task GetListAsync_Valid()
        {
            // Arrange
            await GenerateEntity.GenerateStudent(_infrastructure);
            
            // Act
            var result = await _studentService.GetListStudentsAsync(CancellationToken.None);
            
            // Assert
            result.Should().NotBeNull();
        }
    }
}