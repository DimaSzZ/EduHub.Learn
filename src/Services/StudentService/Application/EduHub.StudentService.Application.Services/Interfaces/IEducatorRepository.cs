using EduHub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Interfaces;

public interface IEducatorRepository : IBaseRepository<Educator>
{
    Task<Educator> GeEducatorById(Guid id,CancellationToken cancellationToken);
}