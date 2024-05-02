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
    public Student(Guid id, string avatar,FullName fullName, Gender gender, DateOnly dateBirth, Email email, Phone phone, Address address)
    {
        SetIdDb(id);
        SetAvatar(avatar);
        SetFullName(fullName);
        SetGender(gender);
        SetDateBirdth(dateBirth);
        SetEmail(email);
        SetAddress(address);
        SetPhoneNumber(phone);
    }
    #endregion
    
    #region Properties
    
    /// <summary>
    /// Имя студента
    /// </summary>
    
    public string Name { get; private set; }
    
    /// <summary>
    /// Фамилия студента
    /// </summary>
    
    public string Surname { get; private set; }
    
    /// <summary>
    /// Отчество студента
    /// </summary>
    
    public string Patronymic { get; private set; }
    
    /// <summary>
    /// Номер телефона студента
    /// </summary>
    
    public string PhoneNumber { get; private set; }
    
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
    public string Email { get; private set; }
    
    /// <summary>
    /// Город студента
    /// </summary>
    public string City { get; private set; }
    
    /// <summary>
    /// Улица студента
    /// </summary>
    public string Street { get; private set; }
    
    /// <summary>
    /// Номерр дома
    /// </summary>
    public int NumberHouse { get; private set; }
    
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
        Guard.Against.NullOrEmpty(avatarUrl, nameof(avatarUrl));
        
        bool isImageExtensionValid = avatarUrl.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                                     avatarUrl.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase);

        Avatar = isImageExtensionValid ? avatarUrl : throw new Exception("The avatar has the wrong data type");
    }

    private void SetFullName(FullName fullName)
    {
         (Name, Surname, Patronymic) = fullName.ValidateFullName();
    }

    private void SetGender(Gender gender)
    {
        Guard.Against.Null(gender, nameof(gender));
        
        if (!Enum.IsDefined(typeof(Gender), gender))
        {
            throw new ArgumentOutOfRangeException(nameof(gender), gender, "Invalid gender value. Only 'Man' (1) or 'Woman' (2) are allowed.");
        }

        Gender = gender;
    }

    private void SetDateBirdth(DateOnly dateOfBirth)
    {
        Guard.Against.Null(dateOfBirth, nameof(dateOfBirth));

        if (dateOfBirth > DateOnly.FromDateTime(DateTime.Now))
        {
            throw new ArgumentOutOfRangeException(nameof(dateOfBirth), dateOfBirth, "Date of birth cannot be in the future.");
        }
        
        DateBirth = dateOfBirth;
    }

    private void SetEmail(Email email)
    {
        Guard.Against.Null(email, nameof(email));
        Email = email.ValidateEmail(email);
    }

    private void SetAddress(Address address)
    {
        Guard.Against.Null(address,nameof(address));
        (City, Street, NumberHouse) = address.ValidateAddress(address);
    }

    private void SetPhoneNumber(Phone phone)
    {
        Guard.Against.Null(phone, nameof(phone));
        PhoneNumber = phone.ValidateFullName(phone);
    }
    #endregion
    
    
}