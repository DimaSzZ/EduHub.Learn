using System.Collections;
using Bogus;
using EduHub.StudentService.Application.Services.Dto.Course;
using EduHub.StudentService.Shared.Tests.Infrastructure.Interfaces;

namespace EduHub.StudentService.Shared.Tests.Infrastructure.TestedData
{
    /// <summary>
    /// Класс генератор для позитивных тестов Course
    /// </summary>
    public class TestCourseDataClass : IEnumerable<object[]>, IGenerateDto<CourseUpsertDto>
    {
        private readonly Faker _faker = new Faker();
        
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                _faker.Random.Guid(), // ID
                _faker.Random.String2(10), // Name
                _faker.Random.String2(10), // Description
                _faker.Random.Guid() // Educator ID
            };
        }
        
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        public CourseUpsertDto GetUpsertDto()
        {
            using var enumerator = GetEnumerator();
            enumerator.MoveNext();
            var data = enumerator.Current;
            
            return new CourseUpsertDto(
                (string)data[1], // Name
                (string)data[2], // Description
                (Guid)data[3] // Educator ID
            );
        }
    }
}