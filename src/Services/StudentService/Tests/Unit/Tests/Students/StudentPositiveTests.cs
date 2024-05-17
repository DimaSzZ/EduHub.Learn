using System.Collections;

namespace Unit.Tests.Students
{
    // Класс, реализующий IEnumerable<object[]> для предоставления данных для тестов
    public class TestStudentDataClass : IEnumerable<object[]>
    {
        private readonly Faker _faker = new Faker(); // Используем библиотеку Faker для генерации случайных данных
        private readonly DateOnly _minBirthDate = new DateOnly(1900, 1, 1); // Минимальная дата для генерации случайных дат рождения

        // Реализация метода GetEnumerator для предоставления данных для тестов
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                _faker.Random.Guid(), // Генерация случайного GUID для id
                _faker.Random.String(), // Генерация случайной строки для avatar
                new FullName(_faker.Name.FirstName(), _faker.Name.LastName(), _faker.Name.LastName()), // Генерация случайного полного имени
                GetRandomNonDefaultGender(), // Получение случайного значения пола, отличного от значения по умолчанию
                _faker.Date.BetweenDateOnly(_minBirthDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)), // Генерация случайной даты между минимальной датой и текущей датой
                new Email(_faker.Internet.Email()), // Генерация случайного email
                new Phone(_faker.Phone.PhoneNumber()), // Генерация случайного номера телефона
                new Address(_faker.Address.City(), _faker.Address.StreetName(), int.Parse(_faker.Address.BuildingNumber())) // Генерация случайного адреса
            };
        }

        // Метод для получения случайного значения пола, отличного от значения по умолчанию
        private Gender GetRandomNonDefaultGender()
        {
            var genders = Enum.GetValues(typeof(Gender)).Cast<Gender>()
                .Where(g => g != Gender.Default).ToArray();
            return _faker.Random.ArrayElement(genders);
        }
        
        // Реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class StudentPositiveTests
    {
        private readonly Faker _faker = new Faker(); // Используем библиотеку Faker для генерации случайных данных
        private readonly DateOnly _minBirthDate = new DateOnly(1900, 1, 1); // Минимальная дата для генерации случайных дат рождения

        // Теоретический тест, использующий данные из класса TestStudentDataClass
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
            // Создаем объект Student с переданными параметрами
            var student = new Student(id, avatar, fullName, gender, dateBirth, email, phone, address);

            // Проверяем, что все свойства объекта заданы правильно
            student.Id.Should().NotBeEmpty(); // Id не должен быть пустым
            student.Avatar.Should().NotBeNullOrEmpty(); // Avatar не должен быть пустым или null
            student.FullName.Should().NotBeNull(); // FullName не должен быть null
            student.Gender.Should().NotBe(Gender.Default); // Gender не должен быть значением по умолчанию
            student.DateBirth.Should().BeAfter(_minBirthDate); // Дата рождения должна быть после минимальной даты
            student.Email.Should().NotBeNull().And.BeOfType<Email>(); // Email не должен быть null и должен быть типа Email
            student.Phone.Should().NotBeNull().And.BeOfType<Phone>(); // Phone не должен быть null и должен быть типа Phone
            student.Address.Should().NotBeNull(); // Address не должен быть null
            student.Address.City.Should().NotBeNullOrEmpty(); // Город не должен быть пустым или null
            student.Address.Street.Should().NotBeNullOrEmpty(); // Улица не должна быть пустой или null
            student.Address.NumberHouse.Should().BeGreaterThan(0); // Номер дома должен быть больше 0
        }

        // Теоретический тест для проверки обновления данных объекта Student
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
            // Создаем объект Student с переданными параметрами
            var student = new Student(id, avatar, fullName, gender, dateBirth, email, phone, address);

            // Генерируем новые данные для обновления объекта Student
            string updatedAvatar = _faker.Random.String2(8);
            FullName updatedFullName = new FullName(_faker.Name.FirstName(), _faker.Name.LastName(), _faker.Name.LastName());
            Gender updatedGender = _faker.Random.Enum<Gender>();
            DateOnly updatedDateBirth = _faker.Date.BetweenDateOnly(_minBirthDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
            Email updatedEmail = new Email(_faker.Internet.Email());
            Phone updatedPhone = new Phone(_faker.Phone.PhoneNumber());
            Address updatedAddress = new Address(_faker.Address.City(), _faker.Address.StreetName(), int.Parse(_faker.Address.BuildingNumber()));

            // Обновляем данные объекта Student
            student.Update(updatedAvatar, updatedFullName, updatedGender, updatedDateBirth, updatedEmail, updatedPhone, updatedAddress);

            // Проверяем, что все свойства объекта заданы правильно после обновления
            student.Avatar.Should().NotBeNullOrEmpty(); // Avatar не должен быть пустым или null
            student.FullName.Should().NotBeNull(); // FullName не должен быть null
            student.Gender.Should().NotBe(Gender.Default); // Gender не должен быть значением по умолчанию
            student.DateBirth.Should().BeAfter(_minBirthDate); // Дата рождения должна быть после минимальной даты
            student.Email.Should().NotBeNull().And.BeOfType<Email>(); // Email не должен быть null и должен быть типа Email
            student.Phone.Should().NotBeNull().And.BeOfType<Phone>(); // Phone не должен быть null и должен быть типа Phone
            student.Address.Should().NotBeNull(); // Address не должен быть null
            student.Address.City.Should().NotBeNullOrEmpty(); // Город не должен быть пустым или null
            student.Address.Street.Should().NotBeNullOrEmpty(); // Улица не должна быть пустой или null
            student.Address.NumberHouse.Should().BeGreaterThan(0); // Номер дома должен быть больше 0
        }

        // Теоретический тест для проверки эквивалентности двух объектов Student с одинаковыми данными
        [Theory]
        [ClassData(typeof(TestStudentDataClass))]
        public void SetStudent_WithSameData_ShouldBeEquivalent(
            Guid id,
            string avatar,
            FullName fullName,
            Gender gender,
            DateOnly dateBirth,
            Email email,
            Phone phone,
            Address address)
        {
            // Создаем два объекта Student с одинаковыми данными
            var student1 = new Student(id, avatar, fullName, gender, dateBirth, email, phone, address);
            var student2 = new Student(id, avatar, fullName, gender, dateBirth, email, phone, address);

            // Проверяем, что оба объекта эквивалентны
            student1.Should().BeEquivalentTo(student2);
        }

        // Теоретический тест для проверки эквивалентности двух объектов Student после обновления их данными
        [Theory]
        [ClassData(typeof(TestStudentDataClass))]
        public void UpdateStudent_WithSameData_ShouldBeEquivalent(
            Guid id,
            string avatar,
            FullName fullName,
            Gender gender,
            DateOnly dateBirth,
            Email email,
            Phone phone,
            Address address)
        {
            // Создаем два объекта Student с одинаковыми данными
            var student1 = new Student(id, avatar, fullName, gender, dateBirth, email, phone, address);
            var student2 = new Student(id, avatar, fullName, gender, dateBirth, email, phone, address);

            // Генерируем новые данные для обновления объектов Student
            string updatedAvatar = _faker.Random.String2(8);
            FullName updatedFullName = new FullName(_faker.Name.FirstName(), _faker.Name.LastName(), _faker.Name.LastName());
            Gender updatedGender = _faker.Random.Enum<Gender>();
            DateOnly updatedDateBirth = _faker.Date.BetweenDateOnly(_minBirthDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
            Email updatedEmail = new Email(_faker.Internet.Email());
            Phone updatedPhone = new Phone(_faker.Phone.PhoneNumber());
            Address updatedAddress = new Address(_faker.Address.City(), _faker.Address.StreetName(), int.Parse(_faker.Address.BuildingNumber()));

            // Обновляем данные обоих объектов Student
            student1.Update(updatedAvatar, updatedFullName, updatedGender, updatedDateBirth, updatedEmail, updatedPhone, updatedAddress);
            student2.Update(updatedAvatar, updatedFullName, updatedGender, updatedDateBirth, updatedEmail, updatedPhone, updatedAddress);

            // Проверяем, что оба объекта эквивалентны после обновления
            student1.Should().BeEquivalentTo(student2);
        }
    }
}
