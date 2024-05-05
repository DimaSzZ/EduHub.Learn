using Ardalis.GuardClauses;
using EduHub.StudentService.Domain.Entities.Enums;
using EduHub.StudentService.Domain.ValueObjects;

namespace EduHub.StudentService.Domain.Entities.Core;

public abstract class BaseHumanEntity : BaseEntity
{
    /// <summary>
    /// ФИО преподователя
    /// </summary>
    public FullName FullName { get; protected set; }
    
    /// <summary>
    /// Пол преподавателя
    /// </summary>
    public Gender Gender { get; protected set; }
    
    /// <summary>
    /// Номер телефона преподавателя
    /// </summary>
    public Phone Phone { get; protected set; }
    
    protected void SetFullName(FullName fullName)
    {
        FullName = Guard.Against.Null(fullName);
    }
    
    protected void SetGender(Gender gender)
    {
        Gender = Guard.Against.Default(gender);
    }
    
    protected void SetPhoneNumber(Phone phone)
    {
        Phone = Guard.Against.Null(phone);
    }
}
