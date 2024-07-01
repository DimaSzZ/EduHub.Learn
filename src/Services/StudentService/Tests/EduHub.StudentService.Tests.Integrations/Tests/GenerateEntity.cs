using AutoMapper;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Infrastructure.Data.DbContext;
using EduHub.StudentService.Shared.Tests.Infrastructure.TestedData;
using EduHub.StudentService.Tests.Integrations.Fixture;
using Microsoft.Extensions.DependencyInjection;

namespace EduHub.StudentService.Tests.Integrations.Tests;

public static class GenerateEntity
{
    private static readonly TestEducatorDataClass _generateEducator = new TestEducatorDataClass();
    private static readonly TestCourseDataClass _generateCourse = new TestCourseDataClass();
    private static readonly TestStudentDataClass _generateStudent = new TestStudentDataClass();
    private static readonly TestEnrollmentDataClass _generateEnrollment = new TestEnrollmentDataClass();
    
    public static async Task<Domain.Entities.Educator> GenerateEducator(DatabaseFixture database)
    {
        await using var transaction = await database.ServiceProvider.GetService<AppDbContext>().Database.BeginTransactionAsync();
        var educatorDto = _generateEducator.GetUpsertDto();
        var educator = database.ServiceProvider.GetService<IMapper>().Map<Domain.Entities.Educator>(educatorDto);
        var educatorResp = await database.ServiceProvider.GetService<IEducatorRepository>().AddAsync(educator, CancellationToken.None);
        await database.ServiceProvider.GetService<AppDbContext>().SaveChangesAsync();
        await transaction.CommitAsync();
        return educatorResp;
    }
    
    public static async Task<Domain.Entities.Course> GenerateCourse(DatabaseFixture database, Guid educatorId)
    {
        await using var transaction = await database.ServiceProvider.GetService<AppDbContext>().Database.BeginTransactionAsync();
        var courseDto = _generateCourse.GetUpsertDto();
        var course = database.ServiceProvider.GetService<IMapper>().Map<Domain.Entities.Course>(courseDto);
        course.Update(course.Name, course.Description, educatorId);
        var courseResp = await database.ServiceProvider.GetService<ICourseRepository>().AddAsync(course, CancellationToken.None);
        await database.ServiceProvider.GetService<AppDbContext>().SaveChangesAsync();
        await transaction.CommitAsync();
        return courseResp;
    }
    
    public static async Task<Domain.Entities.Student> GenerateStudent(DatabaseFixture database)
    {
        await using var transaction = await database.ServiceProvider.GetService<AppDbContext>().Database.BeginTransactionAsync();
        var studentDto = _generateStudent.GetUpsertDto();
        var student = database.ServiceProvider.GetService<IMapper>().Map<Domain.Entities.Student>(studentDto);
        var studentResp = await database.ServiceProvider.GetService<IStudentRepository>().AddAsync(student, CancellationToken.None);
        await database.ServiceProvider.GetService<AppDbContext>().SaveChangesAsync();
        await transaction.CommitAsync();
        return studentResp;
    }
    
    public static async Task<Domain.Entities.Enrollment> GenerateEnrollment(DatabaseFixture database, Guid studentId, Guid courseId)
    {
        await using var transaction = await database.ServiceProvider.GetService<AppDbContext>().Database.BeginTransactionAsync();
        var enrollmentDto = _generateEnrollment.GetUpsertDto();
        var enrollment = database.ServiceProvider.GetService<IMapper>().Map<Domain.Entities.Enrollment>(enrollmentDto);
        enrollment.Update(enrollment.EnrollmentDate,studentId,courseId);
        var enrollmentResp = await database.ServiceProvider.GetService<IEnrollmentRepository>().AddAsync(enrollment, CancellationToken.None);
        await database.ServiceProvider.GetService<AppDbContext>().SaveChangesAsync();
        await transaction.CommitAsync();
        return enrollmentResp;
    }
}