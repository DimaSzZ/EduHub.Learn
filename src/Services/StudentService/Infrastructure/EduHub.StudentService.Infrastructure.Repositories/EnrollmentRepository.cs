using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduHub.StudentService.Infrastructure.Repositories;

public class EnrollmentRepository : BaseRepository<Enrollment>, IEnrollmentRepository
{
    public EnrollmentRepository(DbContext context) : base(context)
    {
    }
    
    public async Task<IList<Enrollment>> GetListByStudentIdAsync(Guid studentId, CancellationToken cancellationToken)
    {
        return await _context.Set<Enrollment>().Where(e => e.StudentId == studentId)
            .ToListAsync(cancellationToken);
    }
}