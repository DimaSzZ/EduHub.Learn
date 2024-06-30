﻿using EduHub.StudentService.Application.Services.Dto.Educator;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Domain.Entities.Enums;
using EduHub.StudentService.Domain.ValueObjects;
using EduHub.StudentService.Shared.Tests.Infrastructure.TestedData;
using EduHub.StudentService.Tests.Integrations.Fixture;
using FluentAssertions;
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
            DateOnly dateEmployment)
        {
            // Arrange
            var educatorDto = new EducatorUpsertDto(fullName.FirstName, fullName.Surname, fullName.Patronymic, gender, phone.Value, workExp, dateEmployment);
            
            // Act
            var result = await _educatorService.AddAsync(educatorDto, CancellationToken.None);
            
            // Assert
            result.Should().NotBeNull();
            result.FirstName.Should().Be(educatorDto.FirstName);
            result.Surname.Should().Be(educatorDto.Surname);
            result.Patronymic.Should().Be(educatorDto.Patronymic);
            result.Gender.Should().Be(educatorDto.Gender);
            result.Phone.Should().Be(educatorDto.Phone);
            result.YearsExperience.Should().Be(educatorDto.YearsExperience);
            result.DateEmployment.Should().Be(educatorDto.DateEmployment);
        }
        
        [Fact]
        public async Task UpdateAsync_ValidEducator_ReturnsEducatorResponseDto()
        {
            // Arrange
            var educator = await GenerateEntity.GenerateEducator(_database);
            var educatorDto = new EducatorUpsertDto(educator.FullName.FirstName, educator.FullName.Surname, educator.FullName.Patronymic,
                educator.Gender, educator.Phone.Value, educator.YearsExperience, educator.DateEmployment);
            
            // Act
            var result = await _educatorService.UpdateAsync(educator.Id, educatorDto, CancellationToken.None);
            
            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(educator.Id);
            result.FirstName.Should().Be(educatorDto.FirstName);
            result.Surname.Should().Be(educatorDto.Surname);
            result.Patronymic.Should().Be(educatorDto.Patronymic);
            result.Gender.Should().Be(educatorDto.Gender);
            result.Phone.Should().Be(educatorDto.Phone);
            result.YearsExperience.Should().Be(educatorDto.YearsExperience);
            result.DateEmployment.Should().Be(educatorDto.DateEmployment);
        }
        
        [Fact]
        public async Task DeleteAsync_ValidId()
        {
            // Arrange
            var educator = await GenerateEntity.GenerateEducator(_database);
            
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
            var educator = await GenerateEntity.GenerateEducator(_database);
            
            // Act
            var result = await _educatorService.GetByIdAsync(educator.Id, CancellationToken.None);
            
            // Assert
            result.Should().NotBeNull();
        }
    }
}