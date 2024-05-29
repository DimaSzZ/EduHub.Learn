namespace EduHub.StudentService.Application.Services.Interfaces.UoW;

public interface IUnitOfWork : IDisposable
{
    ICourseRepository CoursesRepository { get; }
    IEducatorRepository EducatorRepository { get; }
    IEnrollmentRepository EnrollmentRepository { get; }
    IStudentRepository StudentRepository { get; }
    
    Task<int> SaveChanges();
}