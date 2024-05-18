using Unit.Infrastructure.TestedData;

namespace Unit.Tests.Courses
{
    public class CoursePositiveTests
    {
        [Theory]
        [ClassData(typeof(TestCourseDataClass))]
        public void SetCourse_WithValidData_ShouldBeValid(
            Guid id,
            string name,
            string description,
            Guid educatorId)
        {
            // Arrange: Подготовка данных
            // Данные передаются через параметризованный тест, данные уже подготовлены
            
            // Act: Создание экземпляра Course с валидными данными
            var course = new Course(id, name, description, educatorId);
            
            // Assert: Проверка свойств на валидность
            course.Id.Should().NotBeEmpty();
            course.Name.Should().NotBeEmpty();
            course.Description.Should().NotBeEmpty();
            course.EducatorId.Should().NotBeEmpty();
        }
        
        [Theory]
        [ClassData(typeof(TestCourseDataClass))]
        public void UpdateCourse_WithValidData_ShouldBeValid(
            Guid id,
            string name,
            string description,
            Guid educatorId)
        {
            // Arrange: Подготовка данных
            // Данные передаются через параметризованный тест, данные уже подготовлены
            // Создание экземпляра Course с валидными данными
            var course = new Course(id, name, description, educatorId);
            
            // Act: Обновление свойств Course
            course.Update(name, description, educatorId);
            
            // Assert: Проверка свойств на валидность после обновления
            course.Id.Should().NotBeEmpty();
            course.Name.Should().NotBeEmpty();
            course.Description.Should().NotBeEmpty();
            course.EducatorId.Should().NotBeEmpty();
        }
    }
}
