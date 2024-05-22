using EduHub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Interfaces;

public interface IEducatorService : IBaseService<Educator>
{
    Task<List<Educator>> GetListEducators(CancellationToken cancellationToken);
}