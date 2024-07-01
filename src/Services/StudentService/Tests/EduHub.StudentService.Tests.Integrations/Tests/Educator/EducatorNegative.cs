using EduHub.StudentService.Application.Services.Dto.Educator;
using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Domain.Entities.Enums;
using EduHub.StudentService.Domain.ValueObjects;
using EduHub.StudentService.Shared.Tests.Infrastructure.TestedData;
using EduHub.StudentService.Tests.Integrations.Fixture;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace EduHub.StudentService.Tests.Integrations.Tests.Educator
{
    public class EducatorNegative : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _database;
        private readonly IEducatorService _educatorService;
        
        public EducatorNegative(DatabaseFixture database)
        {
            _database = database;
            _educatorService = _database.ServiceProvider.GetService<IEducatorService>();
        }
        
        [Theory]
        [ClassData(typeof(TestEducatorDataClass))]
        public async Task UpdateAsync_NonExistentEducator_ThrowsException(
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
            var act = async () => await _educatorService.UpdateAsync(id, educatorDto, CancellationToken.None);
            
            // Assert
            await act.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Educator>>();
        }
        
        [Fact]
        public async Task DeleteAsync_NonExistentId_ThrowsException()
        {
            // Arrange
            var guid = Guid.NewGuid();
            
            // Act
            var act = async () => await _educatorService.DeleteAsync(guid, CancellationToken.None);
            
            // Assert
            await act.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Educator>>();
        }
        
        [Fact]
        public async Task GetByIdAsync_NonExistentId_ThrowsException()
        {
            // Arrange
            var guid = Guid.NewGuid();
            
            // Act
            var act = async () => await _educatorService.GetByIdAsync(guid, CancellationToken.None);
            
            // Assert
            await act.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Educator>>();
        }
    }
}
