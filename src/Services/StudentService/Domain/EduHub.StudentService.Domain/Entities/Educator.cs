using Ardalis.GuardClauses;
using EduHub.StudentService.Domain.Entities.Core;
using EduHub.StudentService.Domain.Entities.Enums;
using EduHub.StudentService.Domain.ValueObjects;

namespace EduHub.StudentService.Domain.Entities;

/// <summary>
/// Преподаватель для студентика
/// </summary>

public class Educator : BaseEntity
{
    #region Constructor
    
    /// <summary>
    /// Конструктор с непроваледированными данными
    /// </summary>
    /// <param name="id"></param>
    /// <param name="fullName"></param>
    /// <param name="gender"></param>
    /// <param name="phone"></param>
    /// <param name="workExperience"></param>
    /// <param name="dateOfEmployment"></param>
    public Educator(Guid id,FullName fullName,Gender gender, Phone phone,int workExperience,DateOnly dateOfEmployment)
    {
        SetIdDb(id);
        SetFullName(fullName);
        SetGender(gender);
        SetPhoneNumber(phone);
        SetWorkExperience(workExperience);
        SetDateOfEmployment(dateOfEmployment);
    }
    
    #endregion
    
    #region Properties
    
    /// <summary>
    /// Имя преподователя
    /// </summary>
    public string Name { get; private set; }
    
    /// <summary>
    /// Фамилия преподователя
    /// </summary>
    
    public string Surname { get; private set; }
    
    /// <summary>
    /// Отчество перподователя
    /// </summary>
    
    public string Patronymic { get; private set; }
    
    /// <summary>
    /// Пол преподователя (так как в СНГ, то пока что только 2 пола ^-^)
    /// </summary>
    
    public Gender Gender { get; private set; }
    
    /// <summary>
    /// Номер телефона преподавателя
    /// </summary>
    
    public string PhoneNumber { get; private set; }
    
    /// <summary>
    /// Стаж преподователя в годах
    /// </summary>
    
    public int YearsOfExperience { get; private set; }
    
    /// <summary>
    /// Дата устройства на работу
    /// </summary>
    
    public DateOnly DateOfEmployment { get; private set; }
    
    /// <summary>
    /// Курсы, где  ведет преподаватель
    /// </summary>
    
    public IEnumerable<Course> Courses { get; private set; }

    #endregion

    #region Methods
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
    
    private void SetPhoneNumber(Phone phone)
    {
        Guard.Against.Null(phone,nameof(phone));
        PhoneNumber = phone.ValidateFullName(phone);
    }

    private void SetWorkExperience(int yearsOfExperience)
    {
        Guard.Against.Null(yearsOfExperience,nameof(yearsOfExperience));
        YearsOfExperience = Guard.Against.OutOfRange(yearsOfExperience, nameof(yearsOfExperience), 0, 90, 
            $"Work experience '{yearsOfExperience}' should be a non-negative integer.");
    }

    private void SetDateOfEmployment(DateOnly dateOfEmployment)
    {
        DateOfEmployment = Guard.Against.Null(dateOfEmployment,nameof(dateOfEmployment));
    }
    #endregion
}