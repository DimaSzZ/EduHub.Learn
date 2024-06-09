using EduHub.StudentService.Application.Services.Primitives;
using EduHub.StudentService.Domain.Entities.Enums;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Validations;

/// <summary>
/// Расширения для валидатора
/// </summary>
public static class ValidatorExtension
{
    /// <summary>
    /// Валидация имени персоны
    /// </summary>
    /// <param name="ruleBuilder"> свойство, хранящее объект и тип данных для проверки</param>
    /// <typeparam name="T"> объект, который будет валидироваться</typeparam>
    /// <returns>Возвращает отвалидированный объект</returns>
    public static IRuleBuilderOptions<T, string> PersonName<T>(this IRuleBuilder<T, string> ruleBuilder, string propertyName)
    {
        return ruleBuilder
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(T), propertyName))
            .MinimumLength(2).WithMessage(string.Format(ErrorMessages.MinLength, nameof(T), propertyName))
            .MaximumLength(60).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(T), propertyName))
            .Matches(RegexPatterns.NamePattern).WithMessage(string.Format(ErrorMessages.BadName, nameof(T), propertyName));
    }
    
    /// <summary>
    /// Проверка на валидность Id
    /// </summary>
    /// <param name="ruleBuilder"> свойство, хранящее объект и тип данных для проверки</param>
    /// <typeparam name="T"> объект, который будет валидироваться</typeparam>
    /// <returns>Возвращает отвалидированный объект</returns>
    public static IRuleBuilderOptions<T, Guid> Id<T>(this IRuleBuilder<T, Guid> ruleBuilder, string propertyName)
    {
        return ruleBuilder
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(T), propertyName));
    }
    
    /// <summary>
    /// Проверка на валидность даты
    /// </summary>
    /// <param name="ruleBuilder"> свойство, хранящее объект и тип данных для проверки</param>
    /// <typeparam name="T"> объект, который будет валидироваться</typeparam>
    /// <returns>Возвращает отвалидированный объект</returns>
    public static IRuleBuilderOptions<T, DateOnly> Date<T>(this IRuleBuilder<T, DateOnly> ruleBuilder, string propertyName)
    {
        return ruleBuilder
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(T), propertyName))
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today)).WithMessage(string.Format(ErrorMessages.BadDate, nameof(T), propertyName));
    }
    
    /// <summary>
    /// Проверка на валидность номера телефона
    /// </summary>
    /// <param name="ruleBuilder"> свойство, хранящее объект и тип данных для проверки</param>
    /// <typeparam name="T"> объект, который будет валидироваться</typeparam>
    /// <returns>Возвращает отвалидированный объект</returns>
    public static IRuleBuilderOptions<T, string> Phone<T>(this IRuleBuilder<T, string> ruleBuilder, string propertyName)
    {
        return ruleBuilder
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(T), propertyName))
            .Matches(RegexPatterns.PmrPhonePattern).WithMessage(string.Format(ErrorMessages.BadPhone, nameof(T), propertyName));
    }
    
    /// <summary>
    /// Проверка на валидность опыта работы
    /// </summary>
    /// <param name="ruleBuilder"> свойство, хранящее объект и тип данных для проверки</param>
    /// <typeparam name="T"> объект, который будет валидироваться</typeparam>
    /// <returns>Возвращает отвалидированный объект</returns>
    public static IRuleBuilderOptions<T, int> WorkExperience<T>(this IRuleBuilder<T, int> ruleBuilder, string propertyName)
    {
        return ruleBuilder
            .NotNull().WithMessage(string.Format(ErrorMessages.Required, nameof(T), propertyName))
            .GreaterThanOrEqualTo(0).WithMessage(string.Format(ErrorMessages.MinLength, nameof(T), propertyName));
    }
    
    /// <summary>
    /// Проверка на валидность почтового ящика
    /// </summary>
    /// <param name="ruleBuilder"> свойство, хранящее объект и тип данных для проверки</param>
    /// <typeparam name="T"> объект, который будет валидироваться</typeparam>
    /// <returns>Возвращает отвалидированный объект</returns>
    public static IRuleBuilderOptions<T, string> Email<T>(this IRuleBuilder<T, string> ruleBuilder, string propertyName)
    {
        return ruleBuilder
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(T), propertyName))
            .MaximumLength(255).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(T), propertyName))
            .Matches(RegexPatterns.EmailPattern).WithMessage(string.Format(ErrorMessages.BadEmail, nameof(T), propertyName));
    }
    
    /// <summary>
    /// Проверка на валидность пола
    /// </summary>
    /// <param name="ruleBuilder"> свойство, хранящее объект и тип данных для проверки</param>
    /// <typeparam name="T"> объект, который будет валидироваться</typeparam>
    /// <returns>Возвращает отвалидированный объект</returns>
    public static IRuleBuilderOptions<T, Gender> Gender<T>(this IRuleBuilder<T, Gender> ruleBuilder, string propertyName)
    {
        return ruleBuilder
            .NotEqual(default(Gender)).WithMessage(string.Format(ErrorMessages.NotDefault, nameof(T), propertyName))
            .IsInEnum();
    }
    
    /// <summary>
    /// Проверка на валидность названия ФИО
    /// </summary>
    /// <param name="ruleBuilder"> свойство, хранящее объект и тип данных для проверки</param>
    /// <typeparam name="T"> объект, который будет валидироваться</typeparam>
    /// <returns>Возвращает отвалидированный объект</returns>
    public static IRuleBuilderOptions<T, string> Name<T>(this IRuleBuilder<T, string> ruleBuilder, string propertyName)
    {
        return ruleBuilder
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(T), propertyName))
            .MaximumLength(50).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(T), propertyName))
            .Matches(RegexPatterns.NamePattern).WithMessage(string.Format(ErrorMessages.BadName, nameof(T), propertyName));
    }
    
    /// <summary>
    /// Проверка на валидность аспекта адресса: улица, город
    /// </summary>
    /// <param name="ruleBuilder"> свойство, хранящее объект и тип данных для проверки</param>
    /// <typeparam name="T"> объект, который будет валидироваться</typeparam>
    /// <returns>Возвращает отвалидированный объект</returns>
    public static IRuleBuilderOptions<T, string> Address<T>(this IRuleBuilder<T, string> ruleBuilder, string propertyName)
    {
        return ruleBuilder
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(T), propertyName))
            .MaximumLength(100).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(T), propertyName));
    }
    
    /// <summary>
    /// Проверка на валидность номера дома
    /// </summary>
    /// <param name="ruleBuilder"> свойство, хранящее объект и тип данных для проверки</param>
    /// <typeparam name="T"> объект, который будет валидироваться</typeparam>
    /// <returns>Возвращает отвалидированный объект</returns>
    public static IRuleBuilderOptions<T, int> NumberHouse<T>(this IRuleBuilder<T, int> ruleBuilder, string propertyName)
    {
        return ruleBuilder
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(T), propertyName))
            .GreaterThanOrEqualTo(0).WithMessage(string.Format(ErrorMessages.MinLength, nameof(T), propertyName));
    }
    
    /// <summary>
    /// Проверка на валидность ссылки на картинку
    /// </summary>
    /// <param name="ruleBuilder"> свойство, хранящее объект и тип данных для проверки</param>
    /// <typeparam name="T"> объект, который будет валидироваться</typeparam>
    /// <returns>Возвращает отвалидированный объект</returns>
    public static IRuleBuilderOptions<T, string> Avatar<T>(this IRuleBuilder<T, string> ruleBuilder, string propertyName)
    {
        return ruleBuilder
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(T), propertyName))
            .Matches(RegexPatterns.FilePngJpgPattern).WithMessage(string.Format(ErrorMessages.BadFile, nameof(T), propertyName));
    }
}