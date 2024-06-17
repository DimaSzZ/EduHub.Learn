using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Domain.Entities;
using EduHub.StudentService.Infrastructure.Repositories.UoW;
using Microsoft.EntityFrameworkCore;

namespace EduHub.StudentService.Infrastructure.Repositories;

public class EnrollmentRepository : BaseRepository<Enrollment>, IEnrollmentRepository
{
    public EnrollmentRepository(StudentUnitOfWork studentUnitOfWork) : base(studentUnitOfWork)
    {
    }
    
    public async Task<IList<Enrollment>> GetListByStudentIdAsync(Guid studentId, CancellationToken cancellationToken)
    {
        return await _dbSet
            .Where(e => e.StudentId == studentId)
            .ToListAsync(cancellationToken);
    }
}