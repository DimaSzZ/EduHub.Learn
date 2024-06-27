using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Shared.Tests.Infrastructure.TestedData;
using EduHub.StudentService.Tests.Integrations.Fixture;
using Microsoft.Extensions.DependencyInjection;

namespace EduHub.StudentService.Tests.Integrations.Tests.Student;

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
        //Arrange
        var createDto = _studentGenerate.GetUpsertDto();
        
        //Act
        var result = await _studentService.AddAsync(createDto, CancellationToken.None);
        
        //Assert
        Assert.NotNull(result);
        Assert.Equal(createDto.FirstName, result.FirstName);
        Assert.Equal(createDto.Surname, result.Surname);
        Assert.Equal(createDto.Patronymic, result.Patronymic);
        Assert.Equal(createDto.Phone, result.Phone);
        Assert.Equal(createDto.Avatar, result.Avatar);
        Assert.Equal(createDto.Email, result.Email);
        Assert.Equal(createDto.Gender, result.Gender);
        Assert.Equal(createDto.DateBirth, result.DateBirth);
        Assert.Equal(createDto.NumberHouse, result.NumberHouse);
        Assert.Equal(createDto.City, result.City);
        Assert.Equal(createDto.Street, result.Street);
    }
    
    [Fact]
    public async Task UpdateAsync_ValidStudent()
    {
        //Arrange
        var createStudent = await GenerateEntity.GenerateStudent(_database);
        var updateDto = _studentGenerate.GetUpsertDto();
        
        //Act
        var result = await _studentService.UpdateAsync(createStudent.Id, updateDto, CancellationToken.None);
        
        //Assert
        Assert.NotNull(result);
        Assert.Equal(createStudent.Id, result.Id);
        Assert.Equal(updateDto.FirstName, result.FirstName);
        Assert.Equal(updateDto.Surname, result.Surname);
        Assert.Equal(updateDto.Patronymic, result.Patronymic);
        Assert.Equal(updateDto.Phone, result.Phone);
        Assert.Equal(updateDto.Avatar, result.Avatar);
        Assert.Equal(updateDto.Email, result.Email);
        Assert.Equal(updateDto.Gender, result.Gender);
        Assert.Equal(updateDto.DateBirth, result.DateBirth);
        Assert.Equal(updateDto.NumberHouse, result.NumberHouse);
        Assert.Equal(updateDto.City, result.City);
        Assert.Equal(updateDto.Street, result.Street);
    }
    
    [Fact]
    public async Task DeleteAsync_ValId()
    {
        // Arrange
        var student = await GenerateEntity.GenerateStudent(_database);
        
        //Act
        await _studentService.DeleteAsync(student.Id, CancellationToken.None);
        
        //Assert
        Assert.False(await _studentRepository.ExistAsync(student.Id, CancellationToken.None));
    }
    
    [Fact]
    public async Task GetListAsync_Valid()
    {
        // Arrange
        await GenerateEntity.GenerateStudent(_database);
        
        //Act
        var result = await _studentService.GetListStudentsAsync(CancellationToken.None);
        
        //Assert
        Assert.NotNull(result);
    }
    
    [Fact]
    public async Task GetListStudent()
    {
        // Arrange
        await GenerateEntity.GenerateStudent(_database);
        
        //Act
        var result = await _studentService.GetListStudentsAsync(CancellationToken.None);
        
        //Assert
        Assert.NotNull(result);
    }
}