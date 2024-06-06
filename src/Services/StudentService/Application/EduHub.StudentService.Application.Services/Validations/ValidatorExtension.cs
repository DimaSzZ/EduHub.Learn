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
    /// <typeparam name="TEntity"> объект, который будет валидироваться</typeparam>
    /// <returns>Возвращает отвалидированный объект</returns>
    public static IRuleBuilderOptions<TEntity, string> PersonName<TEntity>(this IRuleBuilder<TEntity, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(TEntity)))
            .MinimumLength(2).WithMessage(string.Format(ErrorMessages.MinLength, nameof(TEntity)))
            .MaximumLength(60).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(TEntity)))
            .Matches(RegexPatterns.NamePattern).WithMessage(string.Format(ErrorMessages.BadName, nameof(TEntity)));
    }
    
    /// <summary>
    /// Проверка на валидность Id
    /// </summary>
    /// <param name="ruleBuilder"> свойство, хранящее объект и тип данных для проверки</param>
    /// <typeparam name="TEntity"> объект, который будет валидироваться</typeparam>
    /// <returns>Возвращает отвалидированный объект</returns>
    public static IRuleBuilderOptions<TEntity, Guid> Id<TEntity>(this IRuleBuilder<TEntity, Guid> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(TEntity)));
    }
    
    /// <summary>
    /// Проверка на валидность даты
    /// </summary>
    /// <param name="ruleBuilder"> свойство, хранящее объект и тип данных для проверки</param>
    /// <typeparam name="TEntity"> объект, который будет валидироваться</typeparam>
    /// <returns>Возвращает отвалидированный объект</returns>
    public static IRuleBuilderOptions<TEntity, DateOnly> Date<TEntity>(this IRuleBuilder<TEntity, DateOnly> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(TEntity)))
            .Must(date => date <= DateOnly.FromDateTime(DateTime.Today)).WithMessage(ErrorMessages.BadDate);
    }
    
    /// <summary>
    /// Проверка на валидность номера телефона
    /// </summary>
    /// <param name="ruleBuilder"> свойство, хранящее объект и тип данных для проверки</param>
    /// <typeparam name="TEntity"> объект, который будет валидироваться</typeparam>
    /// <returns>Возвращает отвалидированный объект</returns>
    public static IRuleBuilderOptions<TEntity, string> Phone<TEntity>(this IRuleBuilder<TEntity, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(TEntity)))
            .Matches(RegexPatterns.PmrPhonePattern).WithMessage(ErrorMessages.BadPhone);
    }
    
    /// <summary>
    /// Проверка на валидность опыта работы
    /// </summary>
    /// <param name="ruleBuilder"> свойство, хранящее объект и тип данных для проверки</param>
    /// <typeparam name="TEntity"> объект, который будет валидироваться</typeparam>
    /// <returns>Возвращает отвалидированный объект</returns>
    public static IRuleBuilderOptions<TEntity, int> WorkExperience<TEntity>(this IRuleBuilder<TEntity, int> ruleBuilder)
    {
        return ruleBuilder
            .NotNull().WithMessage(string.Format(ErrorMessages.Required, nameof(TEntity)))
            .GreaterThanOrEqualTo(0).WithMessage(string.Format(ErrorMessages.MinLength, nameof(TEntity)));
    }
    
    /// <summary>
    /// Проверка на валидность почтового ящика
    /// </summary>
    /// <param name="ruleBuilder"> свойство, хранящее объект и тип данных для проверки</param>
    /// <typeparam name="TEntity"> объект, который будет валидироваться</typeparam>
    /// <returns>Возвращает отвалидированный объект</returns>
    public static IRuleBuilderOptions<TEntity, string> Email<TEntity>(this IRuleBuilder<TEntity, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(TEntity)))
            .MaximumLength(255).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(TEntity)))
            .Matches(RegexPatterns.EmailPattern).WithMessage(ErrorMessages.BadEmail);
    }
    
    /// <summary>
    /// Проверка на валидность пола
    /// </summary>
    /// <param name="ruleBuilder"> свойство, хранящее объект и тип данных для проверки</param>
    /// <typeparam name="TEntity"> объект, который будет валидироваться</typeparam>
    /// <returns>Возвращает отвалидированный объект</returns>
    public static IRuleBuilderOptions<TEntity, Gender> Gender<TEntity>(this IRuleBuilder<TEntity, Gender> ruleBuilder)
    {
        return ruleBuilder
            .NotEqual(default(Gender)).WithMessage(string.Format(ErrorMessages.NotDefault, nameof(TEntity)))
            .IsInEnum();
    }
    
    /// <summary>
    /// Проверка на валидность названия
    /// </summary>
    /// <param name="ruleBuilder"> свойство, хранящее объект и тип данных для проверки</param>
    /// <typeparam name="TEntity"> объект, который будет валидироваться</typeparam>
    /// <returns>Возвращает отвалидированный объект</returns>
    public static IRuleBuilderOptions<TEntity, string> Name<TEntity>(this IRuleBuilder<TEntity, string> ruleBuilder)
    {
        return ruleBuilder
            .Matches(RegexPatterns.NamePattern).WithMessage(string.Format(ErrorMessages.BadName, nameof(TEntity)))
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(TEntity)))
            .MaximumLength(50);
    }
    
    /// <summary>
    /// Проверка на валидность аспекта адресса: улица, город
    /// </summary>
    /// <param name="ruleBuilder"> свойство, хранящее объект и тип данных для проверки</param>
    /// <typeparam name="TEntity"> объект, который будет валидироваться</typeparam>
    /// <returns>Возвращает отвалидированный объект</returns>
    public static IRuleBuilderOptions<TEntity, string> Address<TEntity>(this IRuleBuilder<TEntity, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(TEntity)))
            .MaximumLength(100).WithMessage(string.Format(ErrorMessages.MaxLength, nameof(TEntity)));
    }
    
    /// <summary>
    /// Проверка на валидность номера дома
    /// </summary>
    /// <param name="ruleBuilder"> свойство, хранящее объект и тип данных для проверки</param>
    /// <typeparam name="TEntity"> объект, который будет валидироваться</typeparam>
    /// <returns>Возвращает отвалидированный объект</returns>
    public static IRuleBuilderOptions<TEntity, int> NumberHouse<TEntity>(this IRuleBuilder<TEntity, int> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(TEntity)))
            .GreaterThanOrEqualTo(0).WithMessage(string.Format(ErrorMessages.MinLength, nameof(TEntity)));
    }
    
    /// <summary>
    /// Проверка на валидность ссылки на картинку
    /// </summary>
    /// <param name="ruleBuilder"> свойство, хранящее объект и тип данных для проверки</param>
    /// <typeparam name="TEntity"> объект, который будет валидироваться</typeparam>
    /// <returns>Возвращает отвалидированный объект</returns>
    public static IRuleBuilderOptions<TEntity, string> Avatar<TEntity>(this IRuleBuilder<TEntity, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage(string.Format(ErrorMessages.Required, nameof(TEntity)))
            .Matches(RegexPatterns.FilePngJpgPattern).WithMessage(ErrorMessages.BadFile);
    }
}