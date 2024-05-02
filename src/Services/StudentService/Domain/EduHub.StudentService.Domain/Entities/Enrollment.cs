using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Domain.Entities;

/// <summary>
/// Модель отвечающие за состояние зачисление студента
/// </summary>
public class Enrollment : BaseEntity
{
    #region Constructor
    
    /// <summary>
    /// конструктор с неочищенными данными
    /// </summary>
    /// <param name="id"></param>
    /// <param name="enrollmentDate"></param>
    public Enrollment(Guid id, DateOnly enrollmentDate)
    {
        SetId(id);
        SetEnrollmentDate(enrollmentDate);
    }
    
    #endregion
    
    #region Properties
    
    /// <summary>
    /// Id курса
    /// </summary>
    public DateOnly EnrollmentDate { get; private set; }
    
    #endregion
    
    #region Methods
    
    private void SetEnrollmentDate(DateOnly enrollmentDate)
    {
        EnrollmentDate = enrollmentDate;
    }
    
    #endregion
}