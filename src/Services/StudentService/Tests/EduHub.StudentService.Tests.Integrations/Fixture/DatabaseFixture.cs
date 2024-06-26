using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using EduHub.StudentService.Infrastructure.Data.DbContext;
using EduHub.StudentService.Infrastructure.Repositories;
using EduHub.StudentService.Infrastructure.Repositories.UoW;
using EduHub.StudentService.Application.Services.Mapping;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Repositories.Core;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Application.Services.Interfaces.UoW;
using EduHub.StudentService.Application.Services.Interfaces.UoW.Core;
using EduHub.StudentService.Application.Services.Services;
using EduHub.StudentService.Infrastructure.Data.DataSource;
using EduHub.StudentService.Infrastructure.Migrator;
using EduHub.StudentService.Shared.Config;

namespace EduHub.StudentService.Tests.Integrations.Fixture
{
    public class DatabaseFixture : IAsyncLifetime
    {
        private readonly ServiceProvider _serviceProvider;
        
        public DatabaseFixture()
        {
            var services = new ServiceCollection();
            
            ConfigureServices(services);
            SetupDatabase(services);
            
            _serviceProvider = services.BuildServiceProvider();
        }
        
        public IServiceProvider ServiceProvider => _serviceProvider;
        
        private void ConfigureServices(IServiceCollection services)
        {
            AddAutomapper(services);
            AddUoW(services);
            AddRepositories(services);
            AddServices(services);
        }
        
        private void SetupDatabase(IServiceCollection services)
        {
            var configuration = ConfigHelper.LoadConfiguration();
            var connectionString = configuration.GetConnectionString("TestDatabase");
            
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(EduHubNpgsqlDataSource.Create(connectionString),
                    b => b.MigrationsAssembly(typeof(DesignTimeDbContextFactory).Assembly.FullName)));
        }
        
        private void AddRepositories(IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            services.AddScoped<IEducatorRepository, EducatorRepository>();
        }
        
        private void AddAutomapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CourseMappingProfile));
            services.AddAutoMapper(typeof(EducatorMappingProfile));
            services.AddAutoMapper(typeof(StudentMappingProfile));
            services.AddAutoMapper(typeof(EnrollmentMappingProfile));
        }
        
        private void AddUoW(IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork<AppDbContext>));
            services.AddScoped<IStudentUnitOfWork, StudentUnitOfWork>();
        }
        
        private void AddServices(IServiceCollection services)
        {
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IEducatorService, EducatorService>();
            services.AddScoped<IStudentService, Application.Services.Services.StudentService>();
            services.AddScoped<IEnrollmentService, EnrollmentService>();
        }
        
        public async Task InitializeAsync()
        {
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await dbContext.Database.MigrateAsync();
        }
        
        public async Task DisposeAsync()
        {
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await dbContext.Database.EnsureDeletedAsync();
        }
    }
}