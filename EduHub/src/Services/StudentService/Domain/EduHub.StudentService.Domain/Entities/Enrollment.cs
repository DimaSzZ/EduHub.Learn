using Ardalis.GuardClauses;
using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Domain.Entities;

/// <summary>
/// Модель отвечающие за состояние зачисление студента
/// </summary>

public class Enrollment : BaseEntity
{
    #region Constructor

    public Enrollment(Guid id, Guid idStudent, Guid idCourse, DateOnly enrollmentDate)
    {
        SetIdDb(id);
        SetIdStudent(idStudent);
        SetIdCourse(idCourse);
        SetEnrollmentDate(enrollmentDate);
    }

    #endregion
    
    #region Properties
    public Guid IdStudentDb { get; private set; }
    
    public Student StudentDb { get; private set; }
    
    public Guid IdCourseDb { get; private set; }
    
    public Course CourseDb { get; private set; }
    public DateOnly EnrollmentDateDb { get; private set; }

    #endregion

    #region Methods
    private void SetIdStudent(Guid idStudent)
    {
        IdStudentDb = Guard.Against.NullOrEmpty(idStudent,nameof(idStudent));
    }
    private void SetIdCourse(Guid idCourse)
    {
        IdCourseDb = Guard.Against.NullOrEmpty(idCourse,nameof(idCourse));
    }

    private void SetEnrollmentDate(DateOnly enrollmentDate)
    {
        EnrollmentDateDb = Guard.Against.Null(enrollmentDate,nameof(enrollmentDate));
    }

    #endregion
    
}