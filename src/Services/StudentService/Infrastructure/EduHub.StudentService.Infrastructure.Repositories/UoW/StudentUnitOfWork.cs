using Ardalis.GuardClauses;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.UoW;
using EduHub.StudentService.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace EduHub.StudentService.Infrastructure.Repositories.UoW
{
    public class StudentUnitOfWork : UnitOfWork<AppDbContext>, IStudentUnitOfWork
    {
        private readonly IServiceProvider _serviceProvider;
        
        public StudentUnitOfWork(AppDbContext context, IServiceProvider serviceProvider)
            : base(context)
        {
            _serviceProvider = Guard.Against.Null(serviceProvider);
        }
        
        public ICourseRepository CoursesRepository => _serviceProvider.GetRequiredService<ICourseRepository>();
        public IEducatorRepository EducatorRepository => _serviceProvider.GetRequiredService<IEducatorRepository>();
        public IEnrollmentRepository EnrollmentRepository => _serviceProvider.GetRequiredService<IEnrollmentRepository>();
        public IStudentRepository StudentRepository => _serviceProvider.GetRequiredService<IStudentRepository>();
    }
}