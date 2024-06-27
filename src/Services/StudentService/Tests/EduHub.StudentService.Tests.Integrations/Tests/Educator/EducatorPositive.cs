using EduHub.StudentService.Application.Services.Dto.Educator;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Domain.Entities.Enums;
using EduHub.StudentService.Domain.ValueObjects;
using EduHub.StudentService.Shared.Tests.Infrastructure.TestedData;
using EduHub.StudentService.Tests.Integrations.Fixture;
using Microsoft.Extensions.DependencyInjection;

namespace EduHub.StudentService.Tests.Integrations.Tests.Educator
{
    public class EducatorPositive : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _database;
        private readonly IEducatorService _educatorService;
        private readonly IEducatorRepository _educatorRepository;
        
        public EducatorPositive(DatabaseFixture database)
        {
            _database = database;
            _educatorService = _database.ServiceProvider.GetRequiredService<IEducatorService>();
            _educatorRepository = _database.ServiceProvider.GetRequiredService<IEducatorRepository>();
        }
        
        [Theory]
        [ClassData(typeof(TestEducatorDataClass))]
        public async Task AddAsync_ValidEducator(
            Guid id,
            FullName fullName,
            Gender gender,
            Phone phone,
            int workExp,
            DateOnly dateEmployment
        )
        {
            //Arrange
            var educatorDto = new EducatorUpsertDto(fullName.FirstName, fullName.Surname, fullName.Patronymic, gender, phone.Value, workExp, dateEmployment);
            
            //Act
            var result = await _educatorService.AddAsync(educatorDto, CancellationToken.None);
            
            //Assert
            Assert.NotNull(result);
            Assert.Equal(educatorDto.FirstName, result.FirstName);
            Assert.Equal(educatorDto.Surname, result.Surname);
            Assert.Equal(educatorDto.Patronymic, result.Patronymic);
            Assert.Equal(educatorDto.Gender, result.Gender);
            Assert.Equal(educatorDto.Phone, result.Phone);
            Assert.Equal(educatorDto.YearsExperience, result.YearsExperience);
            Assert.Equal(educatorDto.DateEmployment, result.DateEmployment);
        }
        
        [Fact]
        public async Task UpdateAsync_ValidEducator_ReturnsEducatorResponseDto()
        {
            //Arrange
            var educator = await GenerateEntity.GenerateEducator(_database);
            var educatorDto = new EducatorUpsertDto(educator.FullName.FirstName, educator.FullName.Surname, educator.FullName.Patronymic,
                educator.Gender, educator.Phone.Value, educator.YearsExperience, educator.DateEmployment);
            
            //Act
            var result = await _educatorService.UpdateAsync(educator.Id, educatorDto, CancellationToken.None);
            
            //Assert
            Assert.NotNull(result);
            Assert.Equal(educator.Id, result.Id);
            Assert.Equal(educatorDto.FirstName, result.FirstName);
            Assert.Equal(educatorDto.Surname, result.Surname);
            Assert.Equal(educatorDto.Patronymic, result.Patronymic);
            Assert.Equal(educatorDto.Gender, result.Gender);
            Assert.Equal(educatorDto.Phone, result.Phone);
            Assert.Equal(educatorDto.YearsExperience, result.YearsExperience);
            Assert.Equal(educatorDto.DateEmployment, result.DateEmployment);
        }
        
        [Fact]
        public async Task DeleteAsync_ValidId()
        {
            //Arrange
            var educator = await GenerateEntity.GenerateEducator(_database);
            
            //Act
            await _educatorService.DeleteAsync(educator.Id, CancellationToken.None);
            
            //Assert
            Assert.False(await _educatorRepository.ExistAsync(educator.Id, CancellationToken.None));
        }
        
        [Fact]
        public async Task GetByIdAsync_Valid()
        {
            // Arrange
            var educator = await GenerateEntity.GenerateEducator(_database);
            
            //Act
            var result = await _educatorService.GetByIdAsync(educator.Id, CancellationToken.None);
            
            //Assert
            Assert.NotNull(result);
        }
    }
}