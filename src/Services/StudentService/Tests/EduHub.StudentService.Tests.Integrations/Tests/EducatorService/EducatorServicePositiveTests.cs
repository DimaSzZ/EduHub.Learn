using EduHub.StudentService.Application.Services.Dto.Educator;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Domain.Entities.Enums;
using EduHub.StudentService.Domain.ValueObjects;
using EduHub.StudentService.Shared.Tests.Infrastructure.TestedData;
using EduHub.StudentService.Tests.Integrations.Fixture;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Extensions.DependencyInjection;

namespace EduHub.StudentService.Tests.Integrations.Tests.EducatorService
{
    public class EducatorServicePositiveTests : IClassFixture<InfrastructureFixture>
    {
        private readonly InfrastructureFixture _infrastructure;
        private readonly IEducatorService _educatorService;
        private readonly IEducatorRepository _educatorRepository;
        
        public EducatorServicePositiveTests(InfrastructureFixture infrastructure)
        {
            _infrastructure = infrastructure;
            _educatorService = _infrastructure.ServiceProvider.GetRequiredService<IEducatorService>();
            _educatorRepository = _infrastructure.ServiceProvider.GetRequiredService<IEducatorRepository>();
        }
        
        [Theory]
        [ClassData(typeof(TestEducatorDataClass))]
        public async Task AddAsync_ValidEducator(
            Guid id,
            FullName fullName,
            Gender gender,
            Phone phone,
            int workExp,
            DateOnly dateEmployment)
        {
            // Arrange
            var educatorDto = new EducatorUpsertDto(fullName.FirstName, fullName.Surname, fullName.Patronymic, gender, phone.Value, workExp, dateEmployment);
            
            // Act
            var result = await _educatorService.AddAsync(educatorDto, CancellationToken.None);
            
            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.Should().BeEquivalentTo(educatorDto, options => options.ExcludingMissingMembers());
            }
        }
        
        [Fact]
        public async Task UpdateAsync_ValidEducator_ReturnsEducatorResponseDto()
        {
            // Arrange
            var educator = await GenerateEntity.GenerateEducator(_infrastructure);
            var educatorDto = new EducatorUpsertDto(educator.FullName.FirstName, educator.FullName.Surname, educator.FullName.Patronymic,
                educator.Gender, educator.Phone.Value, educator.YearsExperience, educator.DateEmployment);
            
            // Act
            var result = await _educatorService.UpdateAsync(educator.Id, educatorDto, CancellationToken.None);
            
            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.Should().BeEquivalentTo(educatorDto, options => options.ExcludingMissingMembers());
            }
        }
        
        [Fact]
        public async Task DeleteAsync_ValidId()
        {
            // Arrange
            var educator = await GenerateEntity.GenerateEducator(_infrastructure);
            
            // Act
            await _educatorService.DeleteAsync(educator.Id, CancellationToken.None);
            
            // Assert
            var exists = await _educatorRepository.ExistAsync(educator.Id, CancellationToken.None);
            exists.Should().BeFalse();
        }
        
        [Fact]
        public async Task GetByIdAsync_Valid()
        {
            // Arrange
            var educator = await GenerateEntity.GenerateEducator(_infrastructure);
            
            // Act
            var result = await _educatorService.GetByIdAsync(educator.Id, CancellationToken.None);
            
            // Assert
            result.Should().NotBeNull();
        }
    }
}