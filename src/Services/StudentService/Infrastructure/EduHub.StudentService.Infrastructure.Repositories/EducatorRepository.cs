using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Domain.Entities;
using EduHub.StudentService.Infrastructure.Repositories.UoW;

namespace EduHub.StudentService.Infrastructure.Repositories;

public class EducatorRepository : BaseRepository<Educator>, IEducatorRepository
{
    public EducatorRepository(StudentUnitOfWork studentUnitOfWork) : base(studentUnitOfWork)
    {
    }
}