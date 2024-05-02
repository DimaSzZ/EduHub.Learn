using Ardalis.GuardClauses;
using EduHub.StudentService.Domain.Entities.Core;
using EduHub.StudentService.Domain.Entities.Enums;
using EduHub.StudentService.Domain.ValueObjects;

namespace EduHub.StudentService.Domain.Entities;

/// <summary>
/// Описание модели студента
/// </summary>
public class Student : BaseEntity
{
    #region Constructor
    
    /// <summary>
    /// Неочищенные данные, которые будут провалидированным методами  
    /// </summary>
    /// <param name="id"></param>
    /// <param name="avatar"></param>
    /// <param name="fullName"></param>
    /// <param name="gender"></param>
    /// <param name="dateBirth"></param>
    /// <param name="email"></param>
    /// <param name="phone"></param>
    /// <param name="address"></param>
    /// 
    public Student(Guid id, string avatar, FullName fullName, Gender gender, DateOnly dateBirth, Email email, Phone phone, Address address)
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
    
    #endregion
    
    #region Properties
    
    /// <summary>
    /// ФИО студента
    /// </summary>
    public FullName FullName { get; private set; }
    
    /// <summary>
    /// Номер телефона студента
    /// </summary>
    
    public Phone PhoneNumber { get; private set; }
    
    /// <summary>
    /// Пол студента
    /// </summary>
    public Gender Gender { get; private set; }
    
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
    
    public IEnumerable<Enrollment> Enrollment { get; private set; }
    
    #endregion
    
    #region Methods
    
    private void SetAvatar(string avatarUrl)
    {
        Avatar = Guard.Against.NullOrEmpty(avatarUrl, nameof(avatarUrl));
    }
    
    private void SetFullName(FullName fullName)
    {
        FullName = fullName.ValidateFullName();
    }
    
    private void SetGender(Gender gender)
    {
        Gender = Guard.Against.Null(gender, nameof(gender));
    }
    
    private void SetDateBirth(DateOnly dateOfBirth)
    {
        DateBirth = dateOfBirth;
    }
    
    
    private void SetEmail(Email email)
    {
        Email = email.ValidateEmail();
    }
    
    private void SetAddress(Address address)
    {
        Address = address.ValidateAddress();
    }
    
    private void SetPhoneNumber(Phone phone)
    {
        PhoneNumber = phone.ValidatePhone();
    }
    
    #endregion
}