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
                Guid.Empty, Faker.Random.String2(8), new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
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
                Faker.Random.Guid(), Faker.Random.String2(8), null,
                GetRandomNonDefaultGender(), Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
                new Email(Faker.Internet.Email()), new Phone(Faker.Phone.PhoneNumber()), new Address(Faker.Address.City(), Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()))
            },
            
            new object[]
            {
                Faker.Random.Guid(), Faker.Random.String2(8), new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
                default, Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
                new Email(Faker.Internet.Email()), new Phone(Faker.Phone.PhoneNumber()), new Address(Faker.Address.City(), Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()))
            },
            
            new object[]
            {
                Faker.Random.Guid(), Faker.Random.String2(8), new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
                GetRandomNonDefaultGender(), default,
                new Email(Faker.Internet.Email()), new Phone(Faker.Phone.PhoneNumber()), new Address(Faker.Address.City(), Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()))
            },
            
            new object[]
            {
                Faker.Random.Guid(), Faker.Random.String2(8), new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
                GetRandomNonDefaultGender(), Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
                null, new Phone(Faker.Phone.PhoneNumber()), new Address(Faker.Address.City(), Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()))
            },
            
            new object[]
            {
                Faker.Random.Guid(), Faker.Random.String2(8), new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
                GetRandomNonDefaultGender(), Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)),
                new Email(Faker.Internet.Email()), null, new Address(Faker.Address.City(), Faker.Address.StreetName(),
                    int.Parse(Faker.Address.BuildingNumber()))
            },
            new object[]
            {
                Faker.Random.Guid(), Faker.Random.String2(8), new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()),
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
                Guid.Empty, Faker.Random.String2(8), Faker.Random.String2(8), Guid.NewGuid()
            },
            
            new object[]
            {
                Guid.NewGuid(), null, Faker.Random.String2(8), Guid.NewGuid()
            },
            
            new object[]
            {
                Guid.NewGuid(), Faker.Random.String2(8), null, Guid.NewGuid()
            },
            
            new object[]
            {
                Guid.NewGuid(), Faker.Random.String2(8), Faker.Random.String2(8), Guid.Empty
            },
        };
    }
    
    public static IEnumerable<object[]> GetEducatorProperties()
    {
        return new List<object[]>
        {
            new object[]
            {
                Guid.Empty, new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()), GetRandomNonDefaultGender(),
                new Phone(Faker.Phone.PhoneNumber()), Faker.Random.Byte(0, 60),
                Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
            },
            
            new object[]
            {
                Guid.NewGuid(), null, GetRandomNonDefaultGender(),
                new Phone(Faker.Phone.PhoneNumber()), Faker.Random.Byte(0, 60),
                Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
            },
            
            new object[]
            {
                Guid.Empty, new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()), default,
                new Phone(Faker.Phone.PhoneNumber()), Faker.Random.Byte(0, 60),
                Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
            },
            
            new object[]
            {
                Guid.Empty, new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()), GetRandomNonDefaultGender(),
                null, Faker.Random.Byte(0, 60), Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
            },
            
            new object[]
            {
                Guid.Empty, new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()), GetRandomNonDefaultGender(),
                new Phone(Faker.Phone.PhoneNumber()), -1,
                Faker.Date.BetweenDateOnly(MinDate, new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
            },
            
            new object[]
            {
                Guid.Empty, new FullName(Faker.Name.FirstName(), Faker.Name.LastName(), Faker.Name.LastName()), GetRandomNonDefaultGender(),
                new Phone(Faker.Phone.PhoneNumber()), Faker.Random.Byte(0, 60), default
            },
        };
    }
    
    private static Gender GetRandomNonDefaultGender()
    {
        var genders = Enum.GetValues(typeof(Gender)).Cast<Gender>()
            .Where(g => g != Gender.Default).ToArray();
        return Faker.Random.ArrayElement(genders);
    }
}