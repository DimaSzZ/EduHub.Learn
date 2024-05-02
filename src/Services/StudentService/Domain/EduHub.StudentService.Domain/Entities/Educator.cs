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
    /// <param name="dateEmployment"></param>
    public Educator(Guid id, FullName fullName, Gender gender, Phone phone, int workExperience, DateOnly dateEmployment)
    {
        SetId(id);
        SetFullName(fullName);
        SetGender(gender);
        SetPhoneNumber(phone);
        SetWorkExperience(workExperience);
        SetDateEmployment(dateEmployment);
    }
    
    #endregion
    
    #region Properties
    
    /// <summary>
    /// ФИО преподователя
    /// </summary>
    public FullName FullName { get; private set; }
    
    /// <summary>
    /// Пол преподователя (так как в СНГ, то пока что только 2 пола ^-^)
    /// </summary>
    
    public Gender Gender { get; private set; }
    
    /// <summary>
    /// Номер телефона преподавателя
    /// </summary>
    
    public Phone PhoneNumber { get; private set; }
    
    /// <summary>
    /// Стаж преподователя в годах
    /// </summary>
    
    public int YearsExperience { get; private set; }
    
    /// <summary>
    /// Дата устройства на работу
    /// </summary>
    
    public DateOnly DateEmployment { get; private set; }
    
    /// <summary>
    /// Курсы, где  ведет преподаватель
    /// </summary>
    
    public List<Course> Courses { get; private set; }
    
    #endregion
    
    #region Methods
    
    private void SetFullName(FullName fullName)
    {
        FullName = fullName.ValidateFullName();
    }
    
    private void SetGender(Gender gender)
    {
        Gender = Guard.Against.Null(gender, nameof(gender));
    }
    
    private void SetPhoneNumber(Phone phone)
    {
        PhoneNumber = phone.ValidatePhone();
    }
    
    private void SetWorkExperience(int yearsExperience)
    {
        YearsExperience = Guard.Against.Null(yearsExperience, nameof(yearsExperience));
    }
    
    private void SetDateEmployment(DateOnly dateEmployment)
    {
        DateEmployment = dateEmployment;
    }
    
    #endregion
}