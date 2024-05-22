using EduHub.StudentService.Application.Services.Interfaces;
using EduHub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Repositories.BaseServices;

public class EducatorService : BaseService<Educator>, IEducatorService
{
    public Task<List<Educator>> GetListEducators(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}