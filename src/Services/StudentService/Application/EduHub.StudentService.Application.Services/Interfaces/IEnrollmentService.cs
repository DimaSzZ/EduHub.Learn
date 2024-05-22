using EduHub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Interfaces;

public interface IEnrollmentService
{
    Task AddStudentToCourse(Guid idStudent,Guid idCourse, CancellationToken cancellationToken);
    Task<List<Enrollment>> CheckListEnrollments(Guid idStudent, CancellationToken cancellationToken);
    Task<List<Enrollment>> CheckStudentEnrollments(Guid idStudent,Guid idCourse, CancellationToken cancellationToken);
    Task Delete(Enrollment enrollment, CancellationToken cancellationToken);
}