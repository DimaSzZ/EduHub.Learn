using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduHub.StudentService.Infrastructure.Repositories;

public class EducatorRepository : BaseRepository<Educator>, IEducatorRepository
{
    public EducatorRepository(DbContext context) : base(context)
    {
    }
}