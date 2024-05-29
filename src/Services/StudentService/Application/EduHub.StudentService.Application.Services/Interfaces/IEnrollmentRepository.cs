using EduHub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Interfaces;

public interface IEnrollmentRepository : IBaseRepository<Enrollment>
{
    Task<List<Enrollment>> GetStudentEnrollments(Student student,CancellationToken cancellationToken);
}