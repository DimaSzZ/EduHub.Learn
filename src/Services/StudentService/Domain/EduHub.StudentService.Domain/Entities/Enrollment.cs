using Ardalis.GuardClauses;
using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Domain.Entities;

/// <summary>
/// Модель отвечающие за состояние зачисление студента
/// </summary>
public class Enrollment : BaseEntity
{
    #region Constructor
    
    /// <summary>
    /// Конструктор для зачисления
    /// </summary>
    /// <param name="id">Id зачисления</param>
    /// <param name="enrollmentDate">Дата зачисления</param>
    /// <param name="studentId">Id студента</param>
    /// <param name="courseId">Id курса</param>
    public Enrollment(Guid id, DateOnly enrollmentDate, Guid studentId, Guid courseId)
    {
        SetId(id);
        SetStudentId(studentId);
        SetCourseId(courseId);
        SetEnrollmentDate(enrollmentDate);
    }
    
    private Enrollment()
    {
    }
    
    #endregion
    
    #region Properties
    
    /// <summary>
    /// Дата зачисления
    /// </summary>
    public DateOnly EnrollmentDate { get; private set; }
    
    /// <summary>
    /// Id студента
    /// </summary>
    public Guid StudentId { get; private set; }
    
    /// <summary>
    /// Id курса
    /// </summary>
    
    public Guid CourseId { get; private set; }
    
    #endregion
    
    #region Methods
    
    private void SetStudentId(Guid studentId)
    {
        StudentId = Guard.Against.NullOrEmpty(studentId);
    }
    
    private void SetCourseId(Guid courseId)
    {
        CourseId = Guard.Against.NullOrEmpty(courseId);
    }
    
    private void SetEnrollmentDate(DateOnly enrollmentDate)
    {
        EnrollmentDate = Guard.Against.Default(enrollmentDate);
    }
    
    #endregion
}