using Ardalis.GuardClauses;
using AutoMapper;
using EduHub.StudentService.Application.Services.Dto.Enrollment;
using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Application.Services.Interfaces.UoW;
using EduHub.StudentService.Application.Services.Validations.Enrollment;
using EduHub.StudentService.Domain.Entities;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Services;

/// <summary>
/// Сервис зачислений
/// </summary>
public class EnrollmentService : IEnrollmentService
{
    private readonly IMapper _mapper;
    private readonly IStudentUnitOfWork _unitOfWork;
    
    /// <summary>
    /// конструктор, принимающий все необходимые зависимости
    /// </summary>
    /// <param name="mapper">зависимость автомаппера</param>
    /// <param name="unitOfWork">зависимость UoW</param>
    public EnrollmentService(IMapper mapper, IStudentUnitOfWork unitOfWork)
    {
        _mapper = Guard.Against.Null(mapper);
        _unitOfWork = Guard.Against.Null(unitOfWork);
    }
    
    public async Task<EnrollmentResponseDto> AddAsync(EnrollmentCreateDto enrollmentCreateDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(enrollmentCreateDto);
        
        await new EnrollmentCreateDtoValidator().ValidateAndThrowAsync(enrollmentCreateDto, cancellationToken);
        
        var enrollment = _mapper.Map<EnrollmentCreateDto, Enrollment>(enrollmentCreateDto);
        
        var isEnrollment = await _unitOfWork.CoursesRepository.ExistAsync(enrollment.CourseId, cancellationToken);
        if (!isEnrollment)
        {
            throw new EntityNotFoundException<Enrollment>(nameof(Course.Id), enrollment.CourseId);
        }
        
        var isStudent = await _unitOfWork.StudentRepository.ExistAsync(enrollment.StudentId, cancellationToken);
        if (!isStudent)
        {
            throw new EntityNotFoundException<Student>(nameof(Student.Id), enrollment.StudentId);
        }
        
        await _unitOfWork.EnrollmentRepository.AddAsync(enrollment, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return _mapper.Map<Enrollment, EnrollmentResponseDto>(enrollment);
    }
    
    public async Task<List<EnrollmentResponseDto>> GetStudentEnrollmentsAsync(Guid id, CancellationToken cancellationToken)
    {
        var student = await _unitOfWork.StudentRepository.GetByIdAsync(id, cancellationToken);
        if (student == null)
        {
            throw new EntityNotFoundException<Student>(nameof(Enrollment.Id), id);
        }
        
        var enrollments = await _unitOfWork.EnrollmentRepository.GetListByStudentIdAsync(student.Id, cancellationToken);
        return _mapper.Map<List<EnrollmentResponseDto>>(enrollments);
    }
    
    public async Task<List<EnrollmentResponseDto>> GetListEnrollmentsAsync(CancellationToken cancellationToken)
    {
        var enrollments = await _unitOfWork.EnrollmentRepository.GetAllAsync(cancellationToken);
        
        return _mapper.Map<List<EnrollmentResponseDto>>(enrollments);
    }
    
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var enrollment = await GetByIdOrThrowAsync(id, cancellationToken);
        
        await _unitOfWork.EnrollmentRepository.DeleteAsync(enrollment, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
    
    private async Task<Enrollment> GetByIdOrThrowAsync(Guid id, CancellationToken cancellationToken)
    {
        Guard.Against.Default(id);
        var entity = await _unitOfWork.EnrollmentRepository.GetByIdAsync(id, cancellationToken);
        if (entity == null)
        {
            throw new EntityNotFoundException<Enrollment>(nameof(Enrollment.Id), id);
        }
        
        return entity;
    }
}