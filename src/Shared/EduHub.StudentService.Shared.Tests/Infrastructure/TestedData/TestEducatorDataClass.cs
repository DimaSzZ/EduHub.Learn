using System.Collections;
using Bogus;
using EduHub.StudentService.Application.Services.Dto.Educator;
using EduHub.StudentService.Domain.Entities.Enums;
using EduHub.StudentService.Domain.ValueObjects;
using EduHub.StudentService.Shared.Tests.Infrastructure.Interfaces;

namespace EduHub.StudentService.Shared.Tests.Infrastructure.TestedData;

/// <summary>
/// Класс генератор для юнит и интеграционных тестов Educator
/// </summary>
public class TestEducatorDataClass : IEnumerable<object[]>, IGenerateDto<EducatorCreateDto, EducatorUpdateDto>
{
    private readonly Faker _faker = new Faker();
    private readonly DateOnly _minBirthDate = new DateOnly(1900, 1, 1);
    
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            _faker.Random.Guid(), // ID
            new FullName(_faker.Name.FirstName(), _faker.Name.LastName(), _faker.Name.LastName()), // FullName
            EnumGenerator.GetGender(), // Gender
            new Phone(CustomTransnistriaPhoneNumbers.GenerateTransnistriaPhoneNumber()), // Phone
            _faker.Random.Int(0, 60), // Work Experience
            _faker.Date.BetweenDateOnly(_minBirthDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)) // Date of Employment
        };
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
    public EducatorCreateDto GetCreateDto()
    {
        using var enumerator = GetEnumerator();
        enumerator.MoveNext();
        var data = enumerator.Current;

        return new EducatorCreateDto(
            ((FullName)data[1]).FirstName, // FirstName
            ((FullName)data[1]).Surname, // Surname
            ((FullName)data[1]).Patronymic, // Patronymic
            (Gender)data[2], // Gender
            ((Phone)data[3]).Value, // Phone
            (int)data[4], // Work Experience
            (DateOnly)data[5] // Date of Employment
        );
    }
    
    public EducatorUpdateDto GetUpdateDto()
    {
        using var enumerator = GetEnumerator();
        enumerator.MoveNext();
        var data = enumerator.Current;

        return new EducatorUpdateDto(
            (Guid)data[0], // ID
            ((FullName)data[1]).FirstName, // FirstName
            ((FullName)data[1]).Surname, // Surname
            ((FullName)data[1]).Patronymic, // Patronymic
            (Gender)data[2], // Gender
            ((Phone)data[3]).Value, // Phone
            (int)data[4], // Work Experience
            (DateOnly)data[5] // Date of Employment
        );
    }
}
