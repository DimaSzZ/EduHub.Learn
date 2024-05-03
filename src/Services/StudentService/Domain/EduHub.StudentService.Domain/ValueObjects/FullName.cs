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
        Guard.Against.NullOrEmpty(firstName);
        Guard.Against.NullOrEmpty(surname);
        Guard.Against.NullOrEmpty(patronymic);
        
        FirstName = firstName;
        Surname = surname;
        Patronymic = patronymic;
    }
    
    /// <summary>
    /// Имя 
    /// </summary>
    public string FirstName { get; }
    
    /// <summary>
    /// Фамилия человека
    /// </summary>
    public string Surname { get; }
    
    /// <summary>
    /// Отчество человека
    /// </summary>
    public string Patronymic { get; }
}