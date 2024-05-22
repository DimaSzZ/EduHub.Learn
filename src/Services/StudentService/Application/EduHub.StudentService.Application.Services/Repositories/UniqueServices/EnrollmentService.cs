using EduHub.StudentService.Application.Services.Interfaces;
using EduHub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Repositories.UniqueServices;

public class EnrollmentService : IEnrollmentService
{
    public Task AddStudentToCourse(Guid idStudent, Guid idCourse, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    
    public Task<List<Enrollment>> CheckListEnrollments(Guid idStudent, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    
    public Task<List<Enrollment>> CheckStudentEnrollments(Guid idStudent, Guid idCourse, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    
    public Task Delete(Enrollment enrollment, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}