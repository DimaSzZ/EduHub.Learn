using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.UoW.Core;

namespace EduHub.StudentService.Application.Services.Interfaces.UoW;

/// <summary>
/// Реализация UoW, которую я везде использую
/// </summary>
public interface IStudentUnitOfWork : IUnitOfWork
{
    ICourseRepository CoursesRepository { get; }
    IEducatorRepository EducatorRepository { get; }
    IEnrollmentRepository EnrollmentRepository { get; }
    IStudentRepository StudentRepository { get; }
    
}