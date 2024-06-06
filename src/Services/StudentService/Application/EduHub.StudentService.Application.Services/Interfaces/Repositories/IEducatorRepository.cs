using EduHub.StudentService.Application.Services.Interfaces.Repositories.Core;
using EduHub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Interfaces.Repositories;

/// <summary>
/// Репозиторий, отвичающий за работу с Educator
/// </summary>
public interface IEducatorRepository : IBaseRepository<Educator>;