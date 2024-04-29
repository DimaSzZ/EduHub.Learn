using Ardalis.GuardClauses;
using EduHub.StudentService.Domain.Entities.Enums;
using EduHub.StudentService.Domain.ValueObjects;

namespace EduHub.StudentService.Domain.Entities;

/// <summary>
/// Студент, я хуй знает че написать
/// </summary>
public class Student
{
    #region Constructor
    public Student(Guid id, string avatar,FullName fullName, Gender gender, DateOnly dateBirth, Email email, Phone phone, Address address)
    {
        SetId(id);
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
    
    public Guid IdDb { get; private set; }

    public string NameDb { get; private set; }
    
    public string SurnameDb { get; private set; }
    
    public string PatronymicDb { get; private set; }
    
    public string PhoneNumberDb { get; private set; }
    
    public Gender GenderDb { get; private set; }
    
    public DateOnly DateBirthDb { get; private set; }
    
    public string EmailDb { get; private set; }
    
    public string CityDb { get; private set; }
    
    public string StreetDb { get; private set; }
    
    public int NumberHouseDb { get; private set; }
    
    public string AvatarDb { get; private set; }
    
    public IEnumerable<Enrollment> EnrollmentDb { get; private set; }

    #endregion

    #region Methods

    private void SetId(Guid idStudent)
    {
        IdDb = Guard.Against.Null(idStudent,nameof(idStudent));
    }

    private void SetAvatar(string avatarUrl)
    {
        Guard.Against.NullOrEmpty(avatarUrl, nameof(avatarUrl));
        
        bool isImageExtensionValid = avatarUrl.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                                     avatarUrl.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase);

        AvatarDb = isImageExtensionValid ? avatarUrl : throw new Exception("The avatar has the wrong data type");
    }

    private void SetFullName(FullName fullName)
    {
         (NameDb, SurnameDb, PatronymicDb) = fullName.ValidateFullName();
    }

    private void SetGender(Gender gender)
    {
        Guard.Against.Null(gender, nameof(gender));
        
        if (!Enum.IsDefined(typeof(Gender), gender))
        {
            throw new ArgumentOutOfRangeException(nameof(gender), gender, "Invalid gender value. Only 'Man' (1) or 'Woman' (2) are allowed.");
        }

        GenderDb = gender;
    }

    private void SetDateBirdth(DateOnly dateOfBirth)
    {
        Guard.Against.Null(dateOfBirth, nameof(dateOfBirth));

        if (dateOfBirth > DateOnly.FromDateTime(DateTime.Now))
        {
            throw new ArgumentOutOfRangeException(nameof(dateOfBirth), dateOfBirth, "Date of birth cannot be in the future.");
        }
        
        DateBirthDb = dateOfBirth;
    }

    private void SetEmail(Email email)
    {
        Guard.Against.Null(email, nameof(email));
        EmailDb = email.ValidateEmail(email);
    }

    private void SetAddress(Address address)
    {
        Guard.Against.Null(address,nameof(address));
        (CityDb, StreetDb, NumberHouseDb) = address.ValidateAddress(address);
    }

    private void SetPhoneNumber(Phone phone)
    {
        Guard.Against.Null(phone, nameof(phone));
        PhoneNumberDb = phone.ValidateFullName(phone);
    }
    #endregion
    
    
}