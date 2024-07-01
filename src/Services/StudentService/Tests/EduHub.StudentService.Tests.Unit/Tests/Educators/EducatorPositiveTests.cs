

using EduHub.StudentService.Shared.Tests.Infrastructure.TestedData;

namespace Unit.Tests.Educators
{
    /// <summary>
    /// Позитивные тесты для сущностей Educator
    /// </summary>
    public class EducatorPositiveTests
    {
        /// <summary>
        /// Тест исключений при создании Educator
        /// </summary>
        /// <param name="id">Валидность Id</param>
        /// <param name="fullName">Валидность ФИО</param>
        /// <param name="gender">Валидность пола</param>
        /// <param name="phone">Валидность пола</param>
        /// <param name="workExp">Валидность рабочего опыта</param>
        /// <param name="dateEmployment">Валидность даты поступления на работу</param>
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
        
        /// <summary>
        /// Тест исключений при создании Educator
        /// </summary>
        /// <param name="id">Валидность Id</param>
        /// <param name="fullName">Валидность ФИО</param>
        /// <param name="gender">Валидность пола</param>
        /// <param name="phone">Валидность пола</param>
        /// <param name="workExp">Валидность рабочего опыта</param>
        /// <param name="dateEmployment">Валидность даты поступления на работу</param>
        [Theory]
        [ClassData(typeof(TestEducatorDataClass))]
        public void UpdateEducator_WithValidData_ShouldBeValid(
            Guid id,
            FullName fullName,
            Gender gender,
            Phone phone,
            int workExp,
            DateOnly dateEmployment)
        {
            // Arrange: Подготовка данных
            // Данные передаются через параметризованный тест, данные уже подготовлены
            
            // Act: Создание экземпляра Educator с валидными данными и обновляем его
            var educator = new Educator(id, fullName, gender, phone, workExp, dateEmployment);
            
            educator.Update(fullName,gender,phone,workExp,dateEmployment);
            
            // Assert: Проверяем, что все свойства объекта заданы правильно после обновления
            educator.FullName.Should().NotBeNull();
            educator.Gender.Should().NotBe(Gender.Default);
            educator.YearsExperience.Should().BeGreaterThan(-1);
            educator.DateEmployment.Should().NotBe(default);
            educator.Phone.Should().NotBeNull();
        }
    }
}