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
    /// <param name="id"></param>
    /// <param name="courseName"></param>
    /// <param name="courseDescription"></param>
    /// <param name="educatorId"></param>
    public Course(Guid id, string courseName, string courseDescription, Guid educatorId)
    {
        SetIdDb(id);
        SetCourseName(courseName);
        SetCourseDescription(courseDescription);
        SetEducatorId(educatorId);
    }
    
    
    #endregion
    
    #region Properties
    
    /// <summary>
    /// Название курса
    /// </summary>
    public string CourseName { get; private set; }
    
    /// <summary>
    /// Описание курса
    /// </summary>
    
    public string CourseDescription { get; private set; }
    
    /// <summary>
    /// Id преподователя(который проводит курс)
    /// </summary>
    
    public Guid EducatorId { get; private set; }
    
    /// <summary>
    /// Абстракция для преподователя
    /// </summary>
    
    public Educator Educator { get; private set; }

    #endregion

    #region Methods

    private void SetEducatorId(Guid idStudent)
    {
        EducatorId = Guard.Against.Null(idStudent,nameof(idStudent));
    }

    private void SetCourseDescription(string courseDescription)
    {
        CourseDescription = Guard.Against.Null(courseDescription, nameof(courseDescription));
    }

    private void SetCourseName(string courseName)
    {
         Guard.Against.NullOrEmpty(courseName,nameof(courseName));
         Guard.Against.OutOfRange(courseName.Length, nameof(courseName), 1, 60);
         CourseName = courseName;
    }

    #endregion
    
}