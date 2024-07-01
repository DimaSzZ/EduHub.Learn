using AutoMapper;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Infrastructure.Data.DbContext;
using EduHub.StudentService.Shared.Tests.Infrastructure.TestedData;
using EduHub.StudentService.Tests.Integrations.Fixture;
using Microsoft.Extensions.DependencyInjection;

namespace EduHub.StudentService.Tests.Integrations.Tests;

using Domain.Entities;

public static class GenerateEntity
{
    private static readonly TestEducatorDataClass _generateEducator = new TestEducatorDataClass();
    private static readonly TestCourseDataClass _generateCourse = new TestCourseDataClass();
    private static readonly TestStudentDataClass _generateStudent = new TestStudentDataClass();
    private static readonly TestEnrollmentDataClass _generateEnrollment = new TestEnrollmentDataClass();
    
    public static async Task<Domain.Entities.Educator> GenerateEducator(InfrastructureFixture infrastructure)
    {
        await using var transaction = await infrastructure.ServiceProvider.GetService<AppDbContext>().Database.BeginTransactionAsync();
        var educatorDto = _generateEducator.GetUpsertDto();
        var educator = infrastructure.ServiceProvider.GetService<IMapper>().Map<Domain.Entities.Educator>(educatorDto);
        var educatorResp = await infrastructure.ServiceProvider.GetService<IEducatorRepository>().AddAsync(educator, CancellationToken.None);
        await infrastructure.ServiceProvider.GetService<AppDbContext>().SaveChangesAsync();
        await transaction.CommitAsync();
        return educatorResp;
    }
    
    public static async Task<Course> GenerateCourse(InfrastructureFixture infrastructure, Guid educatorId)
    {
        await using var transaction = await infrastructure.ServiceProvider.GetService<AppDbContext>().Database.BeginTransactionAsync();
        var courseDto = _generateCourse.GetUpsertDto();
        var course = infrastructure.ServiceProvider.GetService<IMapper>().Map<Course>(courseDto);
        course.Update(course.Name, course.Description, educatorId);
        var courseResp = await infrastructure.ServiceProvider.GetService<ICourseRepository>().AddAsync(course, CancellationToken.None);
        await infrastructure.ServiceProvider.GetService<AppDbContext>().SaveChangesAsync();
        await transaction.CommitAsync();
        return courseResp;
    }
    
    public static async Task<Domain.Entities.Student> GenerateStudent(InfrastructureFixture infrastructure)
    {
        await using var transaction = await infrastructure.ServiceProvider.GetService<AppDbContext>().Database.BeginTransactionAsync();
        var studentDto = _generateStudent.GetUpsertDto();
        var student = infrastructure.ServiceProvider.GetService<IMapper>().Map<Domain.Entities.Student>(studentDto);
        var studentResp = await infrastructure.ServiceProvider.GetService<IStudentRepository>().AddAsync(student, CancellationToken.None);
        await infrastructure.ServiceProvider.GetService<AppDbContext>().SaveChangesAsync();
        await transaction.CommitAsync();
        return studentResp;
    }
    
    public static async Task<Domain.Entities.Enrollment> GenerateEnrollment(InfrastructureFixture infrastructure, Guid studentId, Guid courseId)
    {
        await using var transaction = await infrastructure.ServiceProvider.GetService<AppDbContext>().Database.BeginTransactionAsync();
        var enrollmentDto = _generateEnrollment.GetUpsertDto();
        var enrollment = infrastructure.ServiceProvider.GetService<IMapper>().Map<Domain.Entities.Enrollment>(enrollmentDto);
        enrollment.Update(enrollment.EnrollmentDate, studentId, courseId);
        var enrollmentResp = await infrastructure.ServiceProvider.GetService<IEnrollmentRepository>().AddAsync(enrollment, CancellationToken.None);
        await infrastructure.ServiceProvider.GetService<AppDbContext>().SaveChangesAsync();
        await transaction.CommitAsync();
        return enrollmentResp;
    }
}