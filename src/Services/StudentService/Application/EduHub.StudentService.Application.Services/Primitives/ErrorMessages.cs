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
    public const string Required = "{0} is required";
    
    /// <summary>
    /// Ошибка проверки на максимальную длину объекта
    /// </summary>
    /// <remarks>
    /// использовать вместе с string.Format
    /// {0} - имя объекта
    /// </remarks>
    public const string MaxLength = "The object {0} has exceeded the maximum length";
    
    /// <summary>
    /// Ошибка проверки на минимальную длину объекта
    /// </summary>
    /// <remarks>
    /// использовать вместе с string.Format
    /// {0} - имя объекта
    /// </remarks>
    public const string MinLength = "The object {0} has exceeded the minimum length";
    
    /// <summary>
    /// Ошибка проверки на корректность названия
    /// </summary>
    /// <remarks>
    /// использовать вместе с string.Format
    /// {0} - имя объекта
    /// </remarks>
    public const string BadName = "The object {0} was named incorrectly";
    
    /// <summary>
    /// Ошибка проверки на корректность номера телефона
    /// </summary>
    public const string BadPhone = "Incorrect phone number";
    
    /// <summary>
    /// Ошибка проверки на дефолтное значение названия
    /// </summary>
    /// <remarks>
    /// использовать вместе с string.Format
    /// {0} - имя объекта
    /// </remarks>
    public const string NotDefault = "Object gender {0} should not be default";
    
    /// <summary>
    /// Ошибка проверки на корректность даты
    /// </summary>
    public const string BadDate = "Incorrect Date";
    
    /// <summary>
    /// Ошибка проверки на корректность почтового ящика
    /// </summary>
    public const string BadEmail = "Incorrect Email";
    
    /// <summary>
    /// Ошибка проверки на корректность ссылки на аватарку
    /// </summary>
    /// <remarks>
    /// использовать вместе с string.Format
    /// {0} - имя объекта
    /// </remarks>
    public const string BadFile = "Object {0} has incorrect format file";
}