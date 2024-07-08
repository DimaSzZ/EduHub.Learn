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
    private static readonly TestEducatorDataClass GenerateDtoEducator = new();
    private static readonly TestCourseDataClass GenerateDtoCourse = new();
    private static readonly TestStudentDataClass GenerateDtoStudent = new();
    private static readonly TestEnrollmentDataClass GenerateDtoEnrollment = new();
    
    public static async Task<Educator> GenerateEducator(InfrastructureFixture infrastructure)
    {
        await using var transaction = await infrastructure.ServiceProvider.GetService<AppDbContext>().Database.BeginTransactionAsync();
        var educatorDto = GenerateDtoEducator.GetUpsertDto();
        var educator = infrastructure.ServiceProvider.GetService<IMapper>().Map<Educator>(educatorDto);
        var educatorResp = await infrastructure.ServiceProvider.GetService<IEducatorRepository>().AddAsync(educator);
        await infrastructure.ServiceProvider.GetService<AppDbContext>().SaveChangesAsync();
        await transaction.CommitAsync();
        return educatorResp;
    }
    
    public static async Task<Course> GenerateCourse(InfrastructureFixture infrastructure, Guid educatorId)
    {
        await using var transaction = await infrastructure.ServiceProvider.GetService<AppDbContext>().Database.BeginTransactionAsync();
        var courseDto = GenerateDtoCourse.GetUpsertDto();
        var course = infrastructure.ServiceProvider.GetService<IMapper>().Map<Course>(courseDto);
        course.Update(course.Name, course.Description, educatorId);
        var courseResp = await infrastructure.ServiceProvider.GetService<ICourseRepository>().AddAsync(course);
        await infrastructure.ServiceProvider.GetService<AppDbContext>().SaveChangesAsync();
        await transaction.CommitAsync();
        return courseResp;
    }
    
    public static async Task<Student> GenerateStudent(InfrastructureFixture infrastructure)
    {
        await using var transaction = await infrastructure.ServiceProvider.GetService<AppDbContext>().Database.BeginTransactionAsync();
        var studentDto = GenerateDtoStudent.GetUpsertDto();
        var student = infrastructure.ServiceProvider.GetService<IMapper>().Map<Student>(studentDto);
        var studentResp = await infrastructure.ServiceProvider.GetService<IStudentRepository>().AddAsync(student);
        await infrastructure.ServiceProvider.GetService<AppDbContext>().SaveChangesAsync();
        await transaction.CommitAsync();
        return studentResp;
    }
    
    public static async Task<Enrollment> GenerateEnrollment(InfrastructureFixture infrastructure, Guid studentId, Guid courseId)
    {
        await using var transaction = await infrastructure.ServiceProvider.GetService<AppDbContext>().Database.BeginTransactionAsync();
        var enrollmentDto = GenerateDtoEnrollment.GetUpsertDto(studentId, courseId);
        var enrollment = infrastructure.ServiceProvider.GetService<IMapper>().Map<Enrollment>(enrollmentDto);
        var enrollmentResp = await infrastructure.ServiceProvider.GetService<IEnrollmentRepository>().AddAsync(enrollment);
        await infrastructure.ServiceProvider.GetService<AppDbContext>().SaveChangesAsync();
        await transaction.CommitAsync();
        return enrollmentResp;
    }
}