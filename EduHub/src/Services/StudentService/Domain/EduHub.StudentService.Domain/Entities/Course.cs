using Ardalis.GuardClauses;

namespace EduHub.StudentService.Domain.Entities;


public class Course
{
    #region Constructor
    
    public Course(Guid id, string courseName, string courseDescription, Guid educatorId)
    {
        SetId(id);
        SetCourseName(courseName);
        SetCourseDescription(courseDescription);
        SetId(educatorId);
    }
    
    
    #endregion
    
    #region Properties
    
    public Guid IdDb { get; private set; }
    
    public string CourseNameDb { get; private set; }
    
    public string CourseDescriptionDb { get; private set; }
    
    public Guid EducatorIdDb { get; private set; }
    
    public Educator EducatorDb { get; private set; }

    #endregion

    #region Methods

    private void SetId(Guid idStudent)
    {
        IdDb = Guard.Against.Null(idStudent,nameof(idStudent));
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