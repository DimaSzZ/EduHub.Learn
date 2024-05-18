using Unit.Infrastructure;

namespace Unit.Tests.Courses
{
    public class CourseNegativeTests
    {
        public static readonly IEnumerable<object[]> CourseProperties = TestedClass.GetCourseProperties();
        
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
        
        [Theory]
        [MemberData(nameof(CourseProperties))]
        public void UpdateCourse_WithNullData_ShouldBeInvalid(
            Guid id,
            string name,
            string description,
            Guid educatorId)
        {
            // Arrange: Подготовка данных
            // Данные передаются через параметризованный тест, данные уже подготовлены
            // Создание экземпляра Course с валидными данными
            var course = new Course(id, name, description, educatorId);

            // Act: Лямбда-выражение для обновления курса с нулевыми данными и проверки на исключение
            var updateCourse = () => course.Update(name, description, educatorId);

            // Assert: Проверка на исключение ArgumentException
            updateCourse.Should().Throw<ArgumentException>();
        }
    }
}
