using EduHub.StudentService.Application.Services.Interfaces;
using EduHub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Repositories.BaseServices;

public class CourseService : BaseService<Course>, ICourseService
{
    public Task<List<Course>> GetListCourses(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}