using Unit.Infrastructure;

namespace Unit.Tests.Educators
{
    public class EducatorNegativeTests
    {
        public static readonly IEnumerable<object[]> EducatorProperties = TestedClass.GetEducatorProperties();
        
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