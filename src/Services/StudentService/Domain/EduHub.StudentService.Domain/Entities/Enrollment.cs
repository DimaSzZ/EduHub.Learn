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
    /// конструктор с неочищенными данными
    /// </summary>
    /// <param name="id"></param>
    /// <param name="idStudent"></param>
    /// <param name="idCourse"></param>
    /// <param name="enrollmentDate"></param>
    public Enrollment(Guid id, Guid idStudent, Guid idCourse, DateOnly enrollmentDate)
    {
        SetIdDb(id);
        SetIdStudent(idStudent);
        SetIdCourse(idCourse);
        SetEnrollmentDate(enrollmentDate);
    }

    #endregion
    
    #region Properties
    
    /// <summary>
    /// Id студента
    /// </summary>
    public Guid IdStudent { get; private set; }
    
    /// <summary>
    /// Абстракция для доступа к студенту
    /// </summary>
    
    public Student Student { get; private set; }
    
    /// <summary>
    /// Id курса
    /// </summary>
    public Guid IdCourse { get; private set; }
    
    /// <summary>
    /// Абстракция для доступа к курсу
    /// </summary>
    
    public Course Course { get; private set; }
    
    /// <summary>
    /// Дата зачисления 
    /// </summary>
    public DateOnly EnrollmentDate { get; private set; }

    #endregion

    #region Methods
    private void SetIdStudent(Guid idStudent)
    {
        IdStudent = Guard.Against.NullOrEmpty(idStudent,nameof(idStudent));
    }
    private void SetIdCourse(Guid idCourse)
    {
        IdCourse = Guard.Against.NullOrEmpty(idCourse,nameof(idCourse));
    }

    private void SetEnrollmentDate(DateOnly enrollmentDate)
    {
        EnrollmentDate = Guard.Against.Null(enrollmentDate,nameof(enrollmentDate));
    }

    #endregion
    
}