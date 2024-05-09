namespace Unit.Tests.Students;

public class StudentNegativeTests
{
    public static readonly IEnumerable<object[]> StudentProperties = GetStudentProperties();
    private static readonly Faker Faker = new Faker();
    private static readonly DateOnly MinBirthDate = new DateOnly(1900, 1, 1);
        
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
        var student = () => new Student(id,avatar,fullName,gender,dateBirth,email,phone,address);
        student.Should().Throw<Exception>();
    }
    
    [Theory]
    [ClassData(typeof(TestStudentDataClass))]
    public void UpdateStudent_WithNullData_ShouldBeInvalid(
        Guid id,
        string avatar,
        FullName fullName,
        Gender gender,
        DateOnly dateBirth,
        Email email,
        Phone phone,
        Address address)
    {
        var student = () => new Student(id,avatar,fullName,gender,dateBirth,email,phone,address).Update(avatar,fullName,gender,dateBirth,email,phone,address);
        student.Should().Throw<Exception>();
    }
    
    private static IEnumerable<object[]> GetStudentProperties()
    {
        return new List<object[]>
        {
            new object[] {
                Guid.Empty, Faker.Random.String(), new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
                GetRandomNonDefaultGender(), Faker.Date.BetweenDateOnly(MinBirthDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
                new Email(Faker.Internet.Email()), new Phone(Faker.Phone.PhoneNumber()), new Address(Faker.Address.City(), Faker.Address.StreetName(), 
                    int.Parse(Faker.Address.BuildingNumber()))},
            
            new object[] {    
                Faker.Random.Guid(), null, new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
                GetRandomNonDefaultGender(), Faker.Date.BetweenDateOnly(MinBirthDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
                new Email(Faker.Internet.Email()), new Phone(Faker.Phone.PhoneNumber()), new Address(Faker.Address.City(), Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()))},
            
            new object[] {    
                Faker.Random.Guid(), Faker.Random.String(), null,
                GetRandomNonDefaultGender(), Faker.Date.BetweenDateOnly(MinBirthDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
                new Email(Faker.Internet.Email()), new Phone(Faker.Phone.PhoneNumber()), new Address(Faker.Address.City(), Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()))},
            
            new object[] {
                Faker.Random.Guid(), Faker.Random.String(), new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
                default, Faker.Date.BetweenDateOnly(MinBirthDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
                new Email(Faker.Internet.Email()), new Phone(Faker.Phone.PhoneNumber()), new Address(Faker.Address.City(), Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()))},
            
            new object[] {    
                Faker.Random.Guid(), Faker.Random.String(), new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
                GetRandomNonDefaultGender(),default,
                new Email(Faker.Internet.Email()), new Phone(Faker.Phone.PhoneNumber()), new Address(Faker.Address.City(), Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()))},
            
            new object[] {   
                Faker.Random.Guid(), Faker.Random.String(), new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
                GetRandomNonDefaultGender(), Faker.Date.BetweenDateOnly(MinBirthDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
                null, new Phone(Faker.Phone.PhoneNumber()), new Address(Faker.Address.City(), Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()))},
            
            new object[]{
                Faker.Random.Guid(), Faker.Random.String(), new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
                GetRandomNonDefaultGender(), Faker.Date.BetweenDateOnly(MinBirthDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
                new Email(Faker.Internet.Email()),null, new Address(Faker.Address.City(), Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()))},
            new object[]{    
                Faker.Random.Guid(), Faker.Random.String(), new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
                GetRandomNonDefaultGender(), Faker.Date.BetweenDateOnly(MinBirthDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
                new Email(Faker.Internet.Email()), new Phone(Faker.Phone.PhoneNumber()), null}
        };
    }
    
    private static Gender GetRandomNonDefaultGender()
    {
        Gender randomGender;
        
        do
        {
            randomGender = Faker.Random.Enum<Gender>();
        } while (randomGender == Gender.Default);
        
        return randomGender;
    }
}