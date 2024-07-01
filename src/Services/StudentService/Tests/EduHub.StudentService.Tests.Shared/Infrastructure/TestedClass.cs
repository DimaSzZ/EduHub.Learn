using Bogus;
using EduHub.StudentService.Domain.Entities.Enums;
using EduHub.StudentService.Domain.ValueObjects;
using Address = EduHub.StudentService.Domain.ValueObjects.Address;

namespace EduHub.StudentService.Shared.Tests.Infrastructure;

/// <summary>
/// Класс генератор случайных данных для сущностей
/// </summary>
public static class TestedClass
{
    private static readonly Faker Faker = new Faker();
    private static readonly DateOnly MinDate = new DateOnly(1900, 1, 1);
    
    /// <summary>
    /// Метод генерации студентов
    /// </summary>
    /// <returns>
    /// Возвращает лист Student
    /// </returns>
    public static IEnumerable<object[]> GetStudentProperties()
    {
        return new List<object[]>
        {
            new object[]
            {
                Guid.Empty, Faker.Random.String2(8), new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
                EnumGenerator.GetGender(),
                Faker.Date.PastDateOnly(),
                new Email(Faker.Internet.Email()), new Phone(CustomTransnistriaPhoneNumbers.GenerateTransnistriaPhoneNumber()), new Address(
                    Faker.Address.City(),
                    Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()))
            },
            
            new object[]
            {
                Faker.Random.Guid(), null, new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
                EnumGenerator.GetGender(),
                Faker.Date.PastDateOnly(),
                new Email(Faker.Internet.Email()), new Phone(CustomTransnistriaPhoneNumbers.GenerateTransnistriaPhoneNumber()), new Address(
                    Faker.Address.City(),
                    Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()))
            },
            
            new object[]
            {
                Faker.Random.Guid(), Faker.Random.String2(8), null,
                EnumGenerator.GetGender(),
                Faker.Date.PastDateOnly(),
                new Email(Faker.Internet.Email()), new Phone(CustomTransnistriaPhoneNumbers.GenerateTransnistriaPhoneNumber()), new Address(
                    Faker.Address.City(),
                    Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()))
            },
            
            new object[]
            {
                Faker.Random.Guid(), Faker.Random.String2(8), new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
                Gender.Default, Faker.Date.PastDateOnly(),
                new Email(Faker.Internet.Email()), new Phone(CustomTransnistriaPhoneNumbers.GenerateTransnistriaPhoneNumber()), new Address(
                    Faker.Address.City(),
                    Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()))
            },
            
            new object[]
            {
                Faker.Random.Guid(), Faker.Random.String2(8), new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
                EnumGenerator.GetGender(), default,
                new Email(Faker.Internet.Email()), new Phone(CustomTransnistriaPhoneNumbers.GenerateTransnistriaPhoneNumber()), new Address(
                    Faker.Address.City(),
                    Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()))
            },
            
            new object[]
            {
                Faker.Random.Guid(), Faker.Random.String2(8), new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
                EnumGenerator.GetGender(),
                Faker.Date.PastDateOnly(),
                null, new Phone(CustomTransnistriaPhoneNumbers.GenerateTransnistriaPhoneNumber()), new Address(Faker.Address.City(), Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()))
            },
            
            new object[]
            {
                Faker.Random.Guid(), Faker.Random.String2(8), new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
                EnumGenerator.GetGender(),
                Faker.Date.PastDateOnly(),
                new Email(Faker.Internet.Email()), null, new Address(Faker.Address.City(), Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()))
            },
            new object[]
            {
                Faker.Random.Guid(), Faker.Random.String2(8), new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
                EnumGenerator.GetGender(),
                Faker.Date.PastDateOnly(),
                new Email(Faker.Internet.Email()), new Phone(CustomTransnistriaPhoneNumbers.GenerateTransnistriaPhoneNumber()), null
            }
        };
    }
    
    /// <summary>
    /// Метод генерации зачислений
    /// </summary>
    /// <returns>
    /// Возвращает лист Enrollment
    /// </returns>
    public static IEnumerable<object[]> GetEnrollmentProperties()
    {
        return new List<object[]>
        {
            new object[]
            {
                Guid.Empty, Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)), Guid.NewGuid(),
                Guid.NewGuid()
            },
            
            new object[]
            {
                Guid.Empty, default, Guid.NewGuid(), Guid.NewGuid()
            },
            
            new object[]
            {
                Guid.NewGuid(), Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
                Guid.Empty, Guid.NewGuid()
            },
            
            new object[]
            {
                Guid.NewGuid(), Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
                Guid.NewGuid(), Guid.Empty
            },
        };
    }
    
    /// <summary>
    /// Метод генерации курсов
    /// </summary>
    /// <returns>
    /// Возвращает лист Course
    /// </returns>
    public static IEnumerable<object[]> GetCourseProperties()
    {
        return new List<object[]>
        {
            new object[]
            {
                Guid.Empty, Faker.Random.String2(8), Faker.Random.String2(8), Guid.NewGuid()
            },
            
            new object[]
            {
                Guid.NewGuid(), null, Faker.Random.String2(8), Guid.NewGuid()
            },
            
            new object[]
            {
                Guid.NewGuid(), Faker.Random.String2(8), null, Guid.NewGuid()
            },
            
            new object[]
            {
                Guid.NewGuid(), Faker.Random.String2(8), Faker.Random.String2(8), Guid.Empty
            },
        };
    }
    
    /// <summary>
    /// Метод генерации Преподавателей
    /// </summary>
    /// <returns>
    /// Возвращает лист Educator
    /// </returns>
    public static IEnumerable<object[]> GetEducatorProperties()
    {
        return new List<object[]>
        {
            new object[]
            {
                Guid.Empty, new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()), EnumGenerator.GetGender(),
                new Phone(CustomTransnistriaPhoneNumbers.GenerateTransnistriaPhoneNumber()), Faker.Random.Byte(0, 60),
                Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
            },
            
            new object[]
            {
                Guid.NewGuid(), null, EnumGenerator.GetGender(),
                new Phone(CustomTransnistriaPhoneNumbers.GenerateTransnistriaPhoneNumber()), Faker.Random.Byte(0, 60),
                Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
            },
            
            new object[]
            {
                Guid.Empty, new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()), Gender.Default,
                new Phone(CustomTransnistriaPhoneNumbers.GenerateTransnistriaPhoneNumber()), Faker.Random.Byte(0, 60),
                Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
            },
            
            new object[]
            {
                Guid.Empty, new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()), EnumGenerator.GetGender(),
                null, Faker.Random.Byte(0, 60), Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
            },
            
            new object[]
            {
                Guid.Empty, new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()), EnumGenerator.GetGender(),
                new Phone(CustomTransnistriaPhoneNumbers.GenerateTransnistriaPhoneNumber()), -1,
                Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
            },
            
            new object[]
            {
                Guid.Empty, new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()), EnumGenerator.GetGender(),
                new Phone(CustomTransnistriaPhoneNumbers.GenerateTransnistriaPhoneNumber()), Faker.Random.Byte(0, 60), default
            },
        };
    }
}