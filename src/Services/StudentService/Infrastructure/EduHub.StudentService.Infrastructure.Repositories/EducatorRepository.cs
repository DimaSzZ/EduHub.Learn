using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Domain.Entities;
using EduHub.StudentService.Infrastructure.Data.DbContext;

namespace EduHub.StudentService.Infrastructure.Repositories;

public class EducatorRepository : BaseRepository<Educator>, IEducatorRepository
{
    public EducatorRepository(AppDbContext context) : base(context)
    {
    }
}