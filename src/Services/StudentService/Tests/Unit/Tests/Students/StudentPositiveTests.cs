using System.Collections;

namespace Unit.Tests.Students;

public class TestStudentDataClass : IEnumerable<object[]>
{
    private readonly Faker _faker = new Faker();
    private readonly DateOnly _minBirthDate = new DateOnly(1900, 1, 1);
    
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            _faker.Random.Guid(),
            _faker.Random.String(),
            new FullName(_faker.Name.FirstName(), _faker.Name.LastName(), _faker.Name.LastName()),
            GetRandomNonDefaultGender(),
            _faker.Date.BetweenDateOnly(_minBirthDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
            new Email(_faker.Internet.Email()),
            new Phone(_faker.Phone.PhoneNumber()),
            new Address(_faker.Address.City(), _faker.Address.StreetName(), int.Parse(_faker.Address.BuildingNumber()))
        };
    }
    
    private Gender GetRandomNonDefaultGender()
    {
        Gender randomGender;
        
        do
        {
            randomGender = _faker.Random.Enum<Gender>();
        } while (randomGender == Gender.Default);
        
        return randomGender;
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class StudentPositiveTests
{
    private readonly Faker _faker = new Faker();
    private readonly DateOnly _minBirthDate = new DateOnly(1900, 1, 1);
    
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
        var student = new Student(id, avatar, fullName, gender, dateBirth, email, phone, address);
        
        student.Id.Should().NotBeEmpty();
        student.Avatar.Should().NotBeNullOrEmpty();
        student.FullName.Should().NotBeNull();
        student.Gender.Should().NotBe(Gender.Default);
        student.DateBirth.Should().BeAfter(_minBirthDate);
        student.Email.Should().NotBeNull().And.BeOfType<Email>();
        student.Phone.Should().NotBeNull().And.BeOfType<Phone>();
        student.Address.Should().NotBeNull();
        student.Address.City.Should().NotBeNullOrEmpty();
        student.Address.Street.Should().NotBeNullOrEmpty();
        student.Address.NumberHouse.Should().BeGreaterThan(0);
    }
    
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
        var student = new Student(id,avatar,fullName,gender,dateBirth,email,phone,address);
        
        string updatedAvatar = _faker.Random.String();
        FullName updatedFullName = new FullName(_faker.Name.FirstName(),_faker.Name.LastName(),_faker.Name.LastName());
        Gender updatedGender = _faker.Random.Enum<Gender>();
        DateOnly updatedDateBirth = _faker.Date.BetweenDateOnly(_minBirthDate,new DateOnly(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day));
        Email updatedEmail = new Email(_faker.Internet.Email());
        Phone updatedPhone = new Phone(_faker.Phone.PhoneNumber());
        Address updatedAddress = new Address(_faker.Address.City(),_faker.Address.StreetName(),int.Parse(_faker.Address.BuildingNumber()));
        
        
        student.Update(updatedAvatar,updatedFullName,updatedGender,updatedDateBirth,updatedEmail,updatedPhone,updatedAddress);
      
        student.Avatar.Should().NotBeNullOrEmpty();
        student.FullName.Should().NotBeNull();
        student.Gender.Should().NotBe(Gender.Default);
        student.DateBirth.Should().BeAfter(_minBirthDate);
        student.Email.Should().NotBeNull().And.BeOfType<Email>();
        student.Phone.Should().NotBeNull().And.BeOfType<Phone>();
        student.Address.Should().NotBeNull();
        student.Address.City.Should().NotBeNullOrEmpty();
        student.Address.Street.Should().NotBeNullOrEmpty();
        student.Address.NumberHouse.Should().BeGreaterThan(0);
    }
    
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
        var student1 = new Student(id, avatar, fullName, gender, dateBirth, email, phone, address);
        var student2 = new Student(id, avatar, fullName, gender, dateBirth, email, phone, address);
        
        student1.Should().BeEquivalentTo(student2);
    }
    
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
        var student1 = new Student(id, avatar, fullName, gender, dateBirth, email, phone, address);
        var student2 = new Student(id, avatar, fullName, gender, dateBirth, email, phone, address);
        
        string updatedAvatar = _faker.Random.String();
        FullName updatedFullName = new FullName(_faker.Name.FirstName(),_faker.Name.LastName(),_faker.Name.LastName());
        Gender updatedGender = _faker.Random.Enum<Gender>();
        DateOnly updatedDateBirth = _faker.Date.BetweenDateOnly(_minBirthDate,new DateOnly(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day));
        Email updatedEmail = new Email(_faker.Internet.Email());
        Phone updatedPhone = new Phone(_faker.Phone.PhoneNumber());
        Address updatedAddress = new Address(_faker.Address.City(),_faker.Address.StreetName(),int.Parse(_faker.Address.BuildingNumber()));
        
        student1.Update(updatedAvatar,updatedFullName,updatedGender,updatedDateBirth,updatedEmail,updatedPhone,updatedAddress);
        student2.Update(updatedAvatar,updatedFullName,updatedGender,updatedDateBirth,updatedEmail,updatedPhone,updatedAddress);
        
        
        student1.Should().BeEquivalentTo(student2);
    }
}