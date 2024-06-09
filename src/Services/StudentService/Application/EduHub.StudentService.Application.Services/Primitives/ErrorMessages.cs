namespace EduHub.StudentService.Application.Services.Primitives;

/// <summary>
/// Класс исключений
/// </summary>
public static class ErrorMessages
{
    /// <summary>
    /// 404 ошибка
    /// </summary>
    /// <remarks>
    /// использовать вместе с string.Format
    /// {0} - имя объекта
    /// {1} - имя свойства
    /// {2} - значение свойства
    /// </remarks>
    public const string NotFound = "{0} with {1} '{2}' not found.";
    
    /// <summary>
    /// Конфликтная ошибка
    /// </summary>
    /// <remarks>
    /// использовать вместе с string.Format
    /// {0} - имя объекта
    /// {1} - имя свойства
    /// {2} - значение свойства
    /// </remarks>
    public const string Conflict = "{0} with {1} '{2}' is conflicted.";
    
    /// <summary>
    /// Ошибка проверки на пустоту(Empty)
    /// </summary>
    /// <remarks>
    /// использовать вместе с string.Format
    /// {0} - имя объекта
    /// </remarks>
    public const string Required = "{0}.{1} is required";
    
    /// <summary>
    /// Ошибка проверки на максимальную длину объекта
    /// </summary>
    /// <remarks>
    /// использовать вместе с string.Format
    /// {0} - имя объекта
    /// </remarks>
    public const string MaxLength = "The object {0}.{1} has exceeded the maximum length";
    
    /// <summary>
    /// Ошибка проверки на минимальную длину объекта
    /// </summary>
    /// <remarks>
    /// использовать вместе с string.Format
    /// {0} - имя объекта
    /// </remarks>
    public const string MinLength = "The object {0}.{1} has exceeded the minimum length";
    
    /// <summary>
    /// Ошибка проверки на корректность названия
    /// </summary>
    /// <remarks>
    /// использовать вместе с string.Format
    /// {0} - имя объекта
    /// </remarks>
    public const string BadName = "The object {0}.{1} was named incorrectly";
    
    /// <summary>
    /// Ошибка проверки на корректность номера телефона
    /// </summary>
    public const string BadPhone = "Incorrect {0}.{1} phone number";
    
    /// <summary>
    /// Ошибка проверки на дефолтное значение названия
    /// </summary>
    /// <remarks>
    /// использовать вместе с string.Format
    /// {0} - имя объекта
    /// </remarks>
    public const string NotDefault = "Object gender {0}.{1} should not be default";
    
    /// <summary>
    /// Ошибка проверки на корректность даты
    /// </summary>
    public const string BadDate = "Incorrect Date {0}.{1}";
    
    /// <summary>
    /// Ошибка проверки на корректность почтового ящика
    /// </summary>
    public const string BadEmail = "Incorrect Email {0}.{1}";
    
    /// <summary>
    /// Ошибка проверки на корректность ссылки на аватарку
    /// </summary>
    /// <remarks>
    /// использовать вместе с string.Format
    /// {0} - имя объекта
    /// </remarks>
    public const string BadFile = "Object {0}.{1} has incorrect format file";
}