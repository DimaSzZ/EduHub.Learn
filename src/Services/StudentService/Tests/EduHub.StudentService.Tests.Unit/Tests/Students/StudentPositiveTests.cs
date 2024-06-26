using EduHub.StudentService.Shared.Tests.Infrastructure;
using EduHub.StudentService.Shared.Tests.Infrastructure.TestedData;

namespace Unit.Tests.Students
{
    /// <summary>
    /// Позитивные тесты для сущностей Student
    /// </summary>
    public class StudentPositiveTests
    {
        private readonly Faker _faker = new Faker();
        private readonly DateOnly _minBirthDate = new DateOnly(1900, 1, 1);
        
        /// <summary>
        /// Текст исключений при создании Student
        /// </summary>
        /// <param name="id">Валидность Id</param>
        /// <param name="avatar">Валидность аватара</param>
        /// <param name="fullName">Валидность ФИО</param>
        /// <param name="gender">Валидность пола</param>
        /// <param name="dateBirth">Валидность даты рождения</param>
        /// <param name="email">Валидность эл. почты</param>
        /// <param name="phone">Валидность номера телефона</param>
        /// <param name="address">Валидность адресса</param>
        [Theory]
        [ClassData(typeof(TestStudentDataClass))]
        public void SetStudent_WithValidData_ShouldBeValid(
            Guid id,
            string avatar,
            FullName fullName,
            Gender gender,
            DateOnly dateBirth,
            Email email,
            Phone phone,
            Address address)
        {
            // Arrange: Подготовка данных (данные передаются через параметризованный тест)
            
            // Act: Создаем объект Student с переданными параметрами
            var student = new Student(id, avatar, fullName, gender, dateBirth, email, phone, address);
            
            // Assert: Проверяем, что все свойства объекта заданы правильно
            student.Id.Should().NotBeEmpty();
            student.Avatar.Should().NotBeNullOrEmpty();
            student.FullName.Should().NotBeNull();
            student.Gender.Should().NotBe(Gender.Default);
            student.DateBirth.Should().BeAfter(_minBirthDate);
            student.Email.Should().NotBeNull();
            student.Phone.Should().NotBeNull();
            student.Address.Should().NotBeNull();
            student.Address.City.Should().NotBeNullOrEmpty();
            student.Address.Street.Should().NotBeNullOrEmpty();
            student.Address.NumberHouse.Should().BeGreaterThan(0);
        }
        
        /// <summary>
        /// Текс исключения при обновлении Student
        /// </summary>
        /// <param name="id">Валидность id</param>
        /// <param name="avatar">Валидность аватарки</param>
        /// <param name="fullName">Валидность ФИО</param>
        /// <param name="gender">Валидность пола</param>
        /// <param name="dateBirth">Валидность даты рождения</param>
        /// <param name="email">Валидность эл почты</param>
        /// <param name="phone">Валидность номера телефона</param>
        /// <param name="address">Валидность адресса</param>
        [Theory]
        [ClassData(typeof(TestStudentDataClass))]
        public void UpdateStudent_WithValidData_ShouldBeValid(
            Guid id,
            string avatar,
            FullName fullName,
            Gender gender,
            DateOnly dateBirth,
            Email email,
            Phone phone,
            Address address)
        {
            // Arrange: Подготовка данных (данные передаются через параметризованный тест)
            
            // Act: Создаем объект Student с переданными параметрами
            var student = new Student(id, avatar, fullName, gender, dateBirth, email, phone, address);
            
            // Act: Генерируем новые данные для обновления объекта Student
            var updatedAvatar = _faker.Random.String2(8);
            var updatedFullName = new FullName(_faker.Name.FirstName(), _faker.Name.LastName(), _faker.Name.LastName());
            var updatedGender = EnumGenerator.GetGender();
            var updatedDateBirth = _faker.Date.BetweenDateOnly(_minBirthDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
            var updatedEmail = new Email(_faker.Internet.Email());
            var updatedPhone = new Phone(_faker.Phone.PhoneNumber());
            var updatedAddress = new Address(_faker.Address.City(), _faker.Address.StreetName(), int.Parse(_faker.Address.BuildingNumber()));
            
            // Act: Обновляем данные объекта Student
            student.Update(updatedAvatar, updatedFullName, updatedGender, updatedDateBirth, updatedEmail, updatedPhone, updatedAddress);
            
            // Assert: Проверяем, что все свойства объекта заданы правильно после обновления
            student.Avatar.Should().NotBeNullOrEmpty();
            student.FullName.Should().NotBeNull();
            student.Gender.Should().NotBe(Gender.Default);
            student.DateBirth.Should().BeAfter(_minBirthDate);
            student.Email.Should().NotBeNull();
            student.Phone.Should().NotBeNull();
            student.Address.Should().NotBeNull();
            student.Address.City.Should().NotBeNullOrEmpty();
            student.Address.Street.Should().NotBeNullOrEmpty();
            student.Address.NumberHouse.Should().BeGreaterThan(0);
        }
    }
}