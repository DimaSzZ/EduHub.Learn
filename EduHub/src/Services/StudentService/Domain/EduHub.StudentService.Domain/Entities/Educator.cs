using Ardalis.GuardClauses;
using EduHub.StudentService.Domain.Entities.Enums;
using EduHub.StudentService.Domain.ValueObjects;

namespace EduHub.StudentService.Domain.Entities;

/// <summary>
/// Преподаватель для студентика
/// </summary>

public class Educator
{
    #region Constructor
    
    public Educator(Guid id,FullName fullName,Gender gender, Phone phone,int workExperience,DateOnly dateOfEmployment)
    {
        SetId(id);
        SetFullName(fullName);
        SetGender(gender);
        SetPhoneNumber(phone);
        SetWorkExperience(workExperience);
        SetDateOfEmployment(dateOfEmployment);
    }
    
    #endregion

    #region Methods

    private void SetId(Guid idEducator)
    {
        IdDb = Guard.Against.Null(idEducator,nameof(idEducator));
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
    
    private void SetPhoneNumber(Phone phone)
    {
        Guard.Against.Null(phone,nameof(phone));
        PhoneNumberDb = phone.ValidateFullName(phone);
    }

    private void SetWorkExperience(int yearsOfExperience)
    {
        Guard.Against.Null(yearsOfExperience,nameof(yearsOfExperience));
        YearsOfExperienceDb = Guard.Against.OutOfRange(yearsOfExperience, nameof(yearsOfExperience), 0, 90, 
            $"Work experience '{yearsOfExperience}' should be a non-negative integer.");
    }

    private void SetDateOfEmployment(DateOnly dateOfEmployment)
    {
        DateOfEmploymentDb = Guard.Against.Null(dateOfEmployment,nameof(dateOfEmployment));
    }
    #endregion
    
    #region Fields

    public Guid IdDb { get; private set; }
    
    public string NameDb { get; private set; }
    
    public string SurnameDb { get; private set; }
    
    public string PatronymicDb { get; private set; }
    
    public Gender GenderDb { get; private set; }
    
    public string PhoneNumberDb { get; private set; }
    
    public int YearsOfExperienceDb { get; private set; }
    
    public DateOnly DateOfEmploymentDb { get; private set; }
    
    public IEnumerable<Course> CoursesDb { get; private set; }

    #endregion
}