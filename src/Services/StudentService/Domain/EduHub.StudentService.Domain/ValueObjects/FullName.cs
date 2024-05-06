using Ardalis.GuardClauses;
using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Domain.ValueObjects;

/// <summary>
/// Сущность, которая используется для установки ФИО в моделях и для системного валидирования
/// </summary>
public class FullName : BaseValueObject
{
    /// <summary>
    /// Конструктор который принимает ФИО
    /// </summary>
    /// <param name="firstName">Имя</param>
    /// <param name="surname">Фамилия</param>
    /// <param name="patronymic">Отчество</param>
    public FullName(string firstName, string surname, string patronymic)
    {
        FirstName = Guard.Against.NullOrEmpty(firstName);
        Surname = Guard.Against.NullOrEmpty(surname);
        Patronymic = Guard.Against.NullOrEmpty(patronymic);
    }
    
    /// <summary>
    /// Имя 
    /// </summary>
    public string FirstName { get; }
    
    /// <summary>
    /// Фамилия
    /// </summary>
    public string Surname { get; }
    
    /// <summary>
    /// Отчество
    /// </summary>
    public string Patronymic { get; }
}