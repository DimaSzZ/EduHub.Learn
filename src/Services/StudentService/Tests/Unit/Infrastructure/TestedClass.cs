namespace Unit.Infrastructure;

public static class TestedClass
{
    private static readonly Faker Faker = new Faker();
    private static readonly DateOnly MinDate = new DateOnly(1900, 1, 1);
    
    public static IEnumerable<object[]> GetStudentProperties()
    {
        return new List<object[]>
        {
            new object[]
            {
                Guid.Empty, Faker.Random.String(), new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
                GetRandomNonDefaultGender(), Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
                new Email(Faker.Internet.Email()), new Phone(Faker.Phone.PhoneNumber()), new Address(Faker.Address.City(), Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()))
            },
            
            new object[]
            {
                Faker.Random.Guid(), null, new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
                GetRandomNonDefaultGender(), Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
                new Email(Faker.Internet.Email()), new Phone(Faker.Phone.PhoneNumber()), new Address(Faker.Address.City(), Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()))
            },
            
            new object[]
            {
                Faker.Random.Guid(), Faker.Random.String(), null,
                GetRandomNonDefaultGender(), Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
                new Email(Faker.Internet.Email()), new Phone(Faker.Phone.PhoneNumber()), new Address(Faker.Address.City(), Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()))
            },
            
            new object[]
            {
                Faker.Random.Guid(), Faker.Random.String(), new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
                default, Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
                new Email(Faker.Internet.Email()), new Phone(Faker.Phone.PhoneNumber()), new Address(Faker.Address.City(), Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()))
            },
            
            new object[]
            {
                Faker.Random.Guid(), Faker.Random.String(), new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
                GetRandomNonDefaultGender(), default,
                new Email(Faker.Internet.Email()), new Phone(Faker.Phone.PhoneNumber()), new Address(Faker.Address.City(), Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()))
            },
            
            new object[]
            {
                Faker.Random.Guid(), Faker.Random.String(), new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
                GetRandomNonDefaultGender(), Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
                null, new Phone(Faker.Phone.PhoneNumber()), new Address(Faker.Address.City(), Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()))
            },
            
            new object[]
            {
                Faker.Random.Guid(), Faker.Random.String(), new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
                GetRandomNonDefaultGender(), Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
                new Email(Faker.Internet.Email()), null, new Address(Faker.Address.City(), Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()))
            },
            new object[]
            {
                Faker.Random.Guid(), Faker.Random.String(), new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
                GetRandomNonDefaultGender(), Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
                new Email(Faker.Internet.Email()), new Phone(Faker.Phone.PhoneNumber()), null
            }
        };
    }
    
    public static IEnumerable<object[]> GetEnrollmentProperties()
    {
        return new List<object[]>
        {
            new object[]
            {
                Guid.Empty, Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)), Guid.NewGuid(),
                Guid.NewGuid()
            },
            
            new object[]
            {
                Guid.Empty, default, Guid.NewGuid(), Guid.NewGuid()
            },
            
            new object[]
            {
                Guid.NewGuid(), Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
                Guid.Empty, Guid.NewGuid()
            },
            
            new object[]
            {
                Guid.NewGuid(), Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
                Guid.NewGuid(), Guid.Empty
            },
        };
    }
    
    public static IEnumerable<object[]> GetCourseProperties()
    {
        return new List<object[]>
        {
            new object[]
            {
                Guid.Empty, Faker.Random.String(), Faker.Random.String(), Guid.NewGuid()
            },
            
            new object[]
            {
                Guid.NewGuid(), null, Faker.Random.String(), Guid.NewGuid()
            },
            
            new object[]
            {
                Guid.NewGuid(), Faker.Random.String(), null, Guid.NewGuid()
            },
            
            new object[]
            {
                Guid.NewGuid(), Faker.Random.String(), Faker.Random.String(), Guid.Empty
            },
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