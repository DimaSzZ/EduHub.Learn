using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.UoW.Core;

namespace EduHub.StudentService.Application.Services.Interfaces.UoW;

public interface IPgUnitOfWork : IUnitOfWork
{
    ICourseRepository CoursesRepository { get; }
    IEducatorRepository EducatorRepository { get; }
    IEnrollmentRepository EnrollmentRepository { get; }
    IStudentRepository StudentRepository { get; }
}