using Unit.Infrastructure;

namespace Unit.Tests.Students
{
    public class StudentNegativeTests
    {
        // Определяем статическое поле, содержащее набор тестовых данных, полученных из класса TestedClass
        public static readonly IEnumerable<object[]> StudentProperties = TestedClass.GetStudentProperties();
        
        // Атрибут Theory указывает на теоретический тест, который будет запущен с несколькими наборами данных
        // MemberData атрибут указывает, что наборы данных для теста берутся из статического поля StudentProperties
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
            // Определяем делегат, создающий новый объект Student с переданными параметрами
            var student = () => new Student(id, avatar, fullName, gender, dateBirth, email, phone, address);
            
            // Проверяем, что при создании объекта Student с указанными параметрами будет выброшено исключение ArgumentException
            student.Should().Throw<ArgumentException>();
        }
    }
}