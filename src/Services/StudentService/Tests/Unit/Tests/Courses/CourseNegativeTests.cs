using Unit.Infrastructure;

namespace Unit.Tests.Courses
{
    // Класс для тестирования негативных сценариев для курсов
    public class CourseNegativeTests
    {
        // Поле, содержащее набор свойств курса для использования в тестах
        public static readonly IEnumerable<object[]> CourseProperties = TestedClass.GetCourseProperties();
        
        // Тест на создание курса с нулевыми данными
        [Theory]
        [MemberData(nameof(CourseProperties))]
        public void SetCourse_WithNullData_ShouldBeInvalid(
            Guid id,
            string name,
            string description,
            Guid educatorId)
        {
            // Лямбда-выражение для создания курса с нулевыми данными и проверки на исключение ArgumentException
            var course = () => new Course(id, name, description, educatorId);
            course.Should().Throw<ArgumentException>();
        }
        
        // Тест на обновление курса с нулевыми данными
        [Theory]
        [MemberData(nameof(CourseProperties))]
        public void UpdateCourse_WithNullData_ShouldBeInvalid(
            Guid id,
            string name,
            string description,
            Guid enrollmentId)
        {
            // Лямбда-выражение для обновления курса с нулевыми данными и проверки на исключение ArgumentException
            var course = () => new Course(id, name, description, enrollmentId).Update(name, description, enrollmentId);
            course.Should().Throw<ArgumentException>();
        }
    }
}