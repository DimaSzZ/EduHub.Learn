using Ardalis.GuardClauses;
using EduHub.StudentService.Domain.Entities.Core;

namespace EduHub.StudentService.Domain.Entities;


public class Course : BaseEntity
{
    #region Constructor
    
    public Course(Guid id, string courseName, string courseDescription, Guid educatorId)
    {
        SetIdDb(id);
        SetCourseName(courseName);
        SetCourseDescription(courseDescription);
        SetEducatorId(educatorId);
    }
    
    
    #endregion
    
    #region Properties
    
    public string CourseNameDb { get; private set; }
    
    public string CourseDescriptionDb { get; private set; }
    
    public Guid EducatorIdDb { get; private set; }
    
    public Educator EducatorDb { get; private set; }

    #endregion

    #region Methods

    private void SetEducatorId(Guid idStudent)
    {
        EducatorIdDb = Guard.Against.Null(idStudent,nameof(idStudent));
    }

    private void SetCourseDescription(string courseDescription)
    {
        CourseDescriptionDb = Guard.Against.Null(courseDescription, nameof(courseDescription));
    }

    private void SetCourseName(string courseName)
    {
         Guard.Against.NullOrEmpty(courseName,nameof(courseName));
         Guard.Against.OutOfRange(courseName.Length, nameof(courseName), 1, 60);
         CourseNameDb = courseName;
    }

    #endregion
    
}