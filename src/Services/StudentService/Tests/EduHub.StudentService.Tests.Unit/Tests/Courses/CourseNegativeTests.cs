using EduHub.StudentService.Shared.Tests.Infrastructure;

namespace Unit.Tests.Courses
{
    /// <summary>
    /// Негативные тесты для сущностей Course
    /// </summary>
    public class CourseNegativeTests
    {
        public static readonly IEnumerable<object[]> CourseProperties = TestedClass.GetCourseProperties();
        
        /// <summary>
        /// Тест исключений при создании Course
        /// </summary>
        /// <param name="id">Валидность id</param>
        /// <param name="name">Валидность названия курса</param>
        /// <param name="description">Валидность описания курса</param>
        /// <param name="educatorId">Валидность преподавателя курса</param>
        [Theory]
        [MemberData(nameof(CourseProperties))]
        public void SetCourse_WithNullData_ShouldBeInvalid(
            Guid id,
            string name,
            string description,
            Guid educatorId)
        {
            // Arrange: Подготовка данных
            // Данные передаются через параметризованный тест, данные уже подготовлены
            
            // Act: Лямбда-выражение для создания курса с нулевыми данными и проверки на исключение
            var course = () => new Course(id, name, description, educatorId);
            
            // Assert: Проверка на исключение ArgumentException
            course.Should().Throw<ArgumentException>();
        }
    }
}