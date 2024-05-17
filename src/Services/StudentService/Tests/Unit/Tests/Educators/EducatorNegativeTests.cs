using Unit.Infrastructure;

namespace Unit.Tests.Educators
{
    // Класс для тестирования негативных сценариев для педагогов
    public class EducatorNegativeTests
    {
        // Поле, содержащее набор свойств педагога для использования в тестах
        public static readonly IEnumerable<object[]> EducatorProperties = TestedClass.GetEducatorProperties();
        
        // Тест на создание педагога с нулевыми данными
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
            // Лямбда-выражение для создания педагога с нулевыми данными и проверки на исключение ArgumentException
            var educator = () => new Educator(id, fullName, gender, phone, workExp, dateEmployment);
            
            educator.Should().Throw<ArgumentException>(); // Проверка, что при создании педагога с нулевыми данными выбрасывается исключение ArgumentException
        }
    }
}