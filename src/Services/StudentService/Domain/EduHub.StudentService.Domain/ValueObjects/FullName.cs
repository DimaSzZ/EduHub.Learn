using Ardalis.GuardClauses;
using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Domain.ValueObjects;

/// <summary>
/// Сущность, которая используется для установки ФИО в моделях и для системного валидирования
/// </summary>
public class FullName : BaseValueObject
{
    /// <summary>
    /// Конструктор с неочищенными данными
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="surname"></param>
    /// <param name="patronymic"></param>
    public FullName(string firstName, string surname, string patronymic)
    {
        FirstName = firstName;
        Surname = surname;
        Patronymic = patronymic;
    }

    /// <summary>
    /// Валидируем ФИО
    /// </summary>
    /// <returns></returns>
    public (string,string,string) ValidateFullName()
    {
        Guard.Against.NullOrEmpty(FirstName, nameof(FirstName));
        Guard.Against.NullOrEmpty(Surname, nameof(Surname));
        Guard.Against.NullOrEmpty(Patronymic, nameof(Patronymic));

        return  (FirstName, Surname, Patronymic);
    }
    
    /// <summary>
    /// Имя человека
    /// </summary>
    public string FirstName { get; }
    
    /// <summary>
    /// Фамилия человека
    /// </summary>
    public string Surname { get;}
    
    /// <summary>
    /// Отчество человека
    /// </summary>
    public string Patronymic { get; }
}