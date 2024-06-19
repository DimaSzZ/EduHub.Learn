using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.UoW;
using EduHub.StudentService.Infrastructure.Data.DbContext;

namespace EduHub.StudentService.Infrastructure.Repositories.UoW
{
    public class StudentUnitOfWork : UnitOfWork<AppDbContext>, IStudentUnitOfWork
    {
        public StudentUnitOfWork(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
        
        public ICourseRepository CoursesRepository => GetRepository<ICourseRepository>();
        public IEducatorRepository EducatorRepository => GetRepository<IEducatorRepository>();
        public IEnrollmentRepository EnrollmentRepository => GetRepository<IEnrollmentRepository>();
        public IStudentRepository StudentRepository => GetRepository<IStudentRepository>();
    }
}