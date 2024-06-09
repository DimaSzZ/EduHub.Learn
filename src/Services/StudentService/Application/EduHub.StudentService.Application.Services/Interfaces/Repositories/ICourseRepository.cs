using EduHub.StudentService.Application.Services.Interfaces.Repositories.Core;
using EduHub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Interfaces.Repositories;

/// <summary>
/// Репозиторий, отвичающий за работу с Course
/// </summary>
public interface ICourseRepository : IBaseRepository<Course>;