namespace Unit.Infrastructure.TestedData;

public static class EnumGenerator
{
    public static Gender GetRandomNonDefaultGender()
    {
        var faker = new Faker();
        return faker.PickRandom(Gender.Man, Gender.Woman);
    }
}