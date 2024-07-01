using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Shared.Tests.Infrastructure.TestedData;
using EduHub.StudentService.Tests.Integrations.Fixture;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace EduHub.StudentService.Tests.Integrations.Tests.Student
{
    public class StudentPositive : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _database;
        private readonly IStudentService _studentService;
        private readonly IStudentRepository _studentRepository;
        private readonly TestStudentDataClass _studentGenerate;
        
        public StudentPositive(DatabaseFixture database)
        {
            _database = database;
            _studentService = _database.ServiceProvider.GetRequiredService<IStudentService>();
            _studentRepository = _database.ServiceProvider.GetRequiredService<IStudentRepository>();
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
            result.Should().NotBeNull();
            result.FirstName.Should().Be(createDto.FirstName);
            result.Surname.Should().Be(createDto.Surname);
            result.Patronymic.Should().Be(createDto.Patronymic);
            result.Phone.Should().Be(createDto.Phone);
            result.Avatar.Should().Be(createDto.Avatar);
            result.Email.Should().Be(createDto.Email);
            result.Gender.Should().Be(createDto.Gender);
            result.DateBirth.Should().Be(createDto.DateBirth);
            result.NumberHouse.Should().Be(createDto.NumberHouse);
            result.City.Should().Be(createDto.City);
            result.Street.Should().Be(createDto.Street);
        }
        
        [Fact]
        public async Task UpdateAsync_ValidStudent()
        {
            // Arrange
            var createStudent = await GenerateEntity.GenerateStudent(_database);
            var updateDto = _studentGenerate.GetUpsertDto();
            
            // Act
            var result = await _studentService.UpdateAsync(createStudent.Id, updateDto, CancellationToken.None);
            
            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(createStudent.Id);
            result.FirstName.Should().Be(updateDto.FirstName);
            result.Surname.Should().Be(updateDto.Surname);
            result.Patronymic.Should().Be(updateDto.Patronymic);
            result.Phone.Should().Be(updateDto.Phone);
            result.Avatar.Should().Be(updateDto.Avatar);
            result.Email.Should().Be(updateDto.Email);
            result.Gender.Should().Be(updateDto.Gender);
            result.DateBirth.Should().Be(updateDto.DateBirth);
            result.NumberHouse.Should().Be(updateDto.NumberHouse);
            result.City.Should().Be(updateDto.City);
            result.Street.Should().Be(updateDto.Street);
        }
        
        [Fact]
        public async Task DeleteAsync_ValidId()
        {
            // Arrange
            var student = await GenerateEntity.GenerateStudent(_database);
            
            // Act
            await _studentService.DeleteAsync(student.Id, CancellationToken.None);
            
            // Assert
            (await _studentRepository.ExistAsync(student.Id, CancellationToken.None)).Should().BeFalse();
        }
        
        [Fact]
        public async Task GetListAsync_Valid()
        {
            // Arrange
            await GenerateEntity.GenerateStudent(_database);
            
            // Act
            var result = await _studentService.GetListStudentsAsync(CancellationToken.None);
            
            // Assert
            result.Should().NotBeNull();
        }
    }
}