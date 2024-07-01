

using EduHub.StudentService.Shared.Tests.Infrastructure;

namespace Unit.Tests.Educators
{
    /// <summary>
    /// Позитивные тесты для сущностей Educator
    /// </summary>
    public class EducatorNegativeTests
    {
        public static readonly IEnumerable<object[]> EducatorProperties = TestedClass.GetEducatorProperties();
            
        /// <summary>
        /// Тест исключений при создании Educator
        /// </summary>
        /// <param name="id">Валидность Id</param>
        /// <param name="fullName">Валидность ФИО</param>
        /// <param name="gender">Валидность пола</param>
        /// <param name="phone">Валидность номера телефона</param>
        /// <param name="workExp">Валидность рабочего опыта</param>
        /// <param name="dateEmployment">Валидность даты поступления на работу</param>
        [Theory]
        [MemberData(nameof(EducatorProperties))]
        public void SetEducator_WithNullData_ShouldBeInvalid(
            Guid id,
            FullName fullName,
            Gender gender,
            Phone phone,
            int workExp,
            DateOnly dateEmployment)
        {
            // Arrange: Подготовка данных
            // Данные передаются через параметризованный тест, данные уже подготовлены
            
            // Act: Лямбда-выражение для создания педагога с нулевыми данными
            var educator = () => new Educator(id, fullName, gender, phone, workExp, dateEmployment);
            
            // Assert: Проверка, что при создании педагога с нулевыми данными выбрасывается исключение ArgumentException
            educator.Should().Throw<ArgumentException>();
        }
    }
}