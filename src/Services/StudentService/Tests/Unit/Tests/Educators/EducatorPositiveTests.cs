using Unit.Infrastructure.TestedData;

namespace Unit.Tests.Educators
{
    public class EducatorPositiveTests
    {
        [Theory]
        [ClassData(typeof(TestEducatorDataClass))]
        public void SetEducator_WithValidData_ShouldBeValid(
            Guid id,
            FullName fullName,
            Gender gender,
            Phone phone,
            int workExp,
            DateOnly dateEmployment)
        {
            // Arrange: Подготовка данных
            // Данные передаются через параметризованный тест, данные уже подготовлены
            
            // Act: Создание экземпляра Educator с валидными данными
            var educator = new Educator(id, fullName, gender, phone, workExp, dateEmployment);
            
            // Assert: Проверка корректности создания объекта
            educator.Id.Should().NotBeEmpty();
            educator.FullName.Should().NotBeNull();
            educator.Gender.Should().NotBe(Gender.Default); 
            educator.YearsExperience.Should().BeGreaterThan(-1); 
            educator.DateEmployment.Should().NotBe(default); 
            educator.Phone.Should().NotBeNull(); 
        }
    }
}