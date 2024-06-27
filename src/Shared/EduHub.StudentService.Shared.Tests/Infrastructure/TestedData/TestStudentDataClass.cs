using System.Collections;
using Bogus;
using EduHub.StudentService.Application.Services.Dto.Student;
using EduHub.StudentService.Domain.Entities.Enums;
using EduHub.StudentService.Shared.Tests.Infrastructure.Interfaces;

namespace EduHub.StudentService.Shared.Tests.Infrastructure.TestedData
{
    /// <summary>
    /// Класс генератор юнит и интеграционных тестов Student
    /// </summary>
    public class TestStudentDataClass : IEnumerable<object[]>, IGenerateDto<StudentUpsertDto>
    {
        private readonly Faker _faker = new Faker();
        private readonly DateOnly _minBirthDate = new DateOnly(1900, 1, 1);

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                _faker.Random.Guid(),
                _faker.Internet.Avatar(), // Avatar
                _faker.Name.FirstName(), // FirstName
                _faker.Name.LastName(), // Surname
                _faker.Name.LastName(), // Patronymic
                EnumGenerator.GetGender(),
                _faker.Date.BetweenDateOnly(_minBirthDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)), // DateBirth
                _faker.Internet.Email(), // Email
                CustomTransnistriaPhoneNumbers.GenerateTransnistriaPhoneNumber(), // Phone
                _faker.Address.City(), // City
                _faker.Address.StreetName(), // Street
                int.Parse(_faker.Address.BuildingNumber()) // NumberHouse
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public StudentUpsertDto GetUpsertDto()
        {
            using var enumerator = GetEnumerator();
            enumerator.MoveNext(); // Move to the first (and only) item in the enumerator
            var data = enumerator.Current;

            return new StudentUpsertDto(
                (string)data[1], // Avatar
                (string)data[2], // FirstName
                (string)data[3], // Surname
                (string)data[4], // Patronymic
                (Gender)data[5], // Gender
                (DateOnly)data[6], // DateBirth
                (string)data[7], // Email
                (string)data[8], // Phone
                (string)data[9], // City
                (string)data[10], // Street
                (int)data[11] // NumberHouse
            );
        }
    }
}
