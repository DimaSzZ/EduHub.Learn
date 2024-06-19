using Ardalis.GuardClauses;
using EduHub.StudentService.Domain.Entities.Core;
using EduHub.StudentService.Domain.Entities.Enums;
using EduHub.StudentService.Domain.ValueObjects;

namespace EduHub.StudentService.Domain.Entities;

/// <summary>
/// Описание модели студента
/// </summary>
public class Student : BaseHumanEntity
{
    #region Constructor
    
    /// <summary>
    /// Неочищенные данные, которые будут провалидированным методами  
    /// </summary>
    /// <param name="id">Id студента</param>
    /// <param name="avatar">url аватара</param>
    /// <param name="fullName">ФИО студента</param>
    /// <param name="gender">Пол студента</param>
    /// <param name="dateBirth">Дата рождения</param>
    /// <param name="email">Почта студента</param>
    /// <param name="phone">Номер телефона студента</param>
    /// <param name="address">Адресс студента</param>
    /// 
    public Student(Guid id, string avatar, FullName fullName, Gender gender,
        DateOnly dateBirth, Email email, Phone phone, Address address)
    {
        SetId(id);
        SetAvatar(avatar);
        SetFullName(fullName);
        SetGender(gender);
        SetDateBirth(dateBirth);
        SetEmail(email);
        SetAddress(address);
        SetPhoneNumber(phone);
    }
    
    private Student()
    {
    }
    
    #endregion
    
    #region Properties
    
    /// <summary>
    /// Дата рождения студента
    /// </summary>
    public DateOnly DateBirth { get; private set; }
    
    /// <summary>
    /// E-mail студента
    /// </summary>
    public Email Email { get; private set; }
    
    /// <summary>
    /// Адресс проживания студента
    /// </summary>
    public Address Address { get; private set; }
    
    /// <summary>
    /// Ссылка на аватарку студента (скорее всего в S3)
    /// </summary>
    public string Avatar { get; private set; }
    
    /// <summary>
    /// Список зачислений студента
    /// </summary>
    public List<Enrollment> Enrollments { get; private set; } = new();
    
    #endregion
    
    #region Methods
    
    /// <summary/>
    /// Метод, служащий для обновления студента
    /// <param name="avatar">url аватара</param>
    /// <param name="fullName">ФИО студента</param>
    /// <param name="gender">Пол студента</param>
    /// <param name="dateBirth">Дата рождения</param>
    /// <param name="email">Почта студента</param>
    /// <param name="phone">Номер телефона студента</param>
    /// <param name="address">Адресс студента</param>
    public void Update(string avatar, FullName fullName, Gender gender,
        DateOnly dateBirth, Email email, Phone phone, Address address)
    {
        SetAvatar(avatar);
        SetFullName(fullName);
        SetGender(gender);
        SetDateBirth(dateBirth);
        SetEmail(email);
        SetAddress(address);
        SetPhoneNumber(phone);
    }
    
    private void SetAvatar(string avatarUrl)
    {
        Avatar = Guard.Against.NullOrEmpty(avatarUrl);
    }
    
    private void SetDateBirth(DateOnly dateOfBirth)
    {
        DateBirth = Guard.Against.Default(dateOfBirth);
    }
    
    private void SetEmail(Email email)
    {
        Email = Guard.Against.Null(email);
    }
    
    private void SetAddress(Address address)
    {
        Address = Guard.Against.Null(address);
    }
    
    #endregion
}