using Unit.Infrastructure;

namespace Unit.Tests.Students
{
    /// <summary>
    /// Негативные тесты для сущностей Student
    /// </summary>
    public class StudentNegativeTests
    {
        public static readonly IEnumerable<object[]> StudentProperties = TestedClass.GetStudentProperties();
        
        /// <summary>
        /// Текст исключение для Student
        /// </summary>
        /// <param name="id">Валидность id</param>
        /// <param name="avatar">Валидность аватара</param>
        /// <param name="fullName">Валидность ФИО</param>
        /// <param name="gender">Валидность пола</param>
        /// <param name="dateBirth">Валидность даты рождения</param>
        /// <param name="email">Валидность эл почты</param>
        /// <param name="phone">Валидность номера телефона</param>
        /// <param name="address">Валидность адресса</param>
        [Theory]
        [MemberData(nameof(StudentProperties))]
        public void SetStudent_WithNullData_ShouldBeInvalid(
            Guid id,
            string avatar,
            FullName fullName,
            Gender gender,
            DateOnly dateBirth,
            Email email,
            Phone phone,
            Address address)
        {
            // Arrange: Подготовка данных
            // Данные передаются через параметризованный тест, данные уже подготовлены
            
            // Act: Определяем делегат, создающий новый объект Student с переданными параметрами
            var student = () => new Student(id, avatar, fullName, gender, dateBirth, email, phone, address);
            
            // Assert: Проверка, что при создании объекта Student с указанными параметрами будет выброшено исключение ArgumentException
            student.Should().Throw<ArgumentException>();
        }
    }
}