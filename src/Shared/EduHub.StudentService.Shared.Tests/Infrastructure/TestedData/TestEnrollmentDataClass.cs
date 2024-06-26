using System.Collections;
using Bogus;
using EduHub.StudentService.Application.Services.Dto.Enrollment;
using EduHub.StudentService.Shared.Tests.Infrastructure.Interfaces;

namespace EduHub.StudentService.Shared.Tests.Infrastructure.TestedData
{
    /// <summary>
    /// Класс генератор для юнит и интеграционных тестов Enrollment
    /// </summary>
    public class TestEnrollmentDataClass : IEnumerable<object[]>, IGenerateDto<EnrollmentCreateDto, EnrollmentUpdateDto>
    {
        private readonly Faker _faker = new Faker();
        private readonly DateOnly _minDate = new DateOnly(1900, 1, 1);
        
        // Реализация метода GetEnumerator для предоставления данных для тестов
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                _faker.Random.Guid(), // ID для UpdateDto
                _faker.Date.BetweenDateOnly(_minDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)), // Date
                _faker.Random.Guid(), // Student ID
                _faker.Random.Guid()  // Course ID
            };
        }
        
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        // Метод для создания EnrollmentCreateDto
        public EnrollmentCreateDto GetCreateDto()
        {
            using var enumerator = GetEnumerator();
            enumerator.MoveNext();
            var data = enumerator.Current;
            
            return new EnrollmentCreateDto(
                (DateOnly)data[1], // Date
                (Guid)data[2], // Student ID
                (Guid)data[3]  // Course ID
            );
        }
        
        // Метод для создания EnrollmentUpdateDto
        public EnrollmentUpdateDto GetUpdateDto()
        {
            using var enumerator = GetEnumerator();
            enumerator.MoveNext();
            var data = enumerator.Current;
            
            return new EnrollmentUpdateDto(
                (Guid)data[0], // ID
                (DateOnly)data[1], // Date
                (Guid)data[2], // Student ID
                (Guid)data[3]  // Course ID
            );
        }
    }
}
