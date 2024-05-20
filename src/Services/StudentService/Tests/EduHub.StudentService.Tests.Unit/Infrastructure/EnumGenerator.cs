namespace Unit.Infrastructure.TestedData;

/// <summary>
/// Класс который служит для генерации Enum сущностей
/// </summary>
public static class EnumGenerator
{
    /// <summary>
    /// Генерирует пол человека не равный default
    /// </summary>
    /// <returns>
    /// Генерирует пол человека не равный default
    /// </returns>
    public static Gender GetGender()
    {
        var faker = new Faker();
        return faker.PickRandom(Gender.Man, Gender.Woman);
    }
}