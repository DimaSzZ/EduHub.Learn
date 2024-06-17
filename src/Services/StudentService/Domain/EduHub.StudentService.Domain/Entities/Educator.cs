using Ardalis.GuardClauses;
using EduHub.StudentService.Domain.Entities.Core;
using EduHub.StudentService.Domain.Entities.Enums;
using EduHub.StudentService.Domain.ValueObjects;

namespace EduHub.StudentService.Domain.Entities;

/// <summary>
/// Преподаватель для студентика
/// </summary>
public class Educator : BaseHumanEntity
{
    #region Constructor
    
    /// <summary>
    /// Конструктор для создания преподавателя
    /// </summary>
    /// <param name="id">id преподавателя</param>
    /// <param name="fullName">ФИО преподавателя</param>
    /// <param name="gender">Пол преподавателя</param>
    /// <param name="phone">Номер преподавателя</param>
    /// <param name="workExperience">Стаж преподавателя</param>
    /// <param name="dateEmployment">Дата устройства на работу</param>
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
    
    public Educator()
    {
    }
    
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
    
    public List<Course> Courses { get; private set; } = new();
    
    #endregion
    
    #region Methods
    
    /// <summary>
    /// Обновляет преподователя
    /// </summary>
    /// <param name="fullName">ФИО преподавателя</param>
    /// <param name="gender">Пол преподавателя</param>
    /// <param name="phone">Номер преподавателя</param>
    /// <param name="workExperience">Стаж преподавателя</param>
    /// <param name="dateEmployment">Дата устройства на работу</param>
    public void Update(FullName fullName, Gender gender, Phone phone, int workExperience, DateOnly dateEmployment)
    {
        SetFullName(fullName);
        SetGender(gender);
        SetPhoneNumber(phone);
        SetWorkExperience(workExperience);
        SetDateEmployment(dateEmployment);
    }
    
    private void SetWorkExperience(int yearsExperience)
    {
        YearsExperience = Guard.Against.Null(yearsExperience);
    }
    
    private void SetDateEmployment(DateOnly dateEmployment)
    {
        DateEmployment = Guard.Against.Default(dateEmployment);
    }
    
    #endregion
}