namespace EduHub.StudentService.Application.Services.Primitives;

public static class RegexPatterns
{
    /// <summary>
    /// Паттерн для валидации ФИО человека
    /// </summary>
    public const string NamePattern = @"^[\p{L}\s'-]+$";
        
    /// <summary>
    /// Паттерн для проверки ПМР номера телефона
    /// </summary>
    public const string PmrPhonePattern = @"^\+373(2\d{7}|[67]\d{7})$";
        
    /// <summary>
    /// Паттерн для проверки эл. почты
    /// </summary>
    public const string EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        
    /// <summary>
    /// Паттерн для проверки ссылка на файл аватарки
    /// </summary>
    public const string FilePngJpgPattern = @"^https?://.*\.(png|jpg)$";
}