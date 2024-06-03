namespace EduHub.StudentService.Application.Services.Interfaces.UoW.Core;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync();
}