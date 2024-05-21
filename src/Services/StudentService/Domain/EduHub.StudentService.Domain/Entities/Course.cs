using Ardalis.GuardClauses;
using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Domain.Entities;

/// <summary>
/// Модель курса
/// </summary>
public class Course : BaseEntity
{
    #region Constructor
    
    /// <summary>
    /// Конструктор, для курса
    /// </summary>
    /// <param name="id">id курса</param>
    /// <param name="name">имя курса</param>
    /// <param name="description">описание курса</param>
    /// <param name="educatorId">id преподавателя</param>
    public Course(Guid id, string name, string description, Guid educatorId)
    {
        SetId(id);
        SetName(name);
        SetDescription(description);
        SetEducatorId(educatorId);
    }
    
    #endregion
    
    #region Properties
    
    /// <summary>
    /// Название курса
    /// </summary>
    public string Name { get; private set; }
    
    /// <summary>
    /// Описание курса
    /// </summary>
    public string Description { get; private set; }
    
    /// <summary>
    /// Id преподователя(который проводит курс)
    /// </summary>
    public Guid EducatorId { get; private set; }
    
    #endregion
    
    #region Methods
    
    /// <summary>
    /// Метод для обновления Course
    /// </summary>
    /// <param name="name">имя курса</param>
    /// <param name="description">описание курса</param>
    /// <param name="educatorId">id преподавателя</param>
    public void Update(string name, string description, Guid educatorId)
    {
        SetName(name);
        SetDescription(description);
        SetEducatorId(educatorId);
    }
    
    private void SetEducatorId(Guid educatorId)
    {
        EducatorId = Guard.Against.NullOrEmpty(educatorId);
    }
    
    private void SetDescription(string description)
    {
        Description = Guard.Against.Null(description);
    }
    
    private void SetName(string name)
    {
        Name = Guard.Against.NullOrEmpty(name);
    }
    
    #endregion
}